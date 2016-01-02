using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NW.Entity;
using JiebaNet.Segmenter;
using System.Text;
using Lucene.Net.QueryParsers;
using PagedList;
using Version = Lucene.Net.Util.Version;

namespace NW.Lucene
{
    public class BlogSearcher : SearcherBase
    {
        #region Add & Update Index

        private static void AddToLuceneIndex(Article data, IndexWriter writer)
        {
            // remove older index entry
            var searchQuery = new TermQuery(new Term("Id", data.Id.ToString()));
            writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();
            doc.Add(new Field("Id", data.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Title", data.Title, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Description", data.Description, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Time", data.Time.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Browses", data.Browses.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Category", data.Category, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("UserId", data.UserId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
        }

        public static void UpdateLuceneIndex(IEnumerable<Article> data)
        {
            //var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            var analyzer = SearcherBase.GetAnalyzer();

            using (var writer = new IndexWriter(SearcherBase.Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // replaces older entry if any
                foreach (var sd in data)
                {
                    AddToLuceneIndex(sd, writer);
                }

                analyzer.Close();
            }
        }

        public static void UpdateLuceneIndex(Article data)
        {
            UpdateLuceneIndex(new[] { data });
        }

        #endregion


        #region Clear Index
        /// <summary>
        /// 按id清楚
        /// </summary>
        /// <param name="recordId"></param>
        public static void ClearLuceneIndexRecord(int recordId)
        {
            //var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            var analyzer = SearcherBase.GetAnalyzer();
            using (var writer = new IndexWriter(SearcherBase.Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                var searchQuery = new TermQuery(new Term("Id", recordId.ToString()));
                writer.DeleteDocuments(searchQuery);

                analyzer.Close();
            }
        }
        /// <summary>
        /// 清楚全部
        /// </summary>
        /// <returns></returns>
        public static bool ClearLuceneIndex()
        {
            try
            {
                //var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                var analyzer = SearcherBase.GetAnalyzer();
                using (var writer = new IndexWriter(SearcherBase.Directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    writer.DeleteAll();

                    analyzer.Close();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Optimize Index

        public static void OptimizeLuceneIndex()
        {
            //var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            var analyzer = SearcherBase.GetAnalyzer();
            using (var writer = new IndexWriter(SearcherBase.Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
            }
        }

        #endregion

        #region Mappers

        private static Article MapDataToModel(Document doc)
        {
            return new Article()
            {
                Id = int.Parse(doc.Get("Id")),
                Title = doc.Get("Title"),
                Description = doc.Get("Description"),
                Time = Convert.ToDateTime(doc.Get("Time")),
                Browses = Convert.ToInt32(doc.Get("Browses")),
                Category = doc.Get("Category"),
                UserId = Convert.ToInt32(doc.Get("UserId"))
            };
        }

        private static IEnumerable<Article> MapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(MapDataToModel).ToList();
        }

        private static IEnumerable<Article> MapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
            return hits.Select(hit => MapDataToModel(searcher.Doc(hit.Doc))).ToList();
        }

        #endregion

        /// <summary>
        /// All the data indexed. 得到全部的索引
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Article> GetAllData()
        {
            if (!System.IO.Directory.EnumerateFiles(LuceneDir).Any())
            {
                return new List<Article>();
            }

            var searcher = new IndexSearcher(Directory, false);
            var reader = IndexReader.Open(Directory, false);
            var docs = new List<Document>();
            var term = reader.TermDocs();

            while (term.Next())
            {
                docs.Add(searcher.Doc(term.Doc));
            }

            reader.Dispose();
            searcher.Dispose();
            return MapLuceneToDataList(docs);
        }


        #region Search

        private static string GetKeyWordsSplitBySpace(string keywords, JiebaTokenizer tokenizer)
        {
            var result = new StringBuilder();

            var words = tokenizer.Tokenize(keywords);

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word.Word))
                {
                    continue;
                }

                result.AppendFormat("{0} ", word.Word);
            }

            return result.ToString().Trim();
        }

        private static Query ParseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException pe)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim() + "*"));
            }

            return query;
        }

        private static IEnumerable<Article> SearchQuery(string searchQuery, int pageIndex, int pageSize, string searchField = "")
        {
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", "")))
            {
                return new List<Article>();
            }

            using (var searcher = new IndexSearcher(SearcherBase.Directory, false))
            {
                var hitsLimit = 1000;
                //var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                var analyzer = SearcherBase.GetAnalyzer();

                if (!string.IsNullOrEmpty(searchField))
                {
                    var parser = new QueryParser(Version.LUCENE_30, searchField, analyzer);
                    var query = ParseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, hitsLimit).ScoreDocs;
                    hits = hits.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
                    var results = MapLuceneToDataList(hits, searcher);
                    analyzer.Dispose();
                    return results;
                }
                else
                {
                    var parser = new MultiFieldQueryParser(Version.LUCENE_30, new[] { "Id", "Title", "Description", "Time", "Browses", "Category", "UserId" }, analyzer);
                    var query = ParseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;
                    hits = hits.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
                    var results = MapLuceneToDataList(hits, searcher);
                    foreach (var item in results)
                    {
                        item.Description = SearcherBase.SimpleHighLighter(item.Description, searchQuery, "<font color='#C60A00'>", "</font>", 226);
                    }
                    analyzer.Close();
                    return results;
                }
            }
        }

        public static IEnumerable<Article> Search(string input, int pageIndex, int pageSize, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<Article>();
            }

            var kwords = input;
            kwords = GetKeyWordsSplitBySpace(kwords, new JiebaTokenizer(new JiebaSegmenter(), kwords));

            var terms = kwords.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);

            return SearchQuery(input, pageIndex, pageSize, fieldName);
        }

        public static IEnumerable<Article> SearchDefault(string input, int pageIndex, int pageSize, string fieldName = "")
        {
            return string.IsNullOrEmpty(input) ? new List<Article>() : SearchQuery(input, pageIndex, pageSize, fieldName);
        }

        #endregion
    }
}
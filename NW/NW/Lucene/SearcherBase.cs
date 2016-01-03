using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NW.Lucene
{
    public class SearcherBase
    {
        /// <summary>
        ///  项目根目录下
        /// </summary>
        public static string LuceneDir = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "lucene_index");

        private static FSDirectory _directoryTemp;

        public static FSDirectory Directory
        {
            get
            {
                if (_directoryTemp == null)
                {
                    _directoryTemp = FSDirectory.Open(new DirectoryInfo(SearcherBase.LuceneDir));
                }
                if (IndexWriter.IsLocked(_directoryTemp))
                {
                    IndexWriter.Unlock(_directoryTemp);
                }

                var lockFilePath = Path.Combine(LuceneDir, "write.lock");
                if (File.Exists(lockFilePath))
                {
                    File.Delete(lockFilePath);
                }

                return _directoryTemp;
            }
        }

        public static Analyzer GetAnalyzer()
        {
            return new JiebaAnalyzer();
        }


        /// <summary>
        /// 高亮处理
        /// </summary>
        /// <param name="p_Body"></param>
        /// <param name="p_KeyWords"></param>
        /// <param name="p_Before"></param>
        /// <param name="p_After"></param>
        /// <param name="p_MaxLength"></param>
        /// <returns></returns>
        public static string SimpleHighLighter(string p_Body, string p_KeyWords, string p_Before,
         string p_After, int p_MaxLength)
        {
            p_KeyWords = p_KeyWords.Trim('*').Trim();
            string[] KeyWords = p_KeyWords.Trim().Split('*');

            for (int i = 0; i < KeyWords.Length; i++)
            {
                string key = KeyWords[i].Trim();
                if (!string.IsNullOrEmpty(key))
                {
                    p_Body = p_Body.Replace(key, p_Before + key + p_After);
                }
            }
            return p_Body;
        }
    }
}
# -*- coding: utf-8 -*-
import sys
import MySQLdb
conn = MySQLdb.connect(host="121.42.136.4", user='root', passwd='123456', db='nw', port=3306,charset='utf8')
cursor = conn.cursor()
reload(sys)
sys.setdefaultencoding('utf8')
file_object = open('sensitive.txt')
str=""
for line in file_object.read().split('\n'):
    name=line.decode("GBK").encode("utf-8")
    cursor.execute("select * from `sensitive` where Name = '" + name + "'");
    result = cursor.fetchall()
    if (len(result) == 0):
        str+="('"+name+"',0),"
        print name
    else:
        print "Is have"
try:
    if(len(str)!=0):
        insert_sql = "INSERT INTO `sensitive`(`Name`,`Lock`) VALUES "+str[0:-1];
        id=cursor.execute(insert_sql)
        conn.commit()
        print id
    cursor.execute("delete from `sensitive` where Id in (select b.Id from (select Max(Id) as Id from `sensitive` group by Name having COUNT(*)>1) as b)")
    conn.commit()
except MySQLdb.Error, e:
    print "Mysql Error %d: %s" % (e.args[0], e.args[1])
cursor.close()
conn.close()
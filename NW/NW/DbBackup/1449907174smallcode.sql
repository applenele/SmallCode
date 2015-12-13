-- MySQL dump 10.13  Distrib 5.5.40, for Win32 (x86)
--
-- Host: 121.42.136.4    Database: nw
-- ------------------------------------------------------
-- Server version	5.5.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `article`
--

DROP TABLE IF EXISTS `article`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `article` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Time` datetime DEFAULT NULL,
  `Browses` int(11) NOT NULL DEFAULT '0',
  `Category` varchar(255) DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `article`
--

LOCK TABLES `article` WRITE;
/*!40000 ALTER TABLE `article` DISABLE KEYS */;
INSERT INTO `article` VALUES (3,'请问请问','请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问请问','2015-12-07 22:38:13',8,'网络',4);
/*!40000 ALTER TABLE `article` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (7,'网络','2015-12-07 22:26:27');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Time` datetime DEFAULT NULL,
  `Category` varchar(255) DEFAULT NULL,
  `Cover` varchar(255) DEFAULT NULL,
  `Lecturer` varchar(255) DEFAULT NULL,
  `Browses` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (5,'网络入门课程','网盘地址：www.baidu.com \r\n密码 ：1234','2015-12-12 09:58:47','网络','/Pictures/1449885500.png','test',3);
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `demand`
--

DROP TABLE IF EXISTS `demand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `demand` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL COMMENT '用户id',
  `DateTime` datetime DEFAULT NULL COMMENT '提交时间',
  `State` int(11) DEFAULT '0' COMMENT '状态',
  `Price` float DEFAULT NULL COMMENT '价格',
  `ReviewTime` varchar(255) DEFAULT NULL COMMENT '审核时间',
  `VideoId` int(11) DEFAULT NULL COMMENT '视频id',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='需求';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `demand`
--

LOCK TABLES `demand` WRITE;
/*!40000 ALTER TABLE `demand` DISABLE KEYS */;
/*!40000 ALTER TABLE `demand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `image`
--

DROP TABLE IF EXISTS `image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `image` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Path` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `image`
--

LOCK TABLES `image` WRITE;
/*!40000 ALTER TABLE `image` DISABLE KEYS */;
INSERT INTO `image` VALUES (3,'demo','demo','/Pictures/1449885353.jpg','2015-12-12 09:55:52'),(4,'星空','哈哈哈','/Pictures/1449885500.png','2015-12-12 09:58:20');
/*!40000 ALTER TABLE `image` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Time` datetime DEFAULT NULL,
  `Thread` varchar(255) DEFAULT NULL,
  `Level` varchar(255) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Exception` varchar(255) DEFAULT NULL,
  `Ip` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=172 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logs`
--

LOCK TABLES `logs` WRITE;
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
INSERT INTO `logs` VALUES (8,'2015-12-07 22:22:54','11','INFO','??','lenny:??','','::1'),(9,'2015-12-07 22:31:28','7','INFO','','','',''),(10,'2015-12-07 22:33:13','49','INFO','??','???http://localhost:55470/Home/Index','','::1'),(12,'2015-12-07 22:35:09','45','INFO','??','???http://localhost:55470/Home/Index','','::1'),(13,'2015-12-07 22:35:23','47','INFO','??','???http://localhost:55470/Home/Index','','::1'),(14,'2015-12-07 22:35:58','45','INFO','??','???http://localhost:55470/Home/Index','','::1'),(15,'2015-12-07 22:39:19','38','INFO','记录','访问了http://localhost:55470/Home/Index','','::1'),(16,'2015-12-07 22:43:57','35','INFO','记录','访问了http://localhost:55470/','','::1'),(17,'2015-12-07 22:47:58','32','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(18,'2015-12-07 22:48:12','45','INFO','记录','lenny:访问了http://localhost:55470/User/Logout','','::1'),(19,'2015-12-07 22:48:12','32','INFO','记录','游客访问了http://localhost:55470/','','::1'),(20,'2015-12-07 22:48:13','46','INFO','记录','游客访问了http://localhost:55470/','','::1'),(21,'2015-12-07 22:48:14','26','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(22,'2015-12-07 22:48:17','32','INFO','记录','游客访问了http://localhost:55470/Blog/Show/3','','::1'),(23,'2015-12-07 22:48:29','16','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(24,'2015-12-07 22:48:29','16','INFO','记录','lenny:登陆','','::1'),(25,'2015-12-07 22:48:29','27','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(26,'2015-12-07 23:12:46','6','INFO','记录','游客访问了http://localhost:55470/','','::1'),(27,'2015-12-07 23:13:05','6','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(28,'2015-12-07 23:13:07','6','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(29,'2015-12-07 23:13:09','6','INFO','记录','游客访问了http://localhost:55470/Blog/Show/3','','::1'),(30,'2015-12-07 23:13:11','6','INFO','记录','游客访问了http://localhost:55470/Blog/Show/4','','::1'),(31,'2015-12-07 23:13:16','6','ERROR','记录','http://localhost:55470/Blog/Show/4未将对象引用设置到对象的实例。','','::1'),(32,'2015-12-07 23:13:37','7','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(33,'2015-12-07 23:13:37','7','INFO','记录','lenny:登陆','','::1'),(34,'2015-12-07 23:13:37','11','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(35,'2015-12-07 23:15:20','6','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(36,'2015-12-07 23:15:24','11','INFO','记录','lenny:访问了http://localhost:55470/Blog','','::1'),(37,'2015-12-07 23:15:26','11','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/3','','::1'),(38,'2015-12-07 23:15:28','11','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/5','','::1'),(39,'2015-12-07 23:15:28','11','ERROR','异常','http://localhost:55470/Blog/Show/5未将对象引用设置到对象的实例。','','::1'),(40,'2015-12-07 23:26:12','32','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(41,'2015-12-07 23:26:16','20','INFO','记录','lenny:访问了http://localhost:55470/Blog','','::1'),(42,'2015-12-07 23:26:17','47','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/3','','::1'),(43,'2015-12-07 23:26:21','6','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/4','','::1'),(44,'2015-12-07 23:26:21','6','ERROR','异常','http://localhost:55470/Blog/Show/4未将对象引用设置到对象的实例。','','::1'),(45,'2015-12-07 23:26:21','6','ERROR','异常','Global record:http://localhost:55470/Blog/Show/4未将对象引用设置到对象的实例。','','::1'),(46,'2015-12-07 23:26:25','32','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/4','','::1'),(47,'2015-12-07 23:26:25','32','ERROR','异常','http://localhost:55470/Blog/Show/4未将对象引用设置到对象的实例。','','::1'),(48,'2015-12-07 23:26:25','32','ERROR','异常','Global record:http://localhost:55470/Blog/Show/4未将对象引用设置到对象的实例。','','::1'),(49,'2015-12-11 13:47:39','6','INFO','记录','游客访问了http://localhost:55470/','','::1'),(50,'2015-12-12 09:17:25','6','INFO','记录','游客访问了http://localhost:55470/','','::1'),(52,'2015-12-12 09:19:41','13','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(53,'2015-12-12 09:19:52','6','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(54,'2015-12-12 09:19:54','6','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(55,'2015-12-12 09:20:00','9','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(56,'2015-12-12 09:20:00','9','INFO','记录','lenny:登陆','','::1'),(57,'2015-12-12 09:20:00','9','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(58,'2015-12-12 09:20:02','6','INFO','记录','lenny:访问了http://localhost:55470/User/Show/4','','::1'),(60,'2015-12-12 09:21:31','13','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(61,'2015-12-12 09:30:04','9','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(62,'2015-12-12 09:30:07','23','INFO','记录','lenny:访问了http://localhost:55470/Course','','::1'),(63,'2015-12-12 09:35:18','26','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(64,'2015-12-12 09:39:31','34','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(65,'2015-12-12 09:39:43','34','INFO','记录','lenny:访问了http://localhost:55470/Blog','','::1'),(66,'2015-12-12 09:39:45','26','INFO','记录','lenny:访问了http://localhost:55470/Blog/Show/3','','::1'),(67,'2015-12-12 09:39:54','37','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(84,'2015-12-12 13:34:24','65','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898465smallcode.sql','','::1'),(85,'2015-12-12 13:34:45','65','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898486smallcode.sql','','::1'),(86,'2015-12-12 13:35:27','68','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(87,'2015-12-12 13:36:20','65','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898556smallcode.sql','','::1'),(88,'2015-12-12 13:40:34','65','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(89,'2015-12-12 13:40:41','68','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898842smallcode.sql','','::1'),(90,'2015-12-12 13:41:56','75','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898916smallcode.sql','','::1'),(91,'2015-12-12 13:43:17','68','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898998smallcode.sql','','::1'),(92,'2015-12-12 13:43:19','75','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449898999smallcode.sql','','::1'),(93,'2015-12-12 13:44:11','7','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449899051smallcode.sql','','::1'),(94,'2015-12-12 13:47:25','69','ERROR','异常','lenny备份数据库出错','','::1'),(95,'2015-12-12 13:51:41','21','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449899501smallcode.sql','','::1'),(96,'2015-12-12 13:52:27','54','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449899547smallcode.sql','','::1'),(97,'2015-12-12 13:59:14','46','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449899925smallcode.sql','','::1'),(98,'2015-12-12 14:00:12','47','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900012smallcode.sql','','::1'),(99,'2015-12-12 14:00:19','46','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900019smallcode.sql','','::1'),(100,'2015-12-12 14:03:12','28','ERROR','异常','lenny备份数据库出错系统找不到指定的文件。','','::1'),(101,'2015-12-12 14:09:07','47','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900548smallcode.sql','','::1'),(102,'2015-12-12 14:09:10','69','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900550smallcode.sql','','::1'),(103,'2015-12-12 14:10:08','24','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900608smallcode.sql','','::1'),(104,'2015-12-12 14:10:15','69','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900616smallcode.sql','','::1'),(105,'2015-12-12 14:10:16','47','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900617smallcode.sql','','::1'),(106,'2015-12-12 14:11:03','69','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449900664smallcode.sql','','::1'),(107,'2015-12-12 14:51:53','17','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903113smallcode.sql','','::1'),(108,'2015-12-12 14:57:14','7','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903435smallcode.sql','','::1'),(109,'2015-12-12 14:57:19','22','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903440smallcode.sql','','::1'),(110,'2015-12-12 14:57:32','40','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903453smallcode.sql','','::1'),(111,'2015-12-12 14:57:37','22','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903457smallcode.sql','','::1'),(112,'2015-12-12 14:57:38','40','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903458smallcode.sql','','::1'),(113,'2015-12-12 14:57:38','22','INFO','记录','lenny备份了数据库D:\\document\\work\\net\\NW\\NW\\NW\\DbBackup\\1449903459smallcode.sql','','::1'),(118,'2015-12-12 15:48:40','23','INFO','记录','lenny批量删除日志116','','::1'),(119,'2015-12-12 15:48:43','21','INFO','记录','lenny批量删除日志117','','::1'),(120,'2015-12-12 15:48:56','48','INFO','记录','lenny批量删除日志115','','::1'),(121,'2015-12-12 15:48:59','23','INFO','记录','lenny批量删除日志114','','::1'),(122,'2015-12-12 15:50:10','48','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(123,'2015-12-12 15:50:12','45','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(124,'2015-12-12 15:50:12','28','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(125,'2015-12-12 15:50:13','21','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(126,'2015-12-12 15:50:14','48','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(127,'2015-12-12 15:50:14','22','ERROR','异常','Global record:http://localhost:55470/Admin/Link/Index未找到路径“/Admin/Link/Index”的控制器或该控制器未实现 IController。','','::1'),(128,'2015-12-12 15:51:11','48','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(129,'2015-12-12 15:51:15','39','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(130,'2015-12-12 15:51:36','22','INFO','记录','lenny:访问了http://localhost:55470/User/Logout','','::1'),(131,'2015-12-12 15:51:36','39','INFO','记录','游客访问了http://localhost:55470/','','::1'),(132,'2015-12-12 15:51:38','28','ERROR','异常','Global record:http://localhost:55470/Admin/Notification/Index无法对 null 引用执行运行时绑定','','::1'),(133,'2015-12-12 15:51:40','48','ERROR','异常','Global record:http://localhost:55470/Admin/Notification/Index无法对 null 引用执行运行时绑定','','::1'),(134,'2015-12-12 15:51:40','33','ERROR','异常','Global record:http://localhost:55470/Admin/Notification/Index无法对 null 引用执行运行时绑定','','::1'),(135,'2015-12-12 15:51:42','45','INFO','记录','游客访问了http://localhost:55470/Home/Index?ReturnUrl=%2fAdmin%2f','','::1'),(136,'2015-12-12 15:52:09','37','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(137,'2015-12-12 15:52:11','38','INFO','记录','游客访问了http://localhost:55470/Blog/Show/3','','::1'),(138,'2015-12-12 15:52:13','37','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(139,'2015-12-12 15:52:14','28','INFO','记录','游客访问了http://localhost:55470/Forum','','::1'),(140,'2015-12-12 15:52:16','22','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(141,'2015-12-12 15:52:22','22','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(142,'2015-12-12 15:52:23','48','INFO','记录','游客访问了http://localhost:55470/','','::1'),(143,'2015-12-12 15:52:24','21','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(144,'2015-12-12 15:52:52','45','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(145,'2015-12-12 15:52:59','23','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(146,'2015-12-12 15:53:01','33','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(147,'2015-12-12 15:53:13','33','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(148,'2015-12-12 15:53:15','38','INFO','记录','游客访问了http://localhost:55470/Forum','','::1'),(149,'2015-12-12 15:53:16','45','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(150,'2015-12-12 15:53:17','37','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(151,'2015-12-12 15:53:18','38','INFO','记录','游客访问了http://localhost:55470/Course','','::1'),(152,'2015-12-12 15:53:20','39','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(153,'2015-12-12 15:53:24','28','INFO','记录','游客访问了http://localhost:55470/','','::1'),(154,'2015-12-12 15:53:34','48','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(155,'2015-12-12 15:53:37','23','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(156,'2015-12-12 15:53:37','28','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(157,'2015-12-12 15:53:38','38','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(158,'2015-12-12 15:53:38','21','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(159,'2015-12-12 15:53:39','39','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(160,'2015-12-12 15:53:39','37','ERROR','异常','Global record:http://localhost:55470/Admin/Log?page=1无法对 null 引用执行运行时绑定','','::1'),(161,'2015-12-12 15:54:28','33','INFO','记录','游客访问了http://localhost:55470/Home/Index?ReturnUrl=%2fAdmin%2fLog%3fpage%3d1&page=1','','::1'),(162,'2015-12-12 15:57:37','22','INFO','记录','游客访问了http://localhost:55470/Blog','','::1'),(163,'2015-12-12 15:58:57','23','INFO','记录','游客访问了http://localhost:55470/Home/Index?ReturnUrl=%2fAdmin%2fDb%2fBackup','','::1'),(164,'2015-12-12 15:59:02','33','ERROR','异常','Global record:http://localhost:55470/User/Login在控制器“NW.Controllers.UserController”上未找到公共操作方法“Login”。','','::1'),(165,'2015-12-12 15:59:13','45','INFO','记录','游客访问了http://localhost:55470/User/Login','','::1'),(166,'2015-12-12 15:59:13','45','INFO','记录','lenny:登陆','','::1'),(167,'2015-12-12 15:59:13','33','INFO','记录','lenny:访问了http://localhost:55470/Home/Index','','::1'),(168,'2015-12-12 15:59:15','38','INFO','记录','lenny:访问了http://localhost:55470/Blog','','::1'),(169,'2015-12-12 15:59:17','21','INFO','记录','lenny:访问了http://localhost:55470/','','::1'),(170,'2015-12-12 15:59:18','33','INFO','记录','lenny:访问了http://localhost:55470/Forum','','::1'),(171,'2015-12-12 15:59:20','45','INFO','记录','lenny:访问了http://localhost:55470/Blog','','::1');
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notification` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreatedTime` datetime DEFAULT NULL,
  `Description` text,
  `Priority` int(11) DEFAULT NULL,
  `IsShow` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
INSERT INTO `notification` VALUES (4,'2015-12-12 15:51:09','SmallCode 开始啦',1,'');
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plateforum`
--

DROP TABLE IF EXISTS `plateforum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plateforum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Picture` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `Report` int(11) DEFAULT NULL,
  `IsClose` tinyint(4) DEFAULT NULL,
  `Browses` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plateforum`
--

LOCK TABLES `plateforum` WRITE;
/*!40000 ALTER TABLE `plateforum` DISABLE KEYS */;
/*!40000 ALTER TABLE `plateforum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reply`
--

DROP TABLE IF EXISTS `reply`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reply` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `BlogId` int(11) NOT NULL,
  `Description` text,
  `FatherId` int(11) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reply`
--

LOCK TABLES `reply` WRITE;
/*!40000 ALTER TABLE `reply` DISABLE KEYS */;
/*!40000 ALTER TABLE `reply` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `replyforum`
--

DROP TABLE IF EXISTS `replyforum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `replyforum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TopicId` int(11) NOT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  `FatherId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `replyforum`
--

LOCK TABLES `replyforum` WRITE;
/*!40000 ALTER TABLE `replyforum` DISABLE KEYS */;
/*!40000 ALTER TABLE `replyforum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `topicforum`
--

DROP TABLE IF EXISTS `topicforum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `topicforum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Content` varchar(255) CHARACTER SET gbk DEFAULT NULL,
  `Top` tinyint(4) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `LastReply` datetime DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  `Reward` int(11) DEFAULT NULL,
  `Browses` int(11) NOT NULL,
  `Report` int(11) DEFAULT NULL,
  `IsShow` tinyint(4) DEFAULT NULL,
  `IsClose` tinyint(4) DEFAULT NULL,
  `IsOfficeIdentified` tinyint(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `topicforum`
--

LOCK TABLES `topicforum` WRITE;
/*!40000 ALTER TABLE `topicforum` DISABLE KEYS */;
/*!40000 ALTER TABLE `topicforum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(255) DEFAULT NULL,
  `Password` varchar(40) DEFAULT NULL,
  `Email` varchar(40) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `QQ` varchar(20) DEFAULT NULL,
  `Address` text,
  `Remark` text,
  `Program` varchar(255) DEFAULT NULL,
  `Photo` varchar(255) DEFAULT NULL,
  `RoleAsInt` int(1) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (4,'lenny','e10adc3949ba59abbe56e057f20f883e','1941973283@qq.com',NULL,NULL,NULL,NULL,NULL,NULL,2,'2015-12-07 22:12:50');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `video`
--

DROP TABLE IF EXISTS `video`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `video` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CourseId` int(11) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Category` varchar(255) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Seret` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `Description` text,
  `UserId` int(11) NOT NULL,
  `AuthorityAsInt` int(1) NOT NULL DEFAULT '0',
  `Browses` int(11) NOT NULL DEFAULT '0',
  `ContentType` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `video`
--

LOCK TABLES `video` WRITE;
/*!40000 ALTER TABLE `video` DISABLE KEYS */;
INSERT INTO `video` VALUES (8,5,'网络入门课程（1）','网络',NULL,NULL,'2015-12-12 10:04:11','网络入门课程（1）',4,0,4,NULL);
/*!40000 ALTER TABLE `video` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-12-12 15:59:44

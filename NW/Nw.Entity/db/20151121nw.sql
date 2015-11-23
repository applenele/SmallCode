# Host: localhost  (Version: 5.5.40)
# Date: 2015-11-21 11:07:15
# Generator: MySQL-Front 5.3  (Build 4.120)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "category"
#

DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

#
# Data for table "category"
#

/*!40000 ALTER TABLE `category` DISABLE KEYS */;
/*!40000 ALTER TABLE `category` ENABLE KEYS */;

#
# Structure for table "course"
#

DROP TABLE IF EXISTS `course`;
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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

#
# Data for table "course"
#

/*!40000 ALTER TABLE `course` DISABLE KEYS */;
/*!40000 ALTER TABLE `course` ENABLE KEYS */;

#
# Structure for table "demand"
#

DROP TABLE IF EXISTS `demand`;
CREATE TABLE `demand` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL COMMENT '用户id',
  `DateTime` datetime DEFAULT NULL COMMENT '提交时间',
  `IsDo` int(11) DEFAULT '0' COMMENT '是否做',
  `Price` float DEFAULT NULL COMMENT '价格',
  `ReviewTime` varchar(255) DEFAULT NULL COMMENT '审核时间',
  `VideoId` int(11) DEFAULT NULL COMMENT '视频id',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='需求';

#
# Data for table "demand"
#

/*!40000 ALTER TABLE `demand` DISABLE KEYS */;
/*!40000 ALTER TABLE `demand` ENABLE KEYS */;

#
# Structure for table "image"
#

DROP TABLE IF EXISTS `image`;
CREATE TABLE `image` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Path` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "image"
#

/*!40000 ALTER TABLE `image` DISABLE KEYS */;
/*!40000 ALTER TABLE `image` ENABLE KEYS */;

#
# Structure for table "logs"
#

DROP TABLE IF EXISTS `logs`;
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
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

#
# Data for table "logs"
#

/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;

#
# Structure for table "reply"
#

DROP TABLE IF EXISTS `reply`;
CREATE TABLE `reply` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `BlogId` int(11) NOT NULL,
  `Description` text,
  `FatherId` int(11) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

#
# Data for table "reply"
#

/*!40000 ALTER TABLE `reply` DISABLE KEYS */;
/*!40000 ALTER TABLE `reply` ENABLE KEYS */;

#
# Structure for table "user"
#

DROP TABLE IF EXISTS `user`;
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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "user"
#

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

#
# Structure for table "userid"
#

DROP TABLE IF EXISTS `userid`;
CREATE TABLE `userid` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Time` datetime DEFAULT NULL,
  `Browses` int(11) NOT NULL DEFAULT '0',
  `Category` varchar(255) DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "userid"
#

/*!40000 ALTER TABLE `userid` DISABLE KEYS */;
/*!40000 ALTER TABLE `userid` ENABLE KEYS */;

#
# Structure for table "video"
#

DROP TABLE IF EXISTS `video`;
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
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

#
# Data for table "video"
#

/*!40000 ALTER TABLE `video` DISABLE KEYS */;
/*!40000 ALTER TABLE `video` ENABLE KEYS */;

/*
Navicat MySQL Data Transfer

Source Server         : loca
Source Server Version : 50540
Source Host           : localhost:3306
Source Database       : nw

Target Server Type    : MYSQL
Target Server Version : 50540
File Encoding         : 65001

Date: 2015-11-23 21:42:27
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for article
-- ----------------------------
DROP TABLE IF EXISTS `article`;
CREATE TABLE `article` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Time` datetime DEFAULT NULL,
  `Browses` int(11) NOT NULL DEFAULT '0',
  `Category` varchar(255) DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for course
-- ----------------------------
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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for demand
-- ----------------------------
DROP TABLE IF EXISTS `demand`;
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

-- ----------------------------
-- Table structure for image
-- ----------------------------
DROP TABLE IF EXISTS `image`;
CREATE TABLE `image` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Description` text,
  `Path` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for logs
-- ----------------------------
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
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for notification
-- ----------------------------
DROP TABLE IF EXISTS `notification`;
CREATE TABLE `notification` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreatedTime` datetime DEFAULT NULL,
  `Description` text,
  `Priority` int(11) DEFAULT NULL,
  `IsShow` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for plateforum
-- ----------------------------
DROP TABLE IF EXISTS `plateforum`;
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

-- ----------------------------
-- Table structure for reply
-- ----------------------------
DROP TABLE IF EXISTS `reply`;
CREATE TABLE `reply` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `BlogId` int(11) NOT NULL,
  `Description` text,
  `FatherId` int(11) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for replyforum
-- ----------------------------
DROP TABLE IF EXISTS `replyforum`;
CREATE TABLE `replyforum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TopicId` int(11) NOT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  `FatherId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for topicforum
-- ----------------------------
DROP TABLE IF EXISTS `topicforum`;
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

-- ----------------------------
-- Table structure for user
-- ----------------------------
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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for video
-- ----------------------------
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

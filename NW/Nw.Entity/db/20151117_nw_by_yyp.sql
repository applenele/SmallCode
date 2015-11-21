/*
Navicat MySQL Data Transfer

Source Server         : yyp
Source Server Version : 50540
Source Host           : localhost:3306
Source Database       : nw

Target Server Type    : MYSQL
Target Server Version : 50540
File Encoding         : 65001

Date: 2015-11-17 09:53:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `topicforum`
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
-- Table structure for `plateforum`
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
-- Table structure for `replyforum`
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



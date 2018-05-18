/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50719
Source Host           : 127.0.0.1:3306
Source Database       : rft

Target Server Type    : MYSQL
Target Server Version : 50719
File Encoding         : 65001

Date: 2018-05-12 15:53:46
Author: Terre
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for rft_admin
-- ----------------------------
CREATE TABLE `rft_admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(64) NOT NULL,
  `email` varchar(255) NOT NULL,
  `name` varchar(45) NOT NULL,
  `active` int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of rft_admin
-- ----------------------------
INSERT INTO `rft_admin` VALUES ('1', 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin@localhost', 'Admin', '1'); -- acc: admin, pass: admin

-- ----------------------------
-- Table structure for rft_apikey
-- ----------------------------
CREATE TABLE `rft_apikey` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `apikey` varchar(16) NOT NULL,
  `securitykey` varchar(45) NOT NULL,
  `owner` int(11) NOT NULL,
  `active` int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `apikey_UNIQUE` (`apikey`),
  UNIQUE KEY `security_UNIQUE` (`securitykey`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for rft_eloadasok
-- ----------------------------
CREATE TABLE `rft_eloadasok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `filmid` int(11) NOT NULL,
  `idopont` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `filmid` (`filmid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for rft_filmek
-- ----------------------------
CREATE TABLE `rft_filmek` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cim` varchar(60) NOT NULL,
  `mufaj` varchar(20) DEFAULT NULL,
  `hossz` int(11) DEFAULT NULL,
  `rendezo` varchar(60) DEFAULT NULL,
  `vetitike` int(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for rft_vasarlasok
-- ----------------------------
CREATE TABLE `rft_vasarlasok` (
  `vasarlasid` int(11) NOT NULL AUTO_INCREMENT,
  `filmid` int(11) NOT NULL,
  `vevoid` int(11) NOT NULL,
  `vasarlasIdeje` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`vasarlasid`),
  KEY `filmid` (`filmid`),
  KEY `vevoid` (`vevoid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for rft_vevok
-- ----------------------------
CREATE TABLE `rft_vevok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(60) NOT NULL,
  `torzsvendeg` tinyint(1) DEFAULT NULL,
  `latogatasSzama` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

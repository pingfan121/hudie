/*
Navicat MySQL Data Transfer

Source Server         : 本地_3311
Source Server Version : 50091
Source Host           : 127.0.0.1:3311
Source Database       : app_benefit

Target Server Type    : MYSQL
Target Server Version : 50091
File Encoding         : 65001

Date: 2017-06-06 18:14:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for app_jianyi
-- ----------------------------
DROP TABLE IF EXISTS `app_jianyi`;
CREATE TABLE `app_jianyi` (
  `id` char(32) NOT NULL,
  `userid` char(32) NOT NULL,
  `content` text NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_jianyi
-- ----------------------------
INSERT INTO `app_jianyi` VALUES ('c7c00804eb2d78f059000000', '111', '����һ��', '2017-03-19 02:48:02');
INSERT INTO `app_jianyi` VALUES ('4ee30904eb2d78f059010000', '111', '����һ��', '2017-03-19 02:49:17');
INSERT INTO `app_jianyi` VALUES ('a1260b04eb2d780c43000000', '111', '啊哈哈', '2017-03-19 02:50:39');
INSERT INTO `app_jianyi` VALUES ('43d9d301eb2d78b40e030000', '111', '这也是一条建议', '2017-03-14 16:31:00');
INSERT INTO `app_jianyi` VALUES ('4effd501eb2d78b40e040000', '111', '这也是一条建议', '2017-03-14 16:33:21');

-- ----------------------------
-- Table structure for app_user
-- ----------------------------
DROP TABLE IF EXISTS `app_user`;
CREATE TABLE `app_user` (
  `id` char(24) NOT NULL,
  `mobile` char(11) NOT NULL COMMENT '手机号',
  `mail` char(48) NOT NULL default '' COMMENT '邮件',
  `pass` char(48) NOT NULL default '' COMMENT '密码',
  `wx_id` char(32) NOT NULL,
  `wb_id` char(32) NOT NULL,
  `name` varchar(32) NOT NULL,
  `head` varchar(255) NOT NULL COMMENT '头像图片url',
  `sex` int(11) NOT NULL default '0' COMMENT '性别 1是男 2是女',
  `createtime` bigint(20) NOT NULL COMMENT '创建时间',
  PRIMARY KEY  (`id`),
  KEY `mobile` USING BTREE (`mobile`),
  KEY `wx_id` (`wx_id`),
  KEY `wb_id` (`wb_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_user
-- ----------------------------
INSERT INTO `app_user` VALUES ('123', '123', '123', '123', '', '', '', '', '0', '0');
INSERT INTO `app_user` VALUES ('124', '123', '123', '123', '', '', '', '', '0', '0');
INSERT INTO `app_user` VALUES ('77237803aeddbf4c1f000000', '18789061261', '', '111111', '', '', '', '', '0', '2016');
INSERT INTO `app_user` VALUES ('89ddfa01eb2d78b455000000', '13242423411', '', '111111', '', '', '', '', '0', '2016');
INSERT INTO `app_user` VALUES ('ac524003aeddbf588b000000', '18789081811', '', '111111', '', '', '', '', '0', '2016');
INSERT INTO `app_user` VALUES ('c7fba403aeddbff443000000', '18789061263', '', '111111', '', '', '', '', '0', '2016');
INSERT INTO `app_user` VALUES ('cf486c03aeddbf3012000000', '12345678', '', '111111', '', '', '', '', '0', '2016');
INSERT INTO `app_user` VALUES ('f912a103aeddbfc832000000', '18789061262', '', '111', '', '', '', '', '0', '2016');

-- ----------------------------
-- Table structure for benefit_discuss
-- ----------------------------
DROP TABLE IF EXISTS `benefit_discuss`;
CREATE TABLE `benefit_discuss` (
  `id` char(32) NOT NULL,
  `itemid` char(32) NOT NULL COMMENT '项id(证明 证伪)',
  `userid` char(32) NOT NULL,
  `content` varchar(2048) NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `itemid` (`itemid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of benefit_discuss
-- ----------------------------
INSERT INTO `benefit_discuss` VALUES ('12342143', '123456789', '333222111', '这是一个评论', '2016-07-05 16:31:19');

-- ----------------------------
-- Table structure for benefit_head
-- ----------------------------
DROP TABLE IF EXISTS `benefit_head`;
CREATE TABLE `benefit_head` (
  `id` char(32) NOT NULL,
  `createtime` datetime NOT NULL,
  `name` varchar(32) NOT NULL default '' COMMENT '救助对象',
  `addr` varchar(255) NOT NULL COMMENT '所在位置',
  `needmoney` int(4) NOT NULL COMMENT '需要金额',
  `nowmoney` int(4) NOT NULL COMMENT '筹集金额',
  `over` int(4) NOT NULL COMMENT '是否结束 1 是已经结束 0 没有结束',
  `details` text NOT NULL,
  `userid` char(32) NOT NULL,
  `username` char(32) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of benefit_head
-- ----------------------------
INSERT INTO `benefit_head` VALUES ('111222333', '2016-07-05 15:49:10', '王尼玛', '北京市武警医院', '150000', '0', '0', '甘肃的陈金福老师是“2016年TCL希望工程烛光奖”的获奖教师，作为一名已知天命的老先生，他生命中三十余年的岁月皆在为“教书育人”这一目标而努力。他从教于甘肃省古浪县大靖镇大墩小学，一直致力于创新教学，改善学校环境，为全校32名孩子们谋求福利，如慈父般爱着每个孩子。他说：“当孩子第一次叫老师的时候，我就知道了，我找到我能做一辈子的事儿了。”', '333222111', '');

-- ----------------------------
-- Table structure for benefit_juankuan
-- ----------------------------
DROP TABLE IF EXISTS `benefit_juankuan`;
CREATE TABLE `benefit_juankuan` (
  `id` char(32) NOT NULL,
  `userid` char(32) NOT NULL,
  `itemid` char(32) NOT NULL,
  `gold` float(8,0) NOT NULL,
  `time` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of benefit_juankuan
-- ----------------------------

-- ----------------------------
-- Table structure for benefit_praise
-- ----------------------------
DROP TABLE IF EXISTS `benefit_praise`;
CREATE TABLE `benefit_praise` (
  `id` char(32) NOT NULL,
  `item` char(32) NOT NULL,
  `userid` char(32) NOT NULL,
  `time` datetime NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of benefit_praise
-- ----------------------------
INSERT INTO `benefit_praise` VALUES ('32532535', '123456789', '333222111', '2016-07-05 16:31:44');

-- ----------------------------
-- Table structure for benefit_proof
-- ----------------------------
DROP TABLE IF EXISTS `benefit_proof`;
CREATE TABLE `benefit_proof` (
  `id` char(32) NOT NULL,
  `issueid` char(32) NOT NULL COMMENT '发布人id',
  `issuename` char(32) NOT NULL COMMENT '发布人名字',
  `content` text NOT NULL,
  `praise` int(4) NOT NULL default '0' COMMENT '赞的数量',
  `discuss` int(4) NOT NULL COMMENT '评论的数量',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of benefit_proof
-- ----------------------------
INSERT INTO `benefit_proof` VALUES ('123456789', '333222111', '', '这是一个证据链', '1', '1');

-- ----------------------------
-- Table structure for bored_head
-- ----------------------------
DROP TABLE IF EXISTS `bored_head`;
CREATE TABLE `bored_head` (
  `id` char(32) NOT NULL,
  `useid` char(32) NOT NULL,
  `content` varchar(255) NOT NULL,
  `createtime` bigint(255) NOT NULL default '0' COMMENT '//创建时间全部使用 long类型  毫秒级',
  `rownum` int(11) NOT NULL,
  `invalid` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bored_head
-- ----------------------------

-- ----------------------------
-- Table structure for bored_head_detail
-- ----------------------------
DROP TABLE IF EXISTS `bored_head_detail`;
CREATE TABLE `bored_head_detail` (
  `id` char(32) NOT NULL,
  `headid` char(32) NOT NULL,
  `useid` char(32) NOT NULL,
  `record_len` int(11) NOT NULL,
  `record_url` varchar(512) NOT NULL,
  `createtime` bigint(255) NOT NULL default '0' COMMENT '//创建时间全部使用 long类型  毫秒级',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bored_head_detail
-- ----------------------------
SET FOREIGN_KEY_CHECKS=1;

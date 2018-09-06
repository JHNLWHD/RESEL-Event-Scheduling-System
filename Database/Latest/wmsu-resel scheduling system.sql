CREATE DATABASE  IF NOT EXISTS `wmsu-resel scheduling system` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `wmsu-resel scheduling system`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: wmsu-resel scheduling system
-- ------------------------------------------------------
-- Server version	5.7.14-log

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
-- Table structure for table `academic_year`
--

DROP TABLE IF EXISTS `academic_year`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `academic_year` (
  `idacademic_year` int(11) NOT NULL AUTO_INCREMENT,
  `academic_year_start` year(4) DEFAULT NULL,
  `academic_year_end` year(4) DEFAULT NULL,
  `academic_year` varchar(45) DEFAULT NULL COMMENT 'Concat start + end = unique',
  `academic_year_status` varchar(45) DEFAULT NULL,
  `academic_year_remove_status` varchar(255) DEFAULT NULL,
  `academic_year_reg_date` date DEFAULT NULL,
  `date_settings_iddate_settings` int(11) NOT NULL,
  PRIMARY KEY (`idacademic_year`),
  UNIQUE KEY `academic_year_UNIQUE` (`academic_year`),
  KEY `fk_academic_year_date_settings1_idx` (`date_settings_iddate_settings`),
  FULLTEXT KEY `academic_year_status` (`academic_year_status`),
  CONSTRAINT `fk_academic_year_date_settings1` FOREIGN KEY (`date_settings_iddate_settings`) REFERENCES `date_settings` (`iddate_settings`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academic_year`
--

LOCK TABLES `academic_year` WRITE;
/*!40000 ALTER TABLE `academic_year` DISABLE KEYS */;
INSERT INTO `academic_year` VALUES (4,2017,2018,'2017 - 2018','Active','FALSE','2017-09-18',5);
/*!40000 ALTER TABLE `academic_year` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `idaccount` int(11) NOT NULL AUTO_INCREMENT,
  `account_fn` varchar(255) DEFAULT NULL,
  `account_ln` varchar(255) DEFAULT NULL,
  `account_username` varchar(255) DEFAULT NULL,
  `account_password` varchar(255) DEFAULT NULL,
  `account_status` varchar(45) DEFAULT NULL,
  `account_type` varchar(45) DEFAULT NULL,
  `account_reg_date` date DEFAULT NULL,
  `account_position` varchar(255) DEFAULT NULL,
  `account_remove_status` varchar(255) DEFAULT NULL,
  `account_isActive` varchar(255) DEFAULT NULL,
  `account_isLogin` varchar(255) DEFAULT NULL,
  `unit_idunit` int(11) NOT NULL,
  PRIMARY KEY (`idaccount`),
  KEY `fk_account_unit1_idx` (`unit_idunit`),
  FULLTEXT KEY `account_position` (`account_position`) COMMENT 'status+postion',
  FULLTEXT KEY `account_status` (`account_status`),
  FULLTEXT KEY `account_type` (`account_type`),
  CONSTRAINT `fk_account_unit1` FOREIGN KEY (`unit_idunit`) REFERENCES `unit` (`idunit`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (3,'Juan','Dela Cruz','admin','admin','Active','Admin','2017-09-18','Head','False','True','FALSE',6);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `activity_logs`
--

DROP TABLE IF EXISTS `activity_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `activity_logs` (
  `idactivity_logs` int(11) NOT NULL AUTO_INCREMENT,
  `activity_logs_myact_name` varchar(255) DEFAULT NULL COMMENT 'User act name',
  `activity_logs_act_name` varchar(255) DEFAULT NULL COMMENT 'Admin act name',
  `activity_logs_date` timestamp(6) NULL DEFAULT NULL,
  `account_idaccount` int(11) NOT NULL,
  PRIMARY KEY (`idactivity_logs`),
  KEY `fk_activity_logs_account_idx` (`account_idaccount`),
  CONSTRAINT `fk_activity_logs_account` FOREIGN KEY (`account_idaccount`) REFERENCES `account` (`idaccount`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity_logs`
--

LOCK TABLES `activity_logs` WRITE;
/*!40000 ALTER TABLE `activity_logs` DISABLE KEYS */;
INSERT INTO `activity_logs` VALUES (1,'You have logged in.','Juan Dela Cruz have logged in.','2017-12-06 07:45:18.000000',3),(2,'You have saved new venue: QWERTYUIP','Juan Dela Cruz have saved new venue: QWERTYUIP','2017-12-06 07:47:28.000000',3),(3,'You have logged out.','Juan Dela Cruz have logged out.','2017-12-06 07:49:49.000000',3),(4,'You have logged in.','Juan Dela Cruz have logged in.','2017-12-06 08:20:50.000000',3),(5,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 05:55:40.000000',3),(6,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 05:59:37.000000',3),(7,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 06:09:59.000000',3),(8,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 06:14:10.000000',3),(9,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 06:19:00.000000',3),(10,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 06:20:30.000000',3),(11,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 07:48:16.000000',3),(12,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:05:24.000000',3),(13,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:06:48.000000',3),(14,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:12:16.000000',3),(15,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:13:27.000000',3),(16,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:18:36.000000',3),(17,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:19:34.000000',3),(18,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:22:20.000000',3),(19,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:23:18.000000',3),(20,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:27:24.000000',3),(21,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:28:16.000000',3),(22,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 08:30:56.000000',3),(23,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 08:32:45.000000',3),(24,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 09:13:26.000000',3),(25,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 09:15:29.000000',3),(26,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 09:29:44.000000',3),(27,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 09:32:35.000000',3),(28,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 10:15:55.000000',3),(29,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 10:17:20.000000',3),(30,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-22 10:48:35.000000',3),(31,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-22 10:49:26.000000',3),(32,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-24 03:48:47.000000',3),(33,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-24 03:55:25.000000',3),(34,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-24 04:26:06.000000',3),(35,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-24 04:28:48.000000',3),(38,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-24 05:21:26.000000',3),(39,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-24 05:23:50.000000',3),(40,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-24 05:38:41.000000',3),(41,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-24 05:43:35.000000',3),(42,'You have logged in.','Juan Dela Cruz have logged in.','2018-01-29 10:28:16.000000',3),(43,'You have logged out.','Juan Dela Cruz have logged out.','2018-01-29 10:31:47.000000',3);
/*!40000 ALTER TABLE `activity_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `college`
--

DROP TABLE IF EXISTS `college`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `college` (
  `idcollege` int(11) NOT NULL AUTO_INCREMENT,
  `college_name` varchar(255) DEFAULT NULL,
  `college_abbrev` varchar(255) DEFAULT NULL COMMENT 'Shortcut',
  `college_reg_date` date DEFAULT NULL,
  `college_remove_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idcollege`),
  UNIQUE KEY `college_name_UNIQUE` (`college_name`),
  UNIQUE KEY `college_abbrev_UNIQUE` (`college_abbrev`),
  FULLTEXT KEY `college_name` (`college_name`),
  FULLTEXT KEY `college_abbrev` (`college_abbrev`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `college`
--

LOCK TABLES `college` WRITE;
/*!40000 ALTER TABLE `college` DISABLE KEYS */;
INSERT INTO `college` VALUES (4,'College of Eng','CET','2017-09-19','FALSE');
/*!40000 ALTER TABLE `college` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `date_settings`
--

DROP TABLE IF EXISTS `date_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `date_settings` (
  `iddate_settings` int(11) NOT NULL AUTO_INCREMENT,
  `date_settings_start` int(11) DEFAULT NULL,
  `date_settings_end` int(11) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`iddate_settings`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `date_settings`
--

LOCK TABLES `date_settings` WRITE;
/*!40000 ALTER TABLE `date_settings` DISABLE KEYS */;
INSERT INTO `date_settings` VALUES (5,6,5,'Active');
/*!40000 ALTER TABLE `date_settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department` (
  `iddepartment` int(11) NOT NULL AUTO_INCREMENT,
  `department_name` varchar(255) DEFAULT NULL,
  `department_abbrev` varchar(255) DEFAULT NULL COMMENT 'Shortcut\n',
  `department_reg_date` date DEFAULT NULL,
  `college_idcollege` int(11) NOT NULL,
  `department_remove_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`iddepartment`),
  UNIQUE KEY `department_name_UNIQUE` (`department_name`),
  UNIQUE KEY `department_abbrev_UNIQUE` (`department_abbrev`),
  KEY `fk_department_college1_idx` (`college_idcollege`),
  FULLTEXT KEY `department_name` (`department_name`),
  FULLTEXT KEY `department_abbrev` (`department_abbrev`),
  CONSTRAINT `fk_department_college1` FOREIGN KEY (`college_idcollege`) REFERENCES `college` (`idcollege`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department_has_event`
--

DROP TABLE IF EXISTS `department_has_event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department_has_event` (
  `iddepartment_has_event` int(11) NOT NULL AUTO_INCREMENT,
  `department_iddepartment` int(11) DEFAULT NULL,
  `event_idevent` int(11) DEFAULT NULL,
  `department_has_event_reg_date` date DEFAULT NULL,
  PRIMARY KEY (`iddepartment_has_event`),
  KEY `fk_department_has_event_event1_idx` (`event_idevent`),
  KEY `fk_department_has_event_department1_idx` (`department_iddepartment`),
  CONSTRAINT `fk_department_has_event_department1` FOREIGN KEY (`department_iddepartment`) REFERENCES `department` (`iddepartment`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_department_has_event_event1` FOREIGN KEY (`event_idevent`) REFERENCES `event` (`idevent`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department_has_event`
--

LOCK TABLES `department_has_event` WRITE;
/*!40000 ALTER TABLE `department_has_event` DISABLE KEYS */;
/*!40000 ALTER TABLE `department_has_event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `idevent` int(11) NOT NULL AUTO_INCREMENT,
  `event_code` varchar(255) DEFAULT NULL,
  `event_name` varchar(255) DEFAULT NULL,
  `event_type` varchar(255) DEFAULT NULL,
  `event_number_of_participants` int(11) DEFAULT NULL,
  `event_priority` varchar(45) DEFAULT NULL,
  `event_remove_status` varchar(255) DEFAULT NULL,
  `event_is_cancel` varchar(255) DEFAULT NULL,
  `event_budget` decimal(10,2) DEFAULT NULL,
  `event_status` varchar(255) DEFAULT NULL,
  `event_remarks` varchar(255) DEFAULT NULL,
  `event_unit` varchar(255) DEFAULT NULL,
  `academic_year_idacademic_year` int(11) NOT NULL,
  `account_idaccount` int(11) NOT NULL,
  `event_reg_date` date DEFAULT NULL,
  `event_goal` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idevent`),
  KEY `fk_event_academic_year1_idx` (`academic_year_idacademic_year`),
  KEY `fk_event_account1_idx` (`account_idaccount`),
  FULLTEXT KEY `event_type` (`event_type`),
  FULLTEXT KEY `event_name` (`event_name`),
  FULLTEXT KEY `event_code` (`event_code`),
  CONSTRAINT `fk_event_academic_year1` FOREIGN KEY (`academic_year_idacademic_year`) REFERENCES `academic_year` (`idacademic_year`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_event_account1` FOREIGN KEY (`account_idaccount`) REFERENCES `account` (`idaccount`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES (1,'R-2017-2018-GDECWWWU','SASA','SASA',10,'Non-Priority','FALSE','FALSE',10000.00,'Completed','','RESEL',4,3,'2017-12-06','SASA'),(2,'R-2017-2018-GTHYZBGM','ADMIN','Seminar-Workshop',12,'Non-Priority','FALSE','FALSE',20000.00,'Completed','','RESEL',4,3,'2018-01-22','ADMIN'),(3,'R-2017-2018-WLDBHOZD','ASAS','Seminar-Workshop',14,'Priority','FALSE','FALSE',40000.00,'Incoming','','RESEL',4,3,'2018-01-29','SDSAFF'),(4,'R-2017-2018-RAPJBQWC','DSFSDF','Seminar-Workshop',34,'Non-Priority','FALSE','FALSE',30000.00,'Incoming','','RESEL',4,3,'2018-01-29','TERTE');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_has_partner_agency`
--

DROP TABLE IF EXISTS `event_has_partner_agency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_has_partner_agency` (
  `idevent_has_partner_agency` int(11) NOT NULL AUTO_INCREMENT,
  `event_idevent` int(11) NOT NULL,
  `partner_agency_idpartner_agency` int(11) NOT NULL,
  PRIMARY KEY (`idevent_has_partner_agency`),
  KEY `fk_event_has_partner_agency_partner_agency1_idx` (`partner_agency_idpartner_agency`),
  KEY `fk_event_has_partner_agency_event1_idx` (`event_idevent`),
  CONSTRAINT `fk_event_has_partner_agency_event1` FOREIGN KEY (`event_idevent`) REFERENCES `event` (`idevent`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_event_has_partner_agency_partner_agency1` FOREIGN KEY (`partner_agency_idpartner_agency`) REFERENCES `partner_agency` (`idpartner_agency`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_has_partner_agency`
--

LOCK TABLES `event_has_partner_agency` WRITE;
/*!40000 ALTER TABLE `event_has_partner_agency` DISABLE KEYS */;
INSERT INTO `event_has_partner_agency` VALUES (1,1,6),(2,2,6),(3,3,6),(4,4,6);
/*!40000 ALTER TABLE `event_has_partner_agency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_has_schedule`
--

DROP TABLE IF EXISTS `event_has_schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_has_schedule` (
  `idevent_has_schedule` int(11) NOT NULL AUTO_INCREMENT,
  `event_idevent` int(11) NOT NULL,
  `schedule_idschedule` int(11) NOT NULL,
  `event_has_schedule_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idevent_has_schedule`),
  KEY `fk_event_has_schedule_schedule1_idx` (`schedule_idschedule`),
  KEY `fk_event_has_schedule_event1_idx` (`event_idevent`),
  CONSTRAINT `fk_event_has_schedule_event1` FOREIGN KEY (`event_idevent`) REFERENCES `event` (`idevent`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_event_has_schedule_schedule1` FOREIGN KEY (`schedule_idschedule`) REFERENCES `schedule` (`idschedule`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_has_schedule`
--

LOCK TABLES `event_has_schedule` WRITE;
/*!40000 ALTER TABLE `event_has_schedule` DISABLE KEYS */;
INSERT INTO `event_has_schedule` VALUES (1,1,1,''),(2,1,2,''),(3,1,3,''),(4,1,4,''),(5,1,5,''),(6,2,6,'Incoming'),(7,2,7,'Incoming'),(8,2,8,'Incoming'),(9,2,9,'Incoming'),(22,2,22,'Incoming'),(23,2,23,'Incoming'),(24,2,24,'Incoming'),(25,2,25,'Incoming'),(26,3,26,'Completed'),(27,4,27,'Incoming');
/*!40000 ALTER TABLE `event_has_schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_has_unit`
--

DROP TABLE IF EXISTS `event_has_unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_has_unit` (
  `idevent_has_unit` int(11) NOT NULL AUTO_INCREMENT,
  `event_idevent` int(11) DEFAULT NULL,
  `unit_idunit` int(11) DEFAULT NULL,
  PRIMARY KEY (`idevent_has_unit`),
  KEY `fk_event_has_unit_unit1_idx` (`unit_idunit`),
  KEY `fk_event_has_unit_event1_idx` (`event_idevent`),
  CONSTRAINT `fk_event_has_unit_event1` FOREIGN KEY (`event_idevent`) REFERENCES `event` (`idevent`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_event_has_unit_unit1` FOREIGN KEY (`unit_idunit`) REFERENCES `unit` (`idunit`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_has_unit`
--

LOCK TABLES `event_has_unit` WRITE;
/*!40000 ALTER TABLE `event_has_unit` DISABLE KEYS */;
INSERT INTO `event_has_unit` VALUES (1,1,6),(2,2,6),(3,3,6),(4,4,6);
/*!40000 ALTER TABLE `event_has_unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_history`
--

DROP TABLE IF EXISTS `event_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_history` (
  `idevent_history` int(11) NOT NULL AUTO_INCREMENT,
  `event_history_name` varchar(255) DEFAULT NULL,
  `event_history_reg_date` date DEFAULT NULL,
  `event_idevent` int(11) NOT NULL,
  PRIMARY KEY (`idevent_history`),
  KEY `fk_event_history_event1_idx` (`event_idevent`),
  CONSTRAINT `fk_event_history_event1` FOREIGN KEY (`event_idevent`) REFERENCES `event` (`idevent`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_history`
--

LOCK TABLES `event_history` WRITE;
/*!40000 ALTER TABLE `event_history` DISABLE KEYS */;
INSERT INTO `event_history` VALUES (1,'SASA is Incoming','2017-12-06',1),(2,'SASA is On-going','2017-12-06',1),(3,'SASA is On-going','2017-12-06',1),(4,'SASA is On-going','2017-12-06',1),(5,'SASA is On-going','2017-12-06',1),(6,'SASA is On-going','2017-12-06',1),(7,'SASA is Completed','2018-01-22',1),(8,'SASA is Completed','2018-01-22',1),(9,'SASA is Completed','2018-01-22',1),(10,'SASA is Completed','2018-01-22',1),(11,'SASA is Completed','2018-01-22',1),(12,'ADMIN is Incoming','2018-01-22',2),(13,'ADMIN is Approved','2018-01-22',2),(14,'ADMIN is Incoming','2018-01-22',2),(15,'ADMIN is Incoming','2018-01-22',2),(16,'ADMIN is Incoming','2018-01-22',2),(17,'ADMIN is On-going','2018-01-24',2),(18,'ADMIN is On-going','2018-01-24',2),(19,'ADMIN is On-going','2018-01-24',2),(20,'ADMIN is On-going','2018-01-24',2),(21,'ADMIN is On-going','2018-01-24',2),(22,'ADMIN is On-going','2018-01-24',2),(23,'ADMIN is On-going','2018-01-24',2),(24,'ADMIN is On-going','2018-01-24',2),(25,'ADMIN is Completed','2018-01-29',2),(26,'ADMIN is Completed','2018-01-29',2),(27,'ADMIN is Completed','2018-01-29',2),(28,'ADMIN is Completed','2018-01-29',2),(29,'ADMIN is Completed','2018-01-29',2),(30,'ADMIN is Completed','2018-01-29',2),(31,'ADMIN is Completed','2018-01-29',2),(32,'ADMIN is Completed','2018-01-29',2),(33,'ASAS is Incoming','2018-01-29',3),(34,'DSFSDF is Incoming','2018-01-29',4);
/*!40000 ALTER TABLE `event_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `holiday`
--

DROP TABLE IF EXISTS `holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `holiday` (
  `idholiday` int(11) NOT NULL AUTO_INCREMENT,
  `holiday_name` varchar(45) DEFAULT NULL,
  `holiday_type` varchar(45) DEFAULT NULL,
  `holiday_date` date DEFAULT NULL,
  `holiday_status` varchar(255) DEFAULT NULL,
  `holiday_reg_date` date DEFAULT NULL,
  `holiday_remove_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idholiday`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holiday`
--

LOCK TABLES `holiday` WRITE;
/*!40000 ALTER TABLE `holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `holiday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partner_agency`
--

DROP TABLE IF EXISTS `partner_agency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partner_agency` (
  `idpartner_agency` int(11) NOT NULL AUTO_INCREMENT,
  `partner_agency_name` varchar(255) DEFAULT NULL,
  `partner_agency_abbrev` varchar(255) DEFAULT NULL,
  `partner_agency_remove_status` varchar(45) DEFAULT NULL,
  `partner_agency_reg_date` date DEFAULT NULL,
  PRIMARY KEY (`idpartner_agency`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partner_agency`
--

LOCK TABLES `partner_agency` WRITE;
/*!40000 ALTER TABLE `partner_agency` DISABLE KEYS */;
INSERT INTO `partner_agency` VALUES (6,'Department f ScitTech','DOST','FALSE','2017-09-19');
/*!40000 ALTER TABLE `partner_agency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schedule` (
  `idschedule` int(11) NOT NULL AUTO_INCREMENT,
  `schedule_date` date DEFAULT NULL,
  `schedule_start_time` time DEFAULT NULL,
  `schedule_end_time` time DEFAULT NULL,
  `schedule_remove_status` varchar(255) DEFAULT NULL,
  `academic_year_idacademic_year` int(11) NOT NULL,
  PRIMARY KEY (`idschedule`),
  KEY `fk_schedule_academic_year1_idx` (`academic_year_idacademic_year`),
  CONSTRAINT `fk_schedule_academic_year1` FOREIGN KEY (`academic_year_idacademic_year`) REFERENCES `academic_year` (`idacademic_year`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (1,'2017-12-06','08:00:00','17:00:00','FALSE',4),(2,'2017-12-07','08:00:00','17:00:00','FALSE',4),(3,'2017-12-08','08:00:00','17:00:00','FALSE',4),(4,'2017-12-09','08:00:00','17:00:00','FALSE',4),(5,'2017-12-10','08:00:00','17:00:00','FALSE',4),(6,'2018-01-23','08:00:00','18:00:00','FALSE',4),(7,'2018-01-24','08:00:00','18:00:00','FALSE',4),(8,'2018-01-25','08:00:00','18:00:00','FALSE',4),(9,'2018-01-26','08:00:00','18:00:00','FALSE',4),(22,'2018-01-23','08:00:00','18:00:00','FALSE',4),(23,'2018-01-24','08:00:00','18:00:00','FALSE',4),(24,'2018-01-25','08:00:00','18:00:00','FALSE',4),(25,'2018-01-26','08:00:00','18:00:00','FALSE',4),(26,'2018-01-30','08:28:00','18:28:00','FALSE',4),(27,'2018-02-28','08:00:00','18:30:00','FALSE',4);
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unit` (
  `idunit` int(11) NOT NULL AUTO_INCREMENT,
  `unit_name` varchar(255) DEFAULT NULL COMMENT 'complete',
  `unit_abbrev` varchar(255) DEFAULT NULL COMMENT 'unit name shortcut',
  `unit_reg_date` date DEFAULT NULL,
  `unit_status` varchar(45) DEFAULT NULL,
  `unit_remove_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idunit`),
  FULLTEXT KEY `unit_name` (`unit_name`),
  FULLTEXT KEY `unit_abbrev` (`unit_abbrev`),
  FULLTEXT KEY `unit_status` (`unit_status`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (6,'Research, Extension Services and External Studies','RESEL','2017-09-18','Active','False');
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venue`
--

DROP TABLE IF EXISTS `venue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venue` (
  `idvenue` int(11) NOT NULL AUTO_INCREMENT,
  `venue_name` varchar(255) DEFAULT NULL,
  `venue_abbrev` varchar(255) DEFAULT NULL,
  `venue_reg_date` date DEFAULT NULL,
  `venue_remove_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idvenue`),
  UNIQUE KEY `venue_name_UNIQUE` (`venue_name`),
  UNIQUE KEY `venue_abbrev_UNIQUE` (`venue_abbrev`),
  FULLTEXT KEY `venue_name` (`venue_name`),
  FULLTEXT KEY `venue_abbrev` (`venue_abbrev`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venue`
--

LOCK TABLES `venue` WRITE;
/*!40000 ALTER TABLE `venue` DISABLE KEYS */;
INSERT INTO `venue` VALUES (1,'QWERTYUIP','QWERTY','2017-12-06','FALSE');
/*!40000 ALTER TABLE `venue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venue_has_schedule`
--

DROP TABLE IF EXISTS `venue_has_schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venue_has_schedule` (
  `idvenue_has_schedule` int(11) NOT NULL AUTO_INCREMENT,
  `venue_idvenue` int(11) NOT NULL,
  `schedule_idschedule` int(11) NOT NULL,
  `venue_has_schedule_reg_date` date DEFAULT NULL,
  PRIMARY KEY (`idvenue_has_schedule`),
  KEY `fk_venue_has_schedule_schedule1_idx` (`schedule_idschedule`),
  KEY `fk_venue_has_schedule_venue1_idx` (`venue_idvenue`),
  CONSTRAINT `fk_venue_has_schedule_schedule1` FOREIGN KEY (`schedule_idschedule`) REFERENCES `schedule` (`idschedule`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_venue_has_schedule_venue1` FOREIGN KEY (`venue_idvenue`) REFERENCES `venue` (`idvenue`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venue_has_schedule`
--

LOCK TABLES `venue_has_schedule` WRITE;
/*!40000 ALTER TABLE `venue_has_schedule` DISABLE KEYS */;
INSERT INTO `venue_has_schedule` VALUES (1,1,1,'2017-12-06'),(2,1,2,'2017-12-06'),(3,1,3,'2017-12-06'),(4,1,4,'2017-12-06'),(5,1,5,'2017-12-06'),(6,1,6,'2018-01-22'),(7,1,7,'2018-01-22'),(8,1,8,'2018-01-22'),(9,1,9,'2018-01-22'),(22,1,22,'2018-01-22'),(23,1,23,'2018-01-22'),(24,1,24,'2018-01-22'),(25,1,25,'2018-01-22'),(26,1,26,'2018-01-29'),(27,1,27,'2018-01-29');
/*!40000 ALTER TABLE `venue_has_schedule` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-27 23:22:07

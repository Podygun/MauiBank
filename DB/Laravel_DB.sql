CREATE DATABASE  IF NOT EXISTS `laravel` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `laravel`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: laravel
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bank_accounts`
--

DROP TABLE IF EXISTS `bank_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bank_accounts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `balance` double NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `valute_id` bigint unsigned DEFAULT NULL,
  `client_id` bigint unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bank_account_valute_idx` (`valute_id`),
  KEY `bank_account_client_idx` (`client_id`),
  CONSTRAINT `bank_account_client_fk` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`),
  CONSTRAINT `bank_account_valute_fk` FOREIGN KEY (`valute_id`) REFERENCES `valutes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank_accounts`
--

LOCK TABLES `bank_accounts` WRITE;
/*!40000 ALTER TABLE `bank_accounts` DISABLE KEYS */;
INSERT INTO `bank_accounts` VALUES (3,81800,NULL,1,3),(4,19200,NULL,2,3),(5,30000.21,NULL,1,4),(6,45000,NULL,2,4),(7,461934.12,NULL,1,5),(8,10444,NULL,2,5);
/*!40000 ALTER TABLE `bank_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `card_types`
--

DROP TABLE IF EXISTS `card_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `card_types` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(31) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card_types`
--

LOCK TABLES `card_types` WRITE;
/*!40000 ALTER TABLE `card_types` DISABLE KEYS */;
INSERT INTO `card_types` VALUES (1,'VISA',NULL),(2,'МИР',NULL);
/*!40000 ALTER TABLE `card_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cards`
--

DROP TABLE IF EXISTS `cards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cards` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `number` varchar(31) COLLATE utf8mb4_unicode_ci NOT NULL,
  `cvv` varchar(4) COLLATE utf8mb4_unicode_ci NOT NULL,
  `date_end` date NOT NULL,
  `card_type_id` bigint unsigned DEFAULT NULL,
  `bank_account_id` bigint unsigned DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `card_card_type_idx` (`card_type_id`),
  KEY `card_bank_account_idx` (`bank_account_id`),
  CONSTRAINT `card_bank_account_fk` FOREIGN KEY (`bank_account_id`) REFERENCES `bank_accounts` (`id`),
  CONSTRAINT `card_card_type_fk` FOREIGN KEY (`card_type_id`) REFERENCES `card_types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cards`
--

LOCK TABLES `cards` WRITE;
/*!40000 ALTER TABLE `cards` DISABLE KEYS */;
INSERT INTO `cards` VALUES (1,NULL,NULL,'from','835','2025-02-12',1,3,NULL),(2,NULL,NULL,'toto','187','2025-02-12',2,4,NULL),(3,NULL,NULL,'4960147628311721','322','2025-02-12',1,5,NULL),(4,NULL,NULL,'2200774009290713','836','2025-02-12',2,6,NULL),(5,NULL,NULL,'4960143267969226','133','2025-02-12',1,7,NULL),(6,NULL,NULL,'2200775124393688','741','2025-02-12',2,8,NULL),(7,'2023-02-18 05:19:52','2023-02-18 05:19:52','5555','555','2021-02-18',1,NULL,NULL);
/*!40000 ALTER TABLE `cards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `second_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `last_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `gender` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `user_account_id` bigint unsigned DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `client_user_account_idx` (`user_account_id`),
  CONSTRAINT `client_user_account_fk` FOREIGN KEY (`user_account_id`) REFERENCES `user_accounts` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (3,'Владислав','Подыганов','Иванович','test','vladpodyganov@yanndex.ru','89023262428',1,NULL,NULL,'2023-03-11 08:47:09'),(4,'влад','сидоров','владимирович','м',NULL,'89274362846',2,NULL,NULL,NULL),(5,'вася','петров','Михайлович','м',NULL,'+79022674871',3,NULL,NULL,NULL);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favours`
--

DROP TABLE IF EXISTS `favours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `favours` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `favour_id` bigint unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favours`
--

LOCK TABLES `favours` WRITE;
/*!40000 ALTER TABLE `favours` DISABLE KEYS */;
INSERT INTO `favours` VALUES (1,'Перевод на карту',NULL,NULL),(2,'Мобильная связь',NULL,NULL),(3,'Дом',NULL,NULL),(4,'Государство',NULL,NULL),(5,'Образование',NULL,NULL),(6,'Транспорт',NULL,NULL),(7,'Интернет',NULL,3),(8,'Газ',NULL,3),(9,'Электроэнергия',NULL,3),(10,'Налоги',NULL,3),(11,'Страхование',NULL,3),(12,'Суды',NULL,4),(13,'Госпошлины',NULL,4),(14,'Лицензии',NULL,4),(15,'Судебные приставы',NULL,4),(16,'Десткие сады',NULL,5),(17,'ВУЗы',NULL,5),(18,'Школы',NULL,5),(19,'Другие образовательные услуги',NULL,5),(20,'Штрафы ГИБДД',NULL,6),(21,'Гаражи и автостоянки',NULL,6),(22,'Парковка',NULL,6),(23,'Такси и каршеринг',NULL,6),(24,'Налоги',NULL,6),(25,'Эвакуация',NULL,6),(26,'Платные дороги',NULL,6),(27,'Вода',NULL,3),(28,'Расчетный счет',NULL,NULL),(29,'Горячая вода',NULL,27),(30,'Холодная вода',NULL,27);
/*!40000 ALTER TABLE `favours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `list_requisites`
--

DROP TABLE IF EXISTS `list_requisites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list_requisites` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `requisite_id` bigint unsigned DEFAULT NULL,
  `organisation_id` bigint unsigned DEFAULT NULL,
  `favour_id` bigint unsigned DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `list_requisite_idx` (`requisite_id`),
  KEY `list_organisation_idx` (`organisation_id`),
  KEY `list_favours_idx` (`favour_id`),
  CONSTRAINT `list_favours_fk` FOREIGN KEY (`favour_id`) REFERENCES `favours` (`id`),
  CONSTRAINT `list_organisation_fk` FOREIGN KEY (`organisation_id`) REFERENCES `organisations` (`id`),
  CONSTRAINT `list_requisite_fk` FOREIGN KEY (`requisite_id`) REFERENCES `requisites` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list_requisites`
--

LOCK TABLES `list_requisites` WRITE;
/*!40000 ALTER TABLE `list_requisites` DISABLE KEYS */;
INSERT INTO `list_requisites` VALUES (11,NULL,1,11,8),(13,NULL,4,4,2),(14,NULL,4,5,2),(15,NULL,4,6,2),(16,NULL,4,8,7),(17,NULL,4,9,7),(18,NULL,1,7,7),(19,NULL,1,1,1),(20,NULL,1,2,1),(21,NULL,1,3,1),(22,NULL,1,10,8),(23,NULL,2,12,29),(24,NULL,2,13,9),(25,NULL,9,1,1),(26,NULL,9,2,1),(27,NULL,9,3,1),(28,NULL,2,12,30);
/*!40000 ALTER TABLE `list_requisites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `migrations`
--

DROP TABLE IF EXISTS `migrations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `migrations` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `migrations`
--

LOCK TABLES `migrations` WRITE;
/*!40000 ALTER TABLE `migrations` DISABLE KEYS */;
INSERT INTO `migrations` VALUES (1,'2023_01_10_120233_create_card_types_table',1),(2,'2023_01_10_120425_create_user_accounts_table',1),(3,'2023_01_10_120500_create_valutes_table',1),(4,'2023_01_10_120630_create_clients_table',1),(5,'2023_01_10_120648_create_bank_accounts_table',1),(6,'2023_02_10_102503_create_cards_table',1),(7,'2023_02_10_121246_create_organisations_table',1),(8,'2023_02_10_121402_create_favours_table',1),(9,'2023_02_10_121559_create_requisites_table',1),(10,'2023_02_10_121641_create_list_requisites_table',1),(11,'2023_02_10_121850_create_pay_checks_table',1),(13,'2023_02_18_083601_add_columns_timestamps_to_clients_table',2),(16,'2023_03_03_132539_add_column_value_requisite_to_pay_checks_table',3),(21,'2023_03_08_104034_delete_column_list_requisites_id_to_pay_checks_table',4),(22,'2023_03_09_113131_add_column_favour_id_to_list_requisites_table',4),(23,'2023_03_15_150645_add_column_money_number_to_organisations_table',5);
/*!40000 ALTER TABLE `migrations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organisations`
--

DROP TABLE IF EXISTS `organisations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organisations` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `money_number` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `organisations_money_number_unique` (`money_number`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organisations`
--

LOCK TABLES `organisations` WRITE;
/*!40000 ALTER TABLE `organisations` DISABLE KEYS */;
INSERT INTO `organisations` VALUES (1,'MauiBank',NULL,'100001'),(2,'Сбер',NULL,'100002'),(3,'Альфа',NULL,'100003'),(4,'Теле2',NULL,'100004'),(5,'МТС',NULL,'100005'),(6,'Билайн',NULL,'100006'),(7,'Ростелеком',NULL,'100007'),(8,'Дом.ру',NULL,'100008'),(9,'Уфанет',NULL,'100009'),(10,'Газпром',NULL,'100010'),(11,'Амургаз',NULL,'100011'),(12,'Водоканал',NULL,'100012'),(13,'Мосэнергосбыт',NULL,'100013');
/*!40000 ALTER TABLE `organisations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pay_checks`
--

DROP TABLE IF EXISTS `pay_checks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pay_checks` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `sum` double NOT NULL,
  `fee` double NOT NULL DEFAULT '0',
  `deleted_at` timestamp NULL DEFAULT NULL,
  `bank_account_id` bigint unsigned DEFAULT NULL,
  `favour_id` bigint unsigned DEFAULT NULL,
  `requisite_value` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `check_bank_account_idx` (`bank_account_id`),
  KEY `check_favour_idx` (`favour_id`),
  CONSTRAINT `check_bank_account_fk` FOREIGN KEY (`bank_account_id`) REFERENCES `bank_accounts` (`id`),
  CONSTRAINT `check_favour_fk` FOREIGN KEY (`favour_id`) REFERENCES `favours` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pay_checks`
--

LOCK TABLES `pay_checks` WRITE;
/*!40000 ALTER TABLE `pay_checks` DISABLE KEYS */;
INSERT INTO `pay_checks` VALUES (1,NULL,NULL,1000,0,NULL,3,1,'2200771876922626'),(2,NULL,NULL,1000,0,NULL,3,1,'2200771876922626'),(3,NULL,NULL,100,0,NULL,3,1,'2200771876922626'),(4,NULL,NULL,100,0,NULL,3,1,'54321'),(5,NULL,NULL,1000,0,NULL,3,1,'65432'),(39,NULL,'2023-03-14 08:55:38',100,0,NULL,3,1,'toto'),(40,NULL,'2023-03-14 09:10:45',100,0,NULL,3,1,'toto'),(41,NULL,'2023-03-15 10:15:56',100,0,NULL,4,1,'toto'),(42,NULL,'2023-03-17 15:32:05',100,0,NULL,4,1,'toto'),(43,NULL,'2023-03-17 15:32:11',100,0,NULL,4,1,'toto');
/*!40000 ALTER TABLE `pay_checks` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `pay_checks_BEFORE_INSERT` BEFORE INSERT ON `pay_checks` FOR EACH ROW BEGIN

declare id_reciever_card int unsigned default 0;

IF new.favour_id = 1 THEN

    set id_reciever_card = (
		select cards.bank_account_id 
		from cards
		where cards.number = new.requisite_value);
    
	IF id_reciever_card != 0 THEN
		-- снятие денег
		update bank_accounts 
		set balance = balance - new.sum - new.fee
		where id = new.bank_account_id;

		-- приход денег
		update bank_accounts 
		set balance = balance + new.sum
		where (bank_accounts.id = id_reciever_card);
	END IF;
    
END IF;




END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `requisites`
--

DROP TABLE IF EXISTS `requisites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requisites` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requisites`
--

LOCK TABLES `requisites` WRITE;
/*!40000 ALTER TABLE `requisites` DISABLE KEYS */;
INSERT INTO `requisites` VALUES (1,'Лицевой счет',NULL),(2,'ИНН',NULL),(3,'КПП',NULL),(4,'Номер телефона',NULL),(5,'ФИО',NULL),(6,'УИН',NULL),(7,'СНИЛС',NULL),(8,'МОУ',NULL),(9,'Номер карты',NULL);
/*!40000 ALTER TABLE `requisites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_accounts`
--

DROP TABLE IF EXISTS `user_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_accounts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `login` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `salt` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_accounts`
--

LOCK TABLES `user_accounts` WRITE;
/*!40000 ALTER TABLE `user_accounts` DISABLE KEYS */;
INSERT INTO `user_accounts` VALUES (1,NULL,NULL,'1','1','1',NULL),(2,NULL,NULL,'2','2','2',NULL),(3,NULL,NULL,'3','3','3',NULL),(22,'2023-02-19 09:59:53','2023-02-19 09:59:53','test','test','test',NULL);
/*!40000 ALTER TABLE `user_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `valutes`
--

DROP TABLE IF EXISTS `valutes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `valutes` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(5) COLLATE utf8mb4_unicode_ci NOT NULL,
  `measure` int NOT NULL,
  `course` double NOT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `valutes`
--

LOCK TABLES `valutes` WRITE;
/*!40000 ALTER TABLE `valutes` DISABLE KEYS */;
INSERT INTO `valutes` VALUES (1,'RUB',1,1,NULL),(2,'USD',1,67.78,NULL);
/*!40000 ALTER TABLE `valutes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'laravel'
--

--
-- Dumping routines for database 'laravel'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-18 16:35:46

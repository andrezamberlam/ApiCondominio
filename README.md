# ApiCondominio




--################################### SCRIPT DB ###########################

CREATE DATABASE  IF NOT EXISTS `dbcondominios` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dbcondominios`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbcondominios
-- ------------------------------------------------------
-- Server version	8.0.17

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
-- Dumping data for table `apartamento`
--

LOCK TABLES `apartamento` WRITE;
/*!40000 ALTER TABLE `apartamento` DISABLE KEYS */;
INSERT INTO `apartamento` VALUES (21,44,'H');
/*!40000 ALTER TABLE `apartamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `apartamentopessoa`
--

LOCK TABLES `apartamentopessoa` WRITE;
/*!40000 ALTER TABLE `apartamentopessoa` DISABLE KEYS */;
INSERT INTO `apartamentopessoa` VALUES (21,25);
/*!40000 ALTER TABLE `apartamentopessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (25,'andre','2019-09-25','55 999354009','01814018000','email@teste.com'),(26,'asdasd','2019-09-18','888888888','018140180009','asdasdasd');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (26,'123@123','202cb962ac59075b964b07152d234b70'),(28,'qwe@qwe','5deb466b0e4c0c313bc6ac950d4247c4'),(29,'asd@asddddd','7815696ecbf1c96e6894b779456d330e'),(30,'asd@asdddddd','7815696ecbf1c96e6894b779456d330e'),(31,'asd@asd','202cb962ac59075b964b07152d234b70'),(32,'aaaa@aaaa','202cb962ac59075b964b07152d234b70'),(33,'aaa@bbb','194401b525555e3c08f287a14bfdd4e6'),(34,'ccc@ccc','f8b5d084bacca8413ef9f1b4542dcec0');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-25  2:42:24

-- MariaDB dump 10.19  Distrib 10.6.11-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: sudoku
-- ------------------------------------------------------
-- Server version	10.6.11-MariaDB-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

create schema `sudoku`;
use sudoku;
--
-- Table structure for table `grid`
--

DROP TABLE IF EXISTS `grid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grid` (
  `iGridCode` int(11) NOT NULL AUTO_INCREMENT,
  `sGrid` varchar(255) NOT NULL,
  `iCreatorCode` int(11) NOT NULL,
  `dCreatedAt` datetime(6) NOT NULL DEFAULT sysdate(),
  `iLevel` tinyint(3) NOT NULL,
  PRIMARY KEY (`iGridCode`),
  UNIQUE KEY `grid__grid__unique` (`sGrid`),
  UNIQUE KEY `grid__sGrid__unique` (`sGrid`),
  KEY `grid__creator` (`iCreatorCode`),
  CONSTRAINT `grid__creator` FOREIGN KEY (`iCreatorCode`) REFERENCES `user` (`iUserCode`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grid`
--

LOCK TABLES `grid` WRITE;
/*!40000 ALTER TABLE `grid` DISABLE KEYS */;
INSERT INTO `grid` VALUES (8,'1         2         3         4         5         6         7         8         9',21,'2023-05-11 14:48:24.000000',2),(9,'9         8         7         6         5         4         3         2         1',21,'2023-05-11 15:21:25.000000',0),(10,'        9       8       7       6       5       4       3       2       1        ',21,'2023-05-11 15:41:53.000000',0),(11,'1         2         4         5         6         7         3         8         9',21,'2023-05-11 15:42:33.000000',1),(12,'        1       9       8       7       6       5       4       3       2        ',21,'2023-05-11 15:42:49.000000',0),(13,'1         5         4         6         7         8         9         2         3',21,'2023-05-11 15:47:48.000000',0),(14,'12345678945678912378912345623456789156789123489123456734567891267891234591234567 ',21,'2023-05-15 14:09:14.000000',0),(15,'1         2         3         5         7         8         2         1         3',21,'2023-05-15 15:02:04.000000',0),(16,'1         2         3         1         2         3         1         2         3',21,'2023-05-15 15:03:24.000000',0);
/*!40000 ALTER TABLE `grid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `result`
--

DROP TABLE IF EXISTS `result`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `result` (
  `iResultCode` int(11) NOT NULL AUTO_INCREMENT,
  `dDateOfGame` date NOT NULL DEFAULT curdate(),
  `iUserCode` int(11) DEFAULT NULL,
  `iGridCode` int(11) NOT NULL,
  `iResolveTime` int(11) NOT NULL,
  PRIMARY KEY (`iResultCode`),
  KEY `result__gridCode__fk` (`iGridCode`),
  KEY `result__userCode__fk` (`iUserCode`),
  CONSTRAINT `result__gridCode__fk` FOREIGN KEY (`iGridCode`) REFERENCES `grid` (`iGridCode`),
  CONSTRAINT `result__userCode__fk` FOREIGN KEY (`iUserCode`) REFERENCES `user` (`iUserCode`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `result`
--

LOCK TABLES `result` WRITE;
/*!40000 ALTER TABLE `result` DISABLE KEYS */;
INSERT INTO `result` VALUES (1,'2023-05-22',21,14,150),(2,'2023-05-22',21,14,300),(3,'2023-05-24',22,14,13),(4,'2023-05-24',22,14,5),(5,'2023-05-24',23,14,3);
/*!40000 ALTER TABLE `result` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `iUserCode` int(11) NOT NULL AUTO_INCREMENT,
  `sNickname` varchar(63) NOT NULL,
  `sPassword` varchar(255) NOT NULL,
  PRIMARY KEY (`iUserCode`),
  UNIQUE KEY `user__nickname__unique` (`sNickname`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (21,'aym','b/8SD80lbZ2lGyN+O+ag/1c7I0GymUKMIEYFnMiIflJqnIUAUZsDQxoJ40hsslAw'),(22,'anonymous','ANONYMOUS'),(23,'aym3','YyKWRaX8AwgpAzg8c/WezRx5Wt3G3iFmrYdKn5I2bXANxStxLPEA98SYWALWd+2A');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-01 14:44:19

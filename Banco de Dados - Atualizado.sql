CREATE DATABASE  IF NOT EXISTS `dbnffacil` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dbnffacil`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: dbnffacil
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `caixa`
--

DROP TABLE IF EXISTS `caixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `caixa` (
  `codigoCaixa` varchar(10) NOT NULL,
  `HoraAbert` datetime DEFAULT NULL,
  `status` int DEFAULT NULL,
  `valorCaixa` double DEFAULT NULL,
  `HoraFechamento` datetime DEFAULT NULL,
  `ValorQuebra` double DEFAULT NULL,
  PRIMARY KEY (`codigoCaixa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caixa`
--

LOCK TABLES `caixa` WRITE;
/*!40000 ALTER TABLE `caixa` DISABLE KEYS */;
/*!40000 ALTER TABLE `caixa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fluxo`
--

DROP TABLE IF EXISTS `fluxo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fluxo` (
  `idFluxo` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `tipo` int DEFAULT NULL,
  `horario` datetime DEFAULT NULL,
  `data` datetime DEFAULT NULL,
  `fk_Caixa_codigoCaixa` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idFluxo`),
  KEY `FK_Fluxo_2` (`fk_Caixa_codigoCaixa`),
  CONSTRAINT `FK_Fluxo_2` FOREIGN KEY (`fk_Caixa_codigoCaixa`) REFERENCES `caixa` (`codigoCaixa`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fluxo`
--

LOCK TABLES `fluxo` WRITE;
/*!40000 ALTER TABLE `fluxo` DISABLE KEYS */;
/*!40000 ALTER TABLE `fluxo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingrediente`
--

DROP TABLE IF EXISTS `ingrediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingrediente` (
  `qtde` decimal(10,0) DEFAULT NULL,
  `idIngrediente` int NOT NULL AUTO_INCREMENT,
  `fk_Receita_idReceita` varchar(10) DEFAULT NULL,
  `fk_Produto_idProduto` int DEFAULT NULL,
  PRIMARY KEY (`idIngrediente`),
  KEY `FK_Ingrediente_3` (`fk_Produto_idProduto`),
  KEY `FK_Ingrediente_2` (`fk_Receita_idReceita`),
  CONSTRAINT `FK_Ingrediente_2` FOREIGN KEY (`fk_Receita_idReceita`) REFERENCES `receita` (`idReceita`) ON DELETE CASCADE,
  CONSTRAINT `FK_Ingrediente_3` FOREIGN KEY (`fk_Produto_idProduto`) REFERENCES `produto` (`idProduto`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingrediente`
--

LOCK TABLES `ingrediente` WRITE;
/*!40000 ALTER TABLE `ingrediente` DISABLE KEYS */;
INSERT INTO `ingrediente` VALUES (500,1,'RE7767',2),(234,5,'RE7577',5),(567,6,'RE4969',2),(120,13,'RE1135',3),(456,14,'RE1135',2),(120,17,'RE1759',3);
/*!40000 ALTER TABLE `ingrediente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamento` (
  `idPagamento` int NOT NULL AUTO_INCREMENT,
  `tipoPagamento` int DEFAULT NULL,
  `valorPagamento` double DEFAULT NULL,
  `fk_Pedido_codigoPedido` varchar(10) DEFAULT NULL,
  `fk_Caixa_codigoCaixa` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idPagamento`),
  KEY `FK_Pagamento_2` (`fk_Pedido_codigoPedido`),
  KEY `FK_Pagamento_3` (`fk_Caixa_codigoCaixa`),
  CONSTRAINT `FK_Pagamento_2` FOREIGN KEY (`fk_Pedido_codigoPedido`) REFERENCES `pedido` (`codigoPedido`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Pagamento_3` FOREIGN KEY (`fk_Caixa_codigoCaixa`) REFERENCES `caixa` (`codigoCaixa`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamento`
--

LOCK TABLES `pagamento` WRITE;
/*!40000 ALTER TABLE `pagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedido` (
  `codigoPedido` varchar(10) NOT NULL,
  `dataPedido` datetime DEFAULT NULL,
  `statusPedido` int DEFAULT NULL,
  `PrazoEntrega` datetime DEFAULT NULL,
  `desconto` double DEFAULT NULL,
  `dataFechamento` datetime DEFAULT NULL,
  `nomeCliente` varchar(100) DEFAULT NULL,
  `whatsApp` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codigoPedido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido`
--

LOCK TABLES `pedido` WRITE;
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produto` (
  `idProduto` int NOT NULL AUTO_INCREMENT,
  `PrecoEmbalagem` double DEFAULT NULL,
  `ConteudoEmbalagem` double DEFAULT NULL,
  `UN` int DEFAULT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idProduto`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES (2,10,350,6,'FERMENTO'),(3,12.5,100,8,'LEITE CONDESADO'),(5,10,450,6,'AÇUCAR');
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receita`
--

DROP TABLE IF EXISTS `receita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `receita` (
  `idReceita` varchar(10) NOT NULL,
  `data` datetime DEFAULT NULL,
  `MargemLucro` double DEFAULT NULL,
  `ValorMaoObra` double DEFAULT NULL,
  `validade` varchar(255) DEFAULT NULL,
  `descricaoReceita` varchar(255) DEFAULT NULL,
  `Rendimento` varchar(255) DEFAULT NULL,
  `gastosgerais` double DEFAULT NULL,
  PRIMARY KEY (`idReceita`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receita`
--

LOCK TABLES `receita` WRITE;
/*!40000 ALTER TABLE `receita` DISABLE KEYS */;
INSERT INTO `receita` VALUES ('RE1135','2023-10-18 22:11:17',5,15,'2 DIAS NA GELADEIRA','VXZVXV','NÃO INFORMADO !',0),('RE1759','2023-10-18 21:20:46',10,10,'não Informado !','BOLO MONTANHA AZUL','2 dias',5.5),('RE2114','2023-10-18 21:23:33',23,12,'','XXXXXX','2 dias',12),('RE4969','2023-10-18 21:35:04',10,0,'','DFFSAFSAF','2 dias',12),('RE7577','2023-10-18 21:33:24',10,12,'','YYYYYY','2 dias',12),('RE7767','2023-10-18 21:18:56',10,23,'','BOLO DE PINHA','2 dias',12);
/*!40000 ALTER TABLE `receita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda` (
  `fk_Receita_idReceita` varchar(10) DEFAULT NULL,
  `fk_Pedido_codigoPedido` varchar(10) DEFAULT NULL,
  `qtde` int DEFAULT NULL,
  KEY `FK_Venda_1` (`fk_Receita_idReceita`),
  KEY `FK_Venda_2` (`fk_Pedido_codigoPedido`),
  CONSTRAINT `FK_Venda_1` FOREIGN KEY (`fk_Receita_idReceita`) REFERENCES `receita` (`idReceita`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Venda_2` FOREIGN KEY (`fk_Pedido_codigoPedido`) REFERENCES `pedido` (`codigoPedido`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda`
--

LOCK TABLES `venda` WRITE;
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-20  8:53:07

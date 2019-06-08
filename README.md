# MirumDDD
Sistema de testes usando a arquitetura DDD em .Net CORE 2.1, testes unitários com Moq e xUnit.

Mirum DB:
CREATE DATABASE Mirum
GO

USE Mirum
GO

CREATE TABLE Cargo
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(255),
	SalarioBase decimal(10,2)
)
GO

CREATE TABLE Pessoa
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(255),
	RG VARCHAR(15),
	Email VARCHAR(255),
	CargoId INT	CONSTRAINT FK_Cargo FOREIGN KEY (CargoId) REFERENCES Cargo(Id)
)
GO

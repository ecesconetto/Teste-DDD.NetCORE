# MirumDDD
Teste para a empresa Mirum usando a arquitetura DDD.

Mirum DB:
CREATE DATABASE Mirum
GO

USE Mirum
GO

CREATE TABLE Cargo
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(255),
	SalarioBase decimal(14,2),
	Email VARCHAR(255)
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
-- 1. CRIAR A BASE DE DADOS DE VENDAS
CREATE DATABASE BD_Vendas;

USE BD_Vendas;

-- 2. CRIAR AS TABELAS (NA ORDEM CORRETA DE DEPENDÊNCIA)
-- A) Tabela de Produtos (Não depende de nenhuma)
CREATE TABLE Produtos (
    ProdutoID INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);
-- B) Tabela de Clientes (Não depende de nenhuma)
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20),
    BI VARCHAR(20) UNIQUE -- Número de Identificação Fiscal
);
-- C) Tabela de Vendas (Depende da tabela Clientes, por isso é criada depois)
CREATE TABLE Vendas (
    VendaID INT PRIMARY KEY IDENTITY(1,1),
    DataVenda DATETIME DEFAULT GETDATE(),
    Utilizador VARCHAR(50) NOT NULL,
	ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID), -- Ligação com o Cliente
    Total DECIMAL(10,2) DEFAULT 0
);
-- D) Tabela de ItensVenda (Depende de Vendas e de Produtos)

CREATE TABLE ItensVenda (
    ItemID INT PRIMARY KEY IDENTITY(1,1),
    VendaID INT FOREIGN KEY REFERENCES Vendas(VendaID),
    ProdutoID INT FOREIGN KEY REFERENCES Produtos(ProdutoID),
    Quantidade INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL
);
select *from produtos;
select *from Clientes;
select *from Vendas;
select *from ItensVenda;

-- 3. INSERIR ALGUNS PRODUTOS PARA TESTE
INSERT INTO Produtos (Nome, Preco, Stock) VALUES 
('Teclado Mecânico', 25000.00, 15),
('Rato Gamer', 18000.00, 20),
('Monitor 24 Pol', 120000.00, 8),
('Auscultadores HyperX', 35000.00, 12);

-- 2. Inserir alguns clientes de teste
INSERT INTO Clientes (Nome, Telefone, BI) VALUES 
('Teodora Miguel', '929204334', '008468696UE055'),
('Manuel Tolentino', '931111111', '540789101'),
('Fernando Carlos', '945222222', '540111213');

-- ============================================
-- 4. CRIAR OS UTILIZADORES (LOGINS NO SERVIDOR)
-- Nota: Executa esta parte na base de dados 'master'
-- =============================================
USE master;

ALTER LOGIN Tolentino4 WITH PASSWORD = 'Tolentino1234', CHECK_POLICY = OFF;
ALTER LOGIN Tolentino4 ENABLE;

-- Garantir as senhas corretas dos outros membros
ALTER LOGIN Cardoso1  WITH PASSWORD = 'Cardoso1234',  CHECK_POLICY = OFF;
ALTER LOGIN Fernando2 WITH PASSWORD = 'Fernando1234', CHECK_POLICY = OFF;
ALTER LOGIN Makuiza3  WITH PASSWORD = 'Makuiza1234',  CHECK_POLICY = OFF;
ALTER LOGIN TeodoraG  WITH PASSWORD = 'TeodoraG1234', CHECK_POLICY = OFF;

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'concilig')
  BEGIN
    CREATE DATABASE [concilig]


    END;
use concilig;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='compras' and xtype='U')
BEGIN
CREATE TABLE Compras (
    nome   varchar(255),
    cpf varchar(255) not null,
	contrato varchar(255),
    produto varchar(255),
    vencimento varchar(255),
    valor decimal(20,2)
)
END;

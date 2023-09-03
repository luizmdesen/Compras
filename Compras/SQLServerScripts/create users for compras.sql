USE [master]
GO
CREATE LOGIN [usuario] WITH PASSWORD=N'123', DEFAULT_DATABASE=[concilig]
GO
USE [concilig]
GO
CREATE USER [usuario] FOR LOGIN [usuario]
GO
GRANT SELECT, INSERT ON OBJECT::dbo.compras TO usuario;
GO


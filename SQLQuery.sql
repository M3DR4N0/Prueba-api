CREATE DATABASE Prueba;
GO

USE Prueba;
GO

CREATE TABLE [PermissionType](
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[description] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Permission](
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[emp_name] VARCHAR(50) NOT NULL,
[emp_last_name] VARCHAR(50) NOT NULL,
[p_type] INT NOT NULL,
[p_date] DATE NOT NULL,
CONSTRAINT FK_Permission_type_id FOREIGN KEY ([p_type]) REFERENCES [PermissionType]([Id])
);
GO

INSERT INTO [PermissionType] VALUES ('Enfermedad');
INSERT INTO [PermissionType] VALUES ('Diligencias');
INSERT INTO [PermissionType] VALUES ('Paternidad');
GO

Drop table [Permission];

/*
USE master;
GO
DROP DATABASE Prueba;
GO
*/
USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Criação da tabela Login.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'Login'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  já executado!');
	RETURN;
END

--INICIO DO 

CREATE TABLE Login(
	LoginId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Email NVARCHAR(40) NOT NULL,
	Admin BIT NOT NULL,
    Ativo BIT NOT NULL,
	Senha NVARCHAR(40) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
	DataNascimento DATE NOT NULL,
    DataInclusao DATE NOT NULL,
	Nome VARCHAR(40) NOT NULL
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');


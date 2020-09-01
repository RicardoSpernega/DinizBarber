USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Criação da tabela Horario.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'Horario'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  já executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE Horario(
	HorarioId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Dia DATE NOT NULL,
	HorarioInicio NVARCHAR(10),
	HorarioFim NVARCHAR(10)
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');


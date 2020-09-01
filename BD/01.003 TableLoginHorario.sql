USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Criação da tabela LoginHorario.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'LoginHorario'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  já executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE LoginHorario(
	LoginHorario INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	LoginId INT NOT NULL,
	HorarioId INT NOT NULL,
	CONSTRAINT FK_LoginId FOREIGN KEY (LoginId) REFERENCES Login (LoginId),
	CONSTRAINT FK_HorarioId FOREIGN KEY (HorarioId) REFERENCES Horario (HorarioId)
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');


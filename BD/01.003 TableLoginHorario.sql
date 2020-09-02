USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Cria��o da tabela LoginHorario.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'LoginHorario'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  j� executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE LoginHorario(
	LoginId INT NOT NULL,
	HorarioId INT NOT NULL,
	PRIMARY KEY(LoginId, HorarioId)
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');





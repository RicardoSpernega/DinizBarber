USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Criação da tabela DiaHorarioAceite.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'DiaHorarioAceite'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  já executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE DiaHorarioAceite(
	DiaHorarioAceiteId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	LoginId INT NULL,
	DiaId INT NOT NULL,
	HorarioInicio VARCHAR(5) NOT NULL,
	HorarioFim VARCHAR(5) NOT NULL,
	TipoStatusHorarioId INT NOT NULL,
	DtInclusao DATETIME NOT NULL,
	DtAceite DATETIME NULL,
	CONSTRAINT FK_LoginId FOREIGN KEY (LoginId) REFERENCES Login (LoginId),
	CONSTRAINT FK_TipoStatusAceiteId FOREIGN KEY (TipoStatusHorarioId) REFERENCES TipoStatusHorario (TipoStatusHorarioId),
	CONSTRAINT FK_DiaId FOREIGN KEY (DiaId) REFERENCES Dia (DiaId)
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');



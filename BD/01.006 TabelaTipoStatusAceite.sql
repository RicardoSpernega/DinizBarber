USE [diniz]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Cria��o da tabela TipoStatusHorario.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'TipoStatusHorario'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  j� executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE TipoStatusHorario(
	TipoStatusHorarioId INT PRIMARY KEY NOT NULL,
	Descricao NVARCHAR(50) NOT NULL
)
INSERT INTO TipoStatusHorario (TipoStatusHorarioId,Descricao)
			VALUES			 (1,'Pendente'),
							 (2,'Reservado'),
							 (3,'Cancelado'),
							 (4,'Disponivel')
							 
--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');

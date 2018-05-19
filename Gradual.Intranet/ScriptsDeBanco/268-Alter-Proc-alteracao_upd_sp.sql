--Descrição: Altera registro na tabela tb_alteracao.
--Autor: Gustavo Malta Guimarães
--Data de criação: 19/07/2010
ALTER PROCEDURE [dbo].[alteracao_upd_sp]
( @id_alteracao	int
, @id_login int)
AS
UPDATE [dbo].[tb_alteracao]
SET    [dt_realizacao] = GETDATE()
,      [id_login]      = @id_login
WHERE  [id_alteracao]  = @id_alteracao
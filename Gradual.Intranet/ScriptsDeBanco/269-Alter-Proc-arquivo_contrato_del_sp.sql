ALTER PROCEDURE [dbo].[arquivo_contrato_del_sp] (@id_ArquivoContrato int)
AS
BEGIN
	DELETE FROM [dbo].[tb_arquivo_contrato]
    WHERE [id_ArquivoContrato] = @id_ArquivoContrato
END
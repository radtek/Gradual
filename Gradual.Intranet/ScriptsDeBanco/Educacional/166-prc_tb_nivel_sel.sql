CREATE PROCEDURE [prc_tb_nivel_sel] (@id_nivel INT)
AS
   SELECT * FROM [dbo].[tb_nivel] WHERE [tb_nivel].[id_nivel] = @id_nivel
 
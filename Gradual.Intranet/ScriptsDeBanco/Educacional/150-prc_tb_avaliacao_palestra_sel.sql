set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER  PROCEDURE [dbo].[prc_tb_avaliacao_palestra_sel] (@id_avaliacaoPalestra  INT)
AS
   SELECT [apa].[id_avaliacaopalestra]
   ,      [apa].[ds_avaliapalestrante]
   ,      [apa].[ds_material]
   ,      [apa].[ds_infraestrutura]
   ,      [apa].[ds_expectativa]
   ,      [apa].[dt_avaliacao]
   FROM   [educacional].[dbo].[tb_avaliacao_palestra] AS [apa]
   WHERE  [apa].[id_avaliacaopalestra] = @id_avaliacaoPalestra


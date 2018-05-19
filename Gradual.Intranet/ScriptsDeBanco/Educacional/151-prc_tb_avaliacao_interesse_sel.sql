set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[prc_tb_avaliacao_interesse_sel] (@id_avaliacaoInteresse INT)
AS
  SELECT  [avi].[ds_avaliacaointeresse]
  FROM    [educacional].[dbo].[tb_avaliacao_interesse] AS [avi]
  WHERE   [avi].[id_avaliacaointeresse] =  @id_avaliacaoInteresse;

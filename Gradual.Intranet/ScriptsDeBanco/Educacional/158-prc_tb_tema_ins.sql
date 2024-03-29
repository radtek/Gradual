set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[prc_tb_tema_ins]
( @id_tema     INT OUTPUT
, @id_nivel    INT
, @ds_titulo   VARCHAR(200)
, @ds_chamada  VARCHAR(500)
, @st_situacao CHAR(1))
AS
   INSERT INTO [dbo].[tb_tema]
          (    [tb_tema].[id_nivel]
          ,    [tb_tema].[ds_titulo]
          ,    [tb_tema].[ds_chamada]
          ,    [tb_tema].[st_situacao])
   VALUES (    @id_nivel
          ,    @ds_titulo
          ,    @ds_chamada
          ,    @st_situacao)

   SELECT @id_tema = SCOPE_IDENTITY()


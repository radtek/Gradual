set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROCEDURE [dbo].[prc_tb_perfil_ins] (@ds_perfil VARCHAR(50))
AS
    INSERT INTO [dbo].[tb_perfil] VALUES (@ds_perfil)

   SELECT SCOPE_IDENTITY()

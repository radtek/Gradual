CREATE PROCEDURE [dbo].[paises_blacklist_upd_sp]
	  @id_pais_blacklist bigint
	, @cd_pais           varchar(3)
AS
/*
DESCRIÇÃO:
	Atualiza registro(s) na tabela tb_paises_blacklist.
CRIAÇÃO:
	Desenvolvedor: Antônio Rodrigues
	Data: 29/04/2010
*/
UPDATE [dbo].[tb_paises_blacklist]
SET    [cd_pais]           = @cd_pais
WHERE  [id_pais_blacklist] = @id_pais_blacklist
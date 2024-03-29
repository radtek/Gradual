set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

--Descrição: Atualiza registro(s) na tabela tb_cliente_pendenciacadastral.
--Autor: Bruno Varandas Ribeiro
--Data de criação: 30/04/2010

--Descrição: Verificando o login do usuário que resolveu.
--Autor: Gustavo Malta Guimarães
--Data de criação: 29/10/2010

ALTER PROCEDURE [dbo].[cliente_pendenciacadastral_upd_sp]
	@id_pendencia_cadastral int,
	@id_tipo_pendencia int,
	@id_cliente int,
	@ds_pendencia varchar(1000),
	@dt_resolucao datetime,
	@ds_resolucao varchar(200),
	@id_login int
AS
UPDATE tb_cliente_pendenciacadastral
SET 
	[id_tipo_pendencia] = @id_tipo_pendencia,
	[id_cliente] = @id_cliente,
	[ds_pendencia] = @ds_pendencia,
	[dt_resolucao] = @dt_resolucao,
	[ds_resolucao] = @ds_resolucao,
	[id_login] = @id_login
WHERE
	[id_pendencia_cadastral] = @id_pendencia_cadastral





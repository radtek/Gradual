--Descrição: Pega a informação relação à ativação na cliger
--Autor: Gustavo Malta Guimarães
--Data de criação: 28/09/2010
CREATE PROCEDURE [dbo].[cliente_ativo_cliger_sel_sp]
	@id_cliente	int
AS
SELECT st_ativo_cliger
  FROM tb_cliente
where id_cliente = @id_cliente;




--Descrição: Salva a informação relação à ativação na cliger
--Autor: Gustavo Malta Guimarães
--Data de criação: 28/09/2010
CREATE PROCEDURE [dbo].[cliente_ativo_cliger_upd_sp]
	@id_cliente	int,
	@st_ativo_cliger bit
AS
	UPDATE tb_cliente
	SET st_ativo_cliger = @st_ativo_cliger
	where id_cliente = @id_cliente;
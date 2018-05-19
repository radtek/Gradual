--Descri��o: Seleciona os dados da tabela tb_cliente_controladora de acordo com o filtro especificado.
--Autor: Bruno Varandas Ribeiro
--Data de cria��o: 29/04/2010
CREATE PROCEDURE cliente_controladora_lst_sp
	@id_cliente bigint
AS
SELECT
	[id_cliente_controlada],
	[id_cliente],
	[ds_nomerazaosocial],
	[ds_cpfcnpj]
FROM tb_cliente_controladora
WHERE [id_cliente] = @id_cliente
ORDER BY 
	[id_cliente_controlada] ASC
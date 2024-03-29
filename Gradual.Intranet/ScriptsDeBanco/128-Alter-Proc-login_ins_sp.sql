set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

--Alteração:   Inserir campos tp_acesso e cd_assessor, e retirar campo ds_login
--Realizada por: Gustavo
--Data da Alteração: 08/06/2010

--Alteração:   Inserir campo ds_nome para o controle de acesso
--Realizada por: Gustavo
--Data da Alteração: 09/06/2010

ALTER PROCEDURE [dbo].[login_ins_sp]
                 @cd_senha                varchar(32)
               , @cd_assinaturaeletronica varchar(32)
               , @nr_tentativaserradas    numeric(2, 0)
               , @id_frase                int
               , @ds_respostafrase        varchar(100)
               , @dt_ultimaexpiracao      datetime
               , @ds_email                varchar(80)
				,@tp_acesso               int
				,@cd_assessor             numeric(5,0)
				,@ds_nome                 varchar(60)
				,@id_login                int OUTPUT
AS
    INSERT INTO tb_login
           (    cd_senha
           ,    cd_assinaturaeletronica
           ,    nr_tentativaserradas
           ,    id_frase
           ,    ds_respostafrase
           ,    dt_ultimaexpiracao
           ,    tp_acesso               
			,	cd_assessor  
			,   ds_nome
           ,    ds_email)
    VALUES (    @cd_senha
           ,    @cd_assinaturaeletronica
           ,    @nr_tentativaserradas
           ,    @id_frase
           ,    @ds_respostafrase
           ,    @dt_ultimaexpiracao
           ,    @tp_acesso               
			,	@cd_assessor 
			,	@ds_nome
           ,    @ds_email)
SELECT @id_login =  SCOPE_IDENTITY()






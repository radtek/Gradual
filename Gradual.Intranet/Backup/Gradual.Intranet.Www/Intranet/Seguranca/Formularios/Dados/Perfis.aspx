﻿<%@ Page Language="C#" enableviewstate="false" AutoEventWireup="true" CodeBehind="Perfis.aspx.cs" Inherits="Gradual.Intranet.Www.Intranet.Seguranca.Formularios.Dados.Perfis" %>


<form id="form1" runat="server">

    <h4>Perfis</h4>

    <h5>Perfis Cadastrados:</h5>

    <table class="Lista" cellspacing="0">

        <thead>
            <tr>
                <td>Perfil</td>
                <td>Restrição</td>
                <td>Ações</td>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="3">
                    <a href="#" onclick="return GradIntra_Cadastro_NovoItemFilho(this)" class="Novo">Novo Perfil</a>
                </td>
            </tr>
        </tfoot>

        <tbody>
            <tr class="Nenhuma">
                <td colspan="3">Nenhuma Perfil Cadastrado</td>
            </tr>
            <tr class="Template" style="display:none">
                <td style="width:1px;">
                    <input type="hidden" Propriedade="json" />
                </td>
                <td style="width:84%" Propriedade="Resumo()"></td>
                <td>
                    <button class="IconButton Excluir" onclick="return GradIntra_Cadastro_ExcluirItemFilho('Seguranca/Formularios/Dados/Perfis.aspx', this)"><span>Excluir</span></button>
                </td>
            </tr>
        </tbody>
        
    </table>

    <div  id="pnlSeguranca_Perfis_Campos" class="pnlFormulario_Campos" style="display:none">

        <input type="hidden" id="hidSeguranca_Perfis_ListaJson" class="ListaJson" runat="server" value="" />

        <input type="hidden" id="txtSeguranca_Perfis_Id" Propriedade="Id" />
        <input type="hidden" id="txtSeguranca_Perfis_ParentId" Propriedade="ParentId" />

        <p class="Menor1">
            <label for="cboSeguranca_Perfis_Perfil">Perfil:</label>
            <select id="cboSeguranca_Perfis_Perfil" Propriedade="Item" class="validate[required]" style="width:20.6em">
                 <option value="">[ Selecione ]</option>
                 <asp:repeater runat="server" id="rptSeguranca_Perfis_Perfil">
                    <ItemTemplate>
                        <option value='<%# Eval("CodigoPerfil") %>'><%# Eval("NomePerfil")%></option>
                    </ItemTemplate>
                </asp:repeater>
            </select>
        </p>
        
        <p class="BotoesSubmit">
            
            <button id="btnSeguranca_Perfis_Salvar" onclick="return btnSeguranca_Perfis_Salvar_Click(this)">Salvar Alterações</button>
            
        </p>
        
    </div>

</form>
<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/adminMaster.Master" AutoEventWireup="true" CodeBehind="genero.aspx.cs" Inherits="rpgASP.webForms.genero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .divForm {
            width: 30%;
            margin: 3%;
            float: left;
            border-right: solid 1px black;
            height: 200px;
        }
        .titulo{
            font-size: 16px;
            font-weight: bold;
            text-align: center;
        }
        .divGrid{
            margin: 3%;
            float: left;
            width: 30%;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titulo"> Cadastro de Gênero de Jogo </h1>
    <div class="divForm">
        <div class="form-group" style="margin-top: 5px;">
            <label for="descricao">Descrição:</label>
            <asp:TextBox ID="txtDescricao" CssClass="form-control" runat="server" style="width:90%" MaxLength="30"></asp:TextBox>
        </div>
        <asp:Button ID="btnGravar" runat="server" Text="Inserir" OnClick="txtGravar_Click" CssClass="btn btn-primary"/>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click"/>

    </div>
    <div class="divGrid">
        <h3 >Lista de Gêneros</h3>
        <asp:ListBox ID="lsbGeneros" runat="server" CssClass="table" DataSourceID="sqlGenero" DataTextField="descricao" DataValueField="id"></asp:ListBox>
        <asp:Button ID="btnSelecionar" runat="server" Text="Selecionar" CssClass="btn btn-primary" OnClick="btnSelecionar_Click" />
        <asp:Button ID="btnRemover" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="btnRemover_Click" />
        <asp:SqlDataSource ID="sqlGenero" runat="server" ConnectionString="<%$ ConnectionStrings:sRpgConnectionString %>" SelectCommand="SELECT * FROM [genero]"></asp:SqlDataSource>
    </div>

</asp:Content>

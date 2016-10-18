<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/geralMaster.Master" AutoEventWireup="true" CodeBehind="loja.aspx.cs" Inherits="rpgASP.webForms.loja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Jogos a venda!</h1>
    <asp:GridView ID="gdvLoja" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlLoja" OnRowCommand="gdvLoja_RowCommand" OnSelectedIndexChanged="gdvLoja_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            <asp:BoundField DataField="valor" HeaderText="valor" SortExpression="valor" />
            <asp:BoundField DataField="idGenero" HeaderText="idGenero" SortExpression="idGenero" />
            <asp:ButtonField Text="Adicionar ao Carrinho" />
        </Columns>
    </asp:GridView>
    <br />
    <h1>
        Você possui um total de <asp:Label ID="lblCarteira" runat="server" Text=""> na carteira</asp:Label>
    </h1>
    <br />
    <h1>Carrinho de Compras: </h1>
    <asp:GridView ID="gdvCarrinho" runat="server" CssClass="table table-hover table-striped"></asp:GridView>
    <h1>
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
    </h1>
    <asp:Button ID="btnFinalizar" runat="server" CssClass="btn btn-primary" Text="Finalizar Venda" OnClick="btnFinalizar_Click" />
    <asp:SqlDataSource ID="sqlLoja" runat="server" ConnectionString="<%$ ConnectionStrings:sRpgConnectionString %>" SelectCommand="SELECT [id], [nome], [valor], [idGenero] FROM [Jogos]"></asp:SqlDataSource>
</asp:Content>

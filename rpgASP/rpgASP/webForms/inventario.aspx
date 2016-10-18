<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/geralMaster.Master" AutoEventWireup="true" CodeBehind="inventario.aspx.cs" Inherits="rpgASP.webForms.inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Lista de Jogos do Usuário</h1>
    <asp:gridview  runat="server" CssClass="table table-hover table-striped" ID="gdvJogos"></asp:gridview>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/geralMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="rpgASP.webForms.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1>
            <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblSaldo" runat="server" Text=""></asp:Label>
            <br />
        </h1>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/geralMaster.Master" AutoEventWireup="true" CodeBehind="crediar.aspx.cs" Inherits="rpgASP.webForms.crediar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="form-group" style="margin: 2%;">
        <h1 style="text-align:center;"> Operação de Credito</h1>
        <label> Digite a quantia que deseja Creditar na Conta:</label>
        <div class="input-group">
            <div class="input-group-addon">R$</div>            
            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" Style="width: 20%; margin-right: 2%"> </asp:TextBox>
            <asp:Button ID="btnDepositar" runat="server" CssClass="btn btn-primary" Text="Depositar" OnClick="btnDepositar_Click" />
        </div>
        <asp:Label ID="lblSaldo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

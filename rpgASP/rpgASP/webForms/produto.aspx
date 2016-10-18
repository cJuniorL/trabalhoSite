<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/adminMaster.Master" AutoEventWireup="true" CodeBehind="produto.aspx.cs" Inherits="rpgASP.webForms.produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titulo {
            font-size: 26px;
            font-weight: bold;
            text-align: center;
        }

        .cadastro {
            width: 40%;
            margin-left: 15%;
            margin-top: 3%;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".selectpicker").selectpicker();

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titulo">Cadastro de Jogos</h1>
    <div class="cadastro">
        <div class="form-group">
            <label for="nome">Nome </label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" Style="width: 85%"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="nome">Genero </label>
            <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control" Style="width: 85%;" DataSourceID="sqlGenero" DataTextField="descricao" DataValueField="id"></asp:DropDownList>
            <asp:SqlDataSource ID="sqlGenero" runat="server" ConnectionString="<%$ ConnectionStrings:sRpgConnectionString %>" SelectCommand="SELECT * FROM [genero]"></asp:SqlDataSource>
        </div>
        <div class="form-inline">
            <label for="valor">Valor</label>
            <br />
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-addon">R$</div>
                    <asp:TextBox ID="txtValor" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="btnGravar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnRemover" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="btnRemover_Click" />
    </div>
    <br />
    <asp:GridView ID="gdvJogos"  CssClass="table table-hover table-striped" style="width:70%; margin-left:15%" GridLines ="None" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlJogos" AllowPaging="True" PageSize="6" OnRowCommand="gdvJogos_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            <asp:BoundField DataField="valor" HeaderText="valor" SortExpression="valor" />
            <asp:BoundField DataField="idGenero" HeaderText="idGenero" SortExpression="idGenero" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True">
            <ControlStyle CssClass="btn btn-success&quot;" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sqlJogos" runat="server" ConnectionString="<%$ ConnectionStrings:sRpgConnectionString %>" SelectCommand="SELECT * FROM [Jogos]"></asp:SqlDataSource>
</asp:Content>

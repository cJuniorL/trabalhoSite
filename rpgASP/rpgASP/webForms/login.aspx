<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="rpgASP.webForms.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RPG - Login</title>
    <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
    <style>
        body {
            background-image: url(Imagens/bkLogin.jpg);
            background-repeat: no-repeat;
            width: 100%;
            height: 100%;
            background-size: cover;
        }

        .divLogin {
            position: absolute;
            top: 29%; /*Para centralizar a div na tela basta fazer a conta ((100 - height) / 2) = top */
            left: 30%;
            border: solid 0.1vw black;
            height: 42%;
            width: 40%;
            opacity: 1;
            background-color: grey;
            color: black;
        }

        .textDiv {
            font-size: 1.5vw;
            text-align: left;
            margin: 3%;
            margin-bottom: 0%;
            font-weight: bold;
        }

        .panel {
            width: 7%;
            float: right;
        }
    </style>
</head>
<script src="../Scripts/jquery-1.9.1.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="divLogin">
            <h1 style="text-align: center; font-weight: bold; font-size: 2vw; margin-top: 1%">Login de Usuário </h1>
            <h1 class="textDiv">Nome de Usuário</h1>
            <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Usuário" runat="server" Style="padding: 2%; width: 85%; margin: 1%; margin-left: 3%; margin-bottom: 0%; margin-right: 0%; font-size: 1vw; height: 10%; float: left;"></asp:TextBox>
            <h1 class="textDiv">Senha </h1>
            <asp:TextBox ID="txtSenha" type="password" CssClass="form-control" placeholder="Senha" runat="server" Style="padding: 2%; width: 85%; margin: 1%; margin-left: 3%; margin-bottom: 0%; height: 10%; font-size: 1vw;"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" Style="padding: 0; margin: 4%; width: 17%; height: 15%; text-align: center; font-size: 1.5vw" OnClick="btnLogin_Click" />
            <asp:Button ID="btnCadastro" runat="server" Text="Cadastro" CssClass="btn btn-primary" Style="padding: 0; margin: 0%; width: 17%; height: 15%; text-align: center; font-size: 1.5vw" OnClick="btnCadastro_Click" />
        </div>
    </form>
</body>
</html>

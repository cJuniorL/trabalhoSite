<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="rpgASP.webForms.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
    <title>RPG - Cadastro</title>

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
            top: 27.5%; /*Para centralizar a div na tela basta fazer a conta ((100 - height) / 2) = top */
            left: 30%;
            border: solid 0.1vw black;
            height: 45%;
            width: 40%;
            opacity: 1;
            background-color: grey;
            color: black;
        }

        .textDiv {
            font-size: 1.25vw;
            text-align: left;
            margin: 1.5%;
            margin-top: 0.5%;
            margin-bottom: 0.5%;
            font-weight: bold;
        }
        .erro{
            font-size: 1.25vw;
            color: red;
            margin: 1.5%;
            margin-top: 0%;
        }
    </style>

</head>
<script src="../Scripts/jquery-1.9.1.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="divLogin">
            <h1 style="text-align: center; font-weight: bold; font-size: 2vw; margin: 1%">Registro de Usuário </h1>
            <h1 class="textDiv">Nome de Usuário</h1>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Usuário" Style="width: 80%; margin-left: 1.5%; height: 7%; font-size: 1vw; padding: 1%;"></asp:TextBox>
            <h1 class="textDiv">Senha</h1>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Senha" type="password" Style="width: 80%; margin-left: 1.5%; height: 7%; font-size: 1vw; padding: 1%;"></asp:TextBox>
            <h1 class="textDiv">Repita a Senha</h1>
            <asp:TextBox ID="txtConfSenha" runat="server" CssClass="form-control" placeholder="Senha" type="password" Style="width: 80%; margin-left: 1.5%; height: 7%; font-size: 1vw; padding: 1%;"></asp:TextBox>
            <h1 class="textDiv">Email</h1>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" Style="width: 80%; margin-left: 1.5%; height: 7%; font-size: 1vw; padding: 1%;"></asp:TextBox>
            <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" style="padding: 0; margin: 2%; margin-bottom: 0%; width: 14%; height: 10%; text-align: center; font-size: 1vw" data-target="#myModal">Registrar</button>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" Style="padding: 0; margin: 2%; margin-bottom: 0%; width: 14%; height: 10%; text-align: center; font-size: 1vw" OnClick="btnCancelar_Click" />
            <br />
             <asp:Label ID="lblErro" runat="server" Text="" CssClass="erro"></asp:Label>
        </div>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Termos de Contrato</h4>
                    </div>
                    <div class="modal-body">
                        <img src="Imagens/paocaseiro.png"style="float: right; width: 35%; height: 35%"/>
                        <strong>PÃO CASEIRO FÁCIL </strong>
                        <br />
                        <p> Ingredientes:</p>
                        <ul>
                            <li>2 e 1/2 copos de água morna</li>
                            <li>2 colheres (sopa) de açúcar</li>
                            <li>1 colher de sal</li>
                            <li>1 ovo</li>
                            <li>1 copo de óleo</li>
                            <li>1 kg de farinha de trigo</li>
                            <li>50 g de fermento de padaria</li>
                        </ul>
                        <br />
                        <p> Modo de Preparo</p>
                        <ul>
                            <li>Acrescente tudo numa tijela</li>
                            <li>Misture tudo</li>
                            <li>Coloque no forno</li>
                            <li>There is a cake</li>
                        </ul>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Recuso</button>
                        <asp:Button ID="btnGravar" runat="server" Text="Aceito" type="button" CssClass="btn btn-primary" OnClick="btnGravar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

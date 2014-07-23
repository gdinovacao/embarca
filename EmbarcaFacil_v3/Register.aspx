<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="EmbarcaFacil_v3.RegisterE" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Embarca Fácil - Registro</title>

    <meta name="description" content="Embarca Fácil - Registro" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!--basic styles-->

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Application/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!--page specific plugin styles-->

    <!--fonts-->

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!--ace styles-->

    <link rel="stylesheet" href="Application/css/ace.min.css" />
    <link rel="stylesheet" href="Application/css/ace-responsive.min.css" />

    <!--[if lt IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
</head>

<body class=" login-layout">



    <div class="container-fluid" id="main-container">
        <div id="main-content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="login-container">
                        <div class="row-fluid">
                            <div class="center">
                                <h1>
                                    <%--<i class="icon-leaf green"></i>--%>
                                    <%--<span class="red">Ace</span>--%>
                                    <span class="white">Sistema de cotações</span>
                                </h1>
                                <h4 class="blue">&copy; 2013 Embarca fácil</h4>
                                <a style="text-align: center" href="Index.aspx" class="white">Voltar para o site</a>
                            </div>
                        </div>

                        <div class="space-6"></div>

                        <div class="row-fluid">
                            <div class="position-relative">
                                <div id="login-box" class="visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header green lighter bigger">
                                                <%--<i class="icon-group blue"></i>--%>
                                                Register -
                                                Novo registro de usuário
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>
                                                Informe seus dados para iniciar:
                                            </p>

                                            <form runat="server">
                                                <div>
                                                    <label>
                                                        <span class="block input-icon input-icon-right">

                                                            <asp:TextBox ID="txtEmailRegister" class="span12" required="" placeholder="Email" runat="server"></asp:TextBox>


                                                        </span>
                                                    </label>

                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtSenhaRegister" class="span12" required="" placeholder="Senha" runat="server" TextMode="Password"></asp:TextBox>

                                                            <%--<i class="icon-user"></i>--%>
                                                        </span>
                                                    </label>

                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtConfirmSenhaRegister" class="span12" required="" placeholder="Confirme a senha" runat="server" TextMode="Password"></asp:TextBox>
                                                        </span>
                                                    </label>
                                                    <label>
                                                    <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="TxtRazãoSocial" class="span12" required="" placeholder="Razão Social" runat="server"></asp:TextBox>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                    <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtNomeFantasia" class="span12" required="" placeholder="Nome fantasia" runat="server"></asp:TextBox>
                                                        </span>
                                                    </label>

                                                    <label>
                                                    <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtCNPJ" class="span12" required="" placeholder="CNPJ/CPF" runat="server"></asp:TextBox>
                                                        </span>
                                                    </label>

                                                    <label>
                                                    <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtCep" class="span6" required="" placeholder="Cep" runat="server"></asp:TextBox>
                                                            <asp:TextBox ID="txtTelefone" class="span6" required="" placeholder="Tel.Celular" runat="server"></asp:TextBox>    
                                                    </span>
                                                    </label>
                                                    
                                                    <label>
                                                    <span class="block input-icon input-icon-right">
                                                            <asp:DropDownList ID="cmbTipoPessoa" class="span12" required="" runat="server">
                                                            </asp:DropDownList>
                                                        </span>
                                                    </label>
                                                    
                                                            
                                                       



                                                    <div class="row-fluid">
                                                        <asp:Button ID="cmdReset" class="span6 btn btn-small" runat="server" Text="Apagar" />
                                                        <asp:Button ID="cmdRegister" class="span6 btn btn-small btn-success" runat="server" Text="Registrar" />

                                                    </div>
                                                </div>
                                            <div style="text-align:center;" >
                                                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                </div>    
                                            </form>
                                        </div>


                                        <div class="toolbar center">
                                            <div style="text-align:center;width:100%;" >
                                                <a href="Login.aspx" class="forgot-password-link">Voltar para login</a>
                                            </div> 
                                        </div>
                                    </div>
                                    <!--/widget-body-->
                                </div>
                                <!--/signup-box-->
                            </div>
                            <!--/position-relative-->
                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>

    </div>



</body>
</html>

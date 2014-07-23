<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="EmbarcaFacil_v3.LoginE" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Login Page - Ace Admin</title>

    <meta name="description" content="User login page" />
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

<body class="login-layout">
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
                                            <h4 class="header blue lighter bigger">
                                                <%--<i class="icon-coffee green"></i>--%>
                                                Login - Informe seus dados
                                            </h4>

                                            <div class="space-6"></div>

                                            <form runat="server">
                                                <div>
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtEmail" class="span12" required="" placeholder="Email" runat="server"></asp:TextBox>
                                                         
                                                        </span>
                                                    </label>

                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="TxtSenha" class="span12" required="" placeholder="Senha" runat="server" TextMode="Password"></asp:TextBox>
                                                         
                                                        </span>
                                                    </label>

                                                    <div class="space"></div>

                                                    <div style="text-align:right;" class="row-fluid">
                                                                                                                
                                                        <asp:Button ID="cmdLogin" class="span4 btn btn-small btn-primary" runat="server" Text="Login" />
                                                       
                                                    </div>
                                                
                                                </div>
                                                <div style="text-align:center;" >
                                                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                </div>    
                                                    </form>
                                        </div>
                                        <!--/widget-main-->

                                        <div class="toolbar clearfix">
                                            <div>
                                                <a href="ForgotPassword.aspx" class="forgot-password-link">
                                                    <%--<i class="icon-arrow-left"></i>--%>
                                                    Esqueçeu sua senha?
                                                </a>
                                            </div>

                                            <div>
                                                <a href="Register.aspx" class="user-signup-link">Quero me cadastrar
														<%--<i class="icon-arrow-right"></i>--%>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/widget-body-->
                                </div>
                                <!--/login-box-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</body>
</html>


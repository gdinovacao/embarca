<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ForgotPassword.aspx.vb" Inherits="EmbarcaFacil_v3.ForgotPassword" %>



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
                                                Alterar - Informe o email
                                            </h4>

                                            <div class="space-6"></div>

                                            <form id="Form1" runat="server">
                                                <div>


                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtEmail" class="span12" required="" placeholder="Informe o email" runat="server"></asp:TextBox>


                                                        </span>
                                                    </label>



                                                    <div style="text-align: right" class="row-fluid">
                                                        <asp:Button ID="cmdEnviar" class="span4 btn btn-small btn-primary" runat="server" Text="Enviar" />

                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                        <!--/widget-main-->
                                        <div style="text-align: center;" class="toolbar clearfix">
                                            <div style="text-align: center; width: 100%">
                                                <a style="text-align: center;" href="Login.aspx" class="forgot-password-link">Voltar para o login
                                                </a>
                                            </div>


                                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
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

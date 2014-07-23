<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="EmbarcaFacil_v3.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Sign In Option 1 -->
    <div style="background-image: url('img/aqua.jpg')" id="sign_up1">
        <div class="container">
            <div class="row">
                <div class="span12 header">
                    <h4>Crie sua conta</h4>
                    <p>
                        Experimente a plataforma dedicada ao setor logístico e só pague se gostar .
                    </p>

                    <div class="span4 social">
                        <a href="#" class="circle facebook" />
                        <img src="img/face.png" alt="" />
                        </a>
                        <a href="#" class="circle twitter">
                            <img src="img/twt.png" alt="" />
                        </a>
                        <a href="#" class="circle gplus">
                            <img src="img/gplus.png" alt="" />
                        </a>
                    </div>
                </div>

                <div class="span3 division">
                    <div class="line l"></div>
                    <span>or</span>
                    <div class="line r"></div>
                    <asp:Label ID="lblMsg" runat="server" Style="color: #FFFFFF"></asp:Label>
                </div>

                <%--registro de usuario--------------------------------%>
                <div class="span12 footer">



                    <input type="text" id="iptemail" required="" placeholder="E-mail" runat="server" />
                    <input type="password" id="iptsenha" required="" placeholder="Senha" runat="server" />
                    <input type="password" id="iptconfsenha" required="" placeholder="Confirme a senha" runat="server" />
                    <asp:Button ID="cmdRegister" runat="server" Text="Entrar" />


                    
                    <div style="text-align: left;" class="span12 dosnt">
                        <p></p>
                        <p></p> 
                        <span>Já tem uma conta?</span>
                        <a href="Login.aspx">Login</a>
                    </div>
                </div>



            </div>
        </div>
    </div>


</asp:Content>

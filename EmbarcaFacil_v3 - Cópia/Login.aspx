<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="EmbarcaFacil_v3.Login1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Sign In Option 1 -->
    <div style="background-image: url('img/aqua.jpg')" id="sign_in1">
        <div class="container">
            <div class="row">
                <div class="span12 header">
                    <h4>Efetue login com sua conta</h4>


                    <div class="span4 social">
                        <a href="#" class="circle facebook">
                            <img src="img/face.png" alt="">
                        </a>
                        <a href="#" class="circle twitter">
                            <img src="img/twt.png" alt="">
                        </a>
                        <a href="#" class="circle gplus">
                            <img src="img/gplus.png" alt="">
                        </a>
                    </div>
                </div>

                <div class="span3 division">
                    <div class="line l"></div>
                    <span>ou</span>
                    <div class="line r"></div>
                    <p>
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></p>
                </div>

                <div class="span12 footer">

                    <input type="text" id="iptemail" required="" placeholder="E-mail" runat="server" />
                    <input type="password" id="iptsenha" required="" placeholder="Senha" runat="server" />

                    <asp:Button ID="cmdLogin" runat="server" Text="Entrar" />

                </div>

                <div class="span12 proof">
                    <div class="span5 remember">
                        <a href="reset.html">Esqueçeu sua senha?</a>

                    </div>

                    <div class="span3 dosnt">
                        <span>Não tem uma conta?</span>
                        <a href="Register.aspx">Registre-se</a>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ForgotPasswordInfo.aspx.vb" Inherits="EmbarcaFacil_v3.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Sign In Option 1 -->
    <div style="background-image: url('img/aqua.jpg')" id="sign_in1">
        <div class="container">
            <div class="row">
                <div class="span12 header">
                    <h4>Senha alterada com sucesso!</h4>

                    <h5 style="text-align: center;">Efetue o login para acessar sua conta</h5>


                    <div class="span12 footer">

                        <asp:Button ID="txtlogin" runat="server" Text="Login" />


                    </div>


                </div>

            </div>
        </div>
    </div>


</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/Site.Master"CodeBehind="Pricing.aspx.vb" Inherits="EmbarcaFacil_v3.Pricing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<!-- Pricing Option 1 -->
    <div id="in_pricing">
        <div class="container">
            <div class="head">
                <h3>Experimente gratuitamento por 07 dias.</h3>
                <h6>Utilize a ferramente e só pague se realmente gostar:</h6>
            </div>

            <div class="row charts_wrapp">
                <!-- Plan Box -->
                <div class="span4">
                    <div class="plan">
                            <div class="wrapper">
                                <h3>Transportador</h3>
                                <div class="price">
                                    <span class="dollar">$</span>
                                    <span class="qty">35,00</span>
                                    <span class="month">/Mês</span>
                                </div>
                                <div class="features">
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cotações
                                    </p>
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cadastro de fíliais
                                    </p>
                                    <p>
                                        <strong>limitados</strong>
                                        Plus suporte por telefone
                                    </p>
                                </div>
                                <a class="order" href="pricing.html">COMPRE AGORA</a>
                            </div>
                        </div>
                </div>
                <!-- Plan Box -->
                <div class="span4 pro">
                        <div class="plan">
                            <div class="wrapper">
                                <img class="ribbon" src="img/badge.png">
                                <h3>Embarcador</h3>
                                <div class="price">
                                    <span class="dollar">$</span>
                                    <span class="qty">99,00</span>
                                    <span class="month">/Mês</span>
                                </div>
                                <div class="features">
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cotações
                                    </p>
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cadastro de fíliais
                                    </p>
                                    <p>
                                        <strong>limitados</strong>
                                        Plus suporte por telefone
                                    </p>
                                </div>
                                <a class="order" href="pricing.html">COMPRE AGORA</a>
                            </div>
                        </div>
                    </div>
                <!-- Plan Box -->
                <div class="span4 standar">
                    <div class="span4 standar">
                        <div class="plan">
                            <div class="wrapper">
                                <h3>Agenciador</h3>
                                <div class="price">
                                    <span class="dollar">$</span>
                                    <span class="qty">65,00</span>
                                    <span class="month">/Mês</span>
                                </div>
                                <div class="features">
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cotações
                                    </p>
                                    <p>
                                        <strong>Ilimitados</strong>
                                        Cadastro de fíliais
                                    </p>
                                    <p>
                                        <strong>limitados</strong>
                                        Plus suporte por telefone
                                    </p>
                                </div>
                                <a class="order" href="pricing.html">COMPRE AGORA</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="start">
                 <p>Experimente 07 dias grátis! </p>
                <a href="#">Começe agora!</a>
            </div>
        </div>
    </div>
    <!-- FAQs -->
    <div id="faq">
        <div class="container">
            <div class="section_header">
                <h3>Perguntas frequentes</h3>
            </div>

            <div class="row">
                <div class="span6 block">
                    <div class="box">
                        <p class="title">Terei suporte por email e telefone?</p>
                        <p class="answ">
                            O suporte técnico está incluido em qualquer plano que você escolher, tanto suporte por telefone quanto suporte por email.</p>
                    </div>
                    <div class="box">
                        <p class="title">Minhas informações estão seguras?</p>
                        <p class="answ">
                            Adotamos uma série de recursos para proteger seus dados, somente com sua autorização fornecemos email ou telefone para contato, tanto como senhas fortes e criptografadas em toda a ramificação do site.</p>
                    </div>
                </div>

                <div class="span6 block">
                    <div class="box">
                        <p class="title">O site oferece recursos de geolocalização?</p>
                        <p class="answ">
                            Nosso site trabalha com os dados atualizados dos correios, sendo assim toda a estrutura de geolocalização parte da informação do CEP.</p>
                    </div>
                    <div class="box">
                        <p class="title">Terei área administrativa e relatórios?</p>
                        <p class="answ">
                            Sim, todo gerenciamento pode ser realizado pelo site, assim como diversos relatórios disponivéis, e se for necessário customizamos os relatórios que você precisar.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>


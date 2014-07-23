<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.vb" Inherits="EmbarcaFacil_v3.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="Section1" class="">

        <section id="feature_slider" class="">
            <!-- 
            Each slide is composed by <img> and .info
            - .info's position is customized with css in index.css
            - each <img> parallax effect is declared by the following params inside its class:
            
            example: class="asset left-472 sp600 t120 z3"
            left-472 means left: -472px from the center
            sp600 is speed transition
            t120 is top to 120px
            z3 is z-index to 3
            Note: Maintain this order of params

            For the backgrounds, you can combine from the bgs folder :D
        -->
            <article class="slide" id="showcasing" style="background: url('img/landscape.png') repeat-x top center;">
                <img class="asset left-30 sp600 t120 z1" src="img/macbook.png" />
                <div class="info">
                    <h2>Embarcador: Envie cargas com os melhores preços.</h2>
                </div>
            </article>
            <article class="slide" id="ideas" style="background: url('img/aqua.jpg') repeat-x top center;">
                <div class="info">
                    <h2>Gerenciamento em qualquer dispositivo móvel.</h2>
                </div>
                <img class="asset left-480 sp600 t260 z1" src="img/left.png" />
                <img class="asset left-210 sp600 t213 z2" src="img/middle.png" />
                <img class="asset left60 sp600 t260 z1" src="img/right.png" />
            </article>
            <article class="slide" id="tour" style="background: url('img/landscape.png') repeat-x top center;">
                <img class="asset left-472 sp650 t210 z3" src="img/ipad.png" />
                <img class="asset left-365 sp600 t270 z4" src="img/iphone.png" />
                <img class="asset left-350 sp450 t135 z2" src="img/desktop.png" />
                <img class="asset left-185 sp550 t220 z1" src="img/macbook.png" />
                <div class="info">
                    <h2>Encontre seu frete</h2>
                    <a href="Register.aspx">CONHEÇA O PRODUTO</a>
                </div>
            </article>
            <article class="slide" id="responsive" style="background: url('img/indigo.jpg') repeat-x top center;">
                <img class="asset left-472 sp600 t120 z3" src="img/html5.png" />
                <img class="asset left-190 sp500 t120 z2" src="img/css3.png" />
                <div class="info">
                    <h2>OBTENHA <strong>Lucratividade & Agilidade</strong>

                    </h2>
                </div>
            </article>
        </section>

        <div id="showcase">
            <div class="container">
                <div class="section_header">
                    <h3>Vantagens </h3>
                </div>
                <div class="row feature_wrapper">
                    <!-- Features Row -->
                    <div class="features_op1_row">
                        <!-- Feature -->
                        <div class="span4 feature first">
                            <div class="img_box">
                                <a href="services.html">
                                    <img src="img/service1.png">
                                    <span class="circle">
                                        <span class="plus">&#43;</span>
                                    </span>
                                </a>
                            </div>
                            <div class="text">
                                <h6>Embarcador</h6>
                                <p>
                                    Obtenha as melhores negociações no
                        sistema de leilões de fretes, e gerencie todas as suas negociações.
                                </p>
                            </div>
                        </div>
                        <!-- Feature -->
                        <div class="span4 feature">
                            <div class="img_box">
                                <a href="services.html">
                                    <img src="img/service2.png">
                                    <span class="circle">
                                        <span class="plus">&#43;</span>
                                    </span>
                                </a>
                            </div>
                            <div class="text">
                                <h6>Transportador</h6>
                                <p>
                                    Tenha em mãos os melhores fretes
                        em tempo real em todo território nacional, não perca as melhores oportunidades no
                        mercado.
                                </p>
                            </div>
                        </div>
                        <!-- Feature -->
                        <div class="span4 feature last">
                            <div class="img_box">
                                <a href="services.html">
                                    <img src="img/service3.png">
                                    <span class="circle">
                                        <span class="plus">&#43;</span>
                                    </span>
                                </a>
                            </div>
                            <div class="text">
                                <h6>Autônomos</h6>
                                <p>
                                    Receba via SMS os fretes solicitados
                        por transportadores de todo brasil, tenha maior rentabilidade e administre suas
                        cargas!.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="features">
            <div class="container">
                <div class="section_header">
                    <h3>Caracteristicas</h3>
                </div>
                <div class="row feature">
                    <div class="span6">
                        <img src="img/showcase1.png" />
                    </div>
                    <div class="span6 info">
                        <h3>
                            <img src="img/features-ico1.png" />
                            Acesse de qualquer dispositivo.
                        </h3>
                        <p>
                            Receba e solicite cotações de qualquer dispositivo móvel. Gerencie sua carga de qualquer lugar. Possibilidade de rastreamento de sua carga com geração de ocorrências.
                        </p>
                    </div>
                </div>
                <div class="row feature ss">
                    <div class="span6 info">
                        <h3>
                            <img src="img/features-ico2.png" />
                            Blog incluido
                        </h3>
                        <p>
                            Nosso blog trás informações atualizadas sobre a logística no Brasil. Informação de qualidade em qualquer lugar 24 horas por dia.
                        </p>
                    </div>
                    <div class="span6">
                        <img src="img/showcase2.png" class="pull-right" />
                    </div>
                </div>
                <div class="row feature ss">
                    <div class="span6">
                        <img src="img/showcase3.png" />
                    </div>
                    <div class="span6 info">
                        <h3>
                            <img src="img/features-ico3.png" />
                            Simples e rápido
                        </h3>
                        <p>
                            Aplicativo simples desenvolvido para quem precisa de agilidade em suas operações, buscando integrar todos os setores envolvidos no processo logístico.
                        </p>
                    </div>
                </div>
            </div>
        </div>
       

        <!-- Pricing Option -->
        <div id="in_pricing">
            <div class="container">
                <div class="section_header">
                    <h3>Planos</h3>
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
                <div class="start">
                    <p>Experimente 07 dias grátis! </p>
                    <a href="pricing.html">Começe agora!</a>
                </div>
            </div>
        </div>

        <div id="clients">
            <div class="container">
                <div class="section_header">
                    <h3>Clientes:</h3>
                </div>
            </div>
            <div class="span2 client">
                <div class="img client2"></div>
            </div>
            <div class="span2 client">
                <div class="img client3"></div>
            </div>
            <div class="span2 client">
                <div class="img client1"></div>
            </div>
            <div class="span2 client">
                <div class="img client2"></div>
            </div>
            <div class="span2 client">
                <div class="img client3"></div>
            </div>
        </div>
    </section> 
</asp:Content>

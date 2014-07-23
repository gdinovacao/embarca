<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="About.aspx.vb" Inherits="EmbarcaFacil_v3.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="aboutus">
        <div class="container">
            <div class="section_header">
                <h3>Nossa missão</h3>
            </div>
            <div class="row">
                <div class="span6 intro">
                    <h6>Inovar, mais que uma palavra, nosso desafio.</h6>
                    <div>
                       
                            <p>A GDInovação é uma empresa especializada em gestão e desenvolvimento em TI para diversos segmentos, que nasceu com o objetivo de trazer soluções dinâmicas, eficientes e práticas para o dia a dia de sua empresa. Temos uma visão inovadora, e mais de dez anos de expertise no segmento de hardware e desenvolvimento de softwares no ramo logístico, fornecemos produtos de alta qualidade, mobilidade e de credibilidade para padronização de TI da sua empresa.
                                <br />
                                <br />Valorizamos a integridade, a honestidade, o crescimento pessoal
                        contínuo, a abertura e o respeito mútuo. Somos comprometidos com
                        nossos clientes e parceiros e temos paixão por tecnologia.
                        Temos disposiçãode sobra para assumir desafios e levá-los até o fim.
                    </p>
                       
                    </div>
                </div>
                <div class="span6 flexslider">
                    <ul class="slides">
                        <li>
                            <img src="img/about_slide1.jpg" />
                        </li>
                        <li>
                            <img src="img/about_slide1.jpg" />
                        </li>
                        <li>
                            <img src="img/about_slide1.jpg" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div id="team">
        <div class="container">
            <div class="section_header">
                <h3>Nossa equipe</h3>
            </div>

            <div class="row people">
                <div class="row row1">
                    <div class="span6 bio_box">
                        <img src="img/sociocaio.jpg" class="img-circle" alt="socioCaio">
                        <div class="info">
                            <p class="name">Caio César Dinardo</p>
                            <p class="area">Diretor Comercial</p>
                            <a href="#" class="facebook">
                                <span class="socialicons ico1"></span>
                                <span class="socialicons_h ico1h"></span>
                            </a>
                            <a href="#" class="twitter">
                                <span class="socialicons ico2"></span>
                                <span class="socialicons_h ico2h"></span>
                            </a>

                        </div>
                    </div>

                    <div class="span6 bio_box bio_boxr">
                        <img src="img/sociopaulo.jpg" class="img-circle" alt="">
                        <div class="info">
                            <p class="name">Japa do giraia</p>
                            <p class="area">Diretor de desenvolvimento</p>
                            <a href="#" class="facebook">
                                <span class="socialicons ico1"></span>
                                <span class="socialicons_h ico1h"></span>
                            </a>
                            <a href="#" class="twitter">
                                <span class="socialicons ico2"></span>
                                <span class="socialicons_h ico2h"></span>
                            </a>

                        </div>
                    </div>
                </div>

                <div class="row row1">
                    <div class="span6 bio_box">
                        <img src="img/socioricardo.jpg" class="img-circle" alt="socioricardo">
                        <div class="info">
                            <p class="name">Ricardo Alexandre San Gregorio</p>
                            <p class="area">Design</p>
                            <a href="#" class="facebook">
                                <span class="socialicons ico1"></span>
                                <span class="socialicons_h ico1h"></span>
                            </a>
                            <a href="#" class="twitter">
                                <span class="socialicons ico2"></span>
                                <span class="socialicons_h ico2h"></span>
                            </a>

                        </div>
                    </div>

                    <div class="span6 bio_box bio_boxr">
                        <img src="img/ale.png" alt="">
                        <div class="info">
                            <p class="name">Lidiane Tanaka</p>
                            <p class="area">Diretora de Marketing</p>
                            <a href="#" class="facebook">
                                <span class="socialicons ico1"></span>
                                <span class="socialicons_h ico1h"></span>
                            </a>
                            <a href="#" class="twitter">
                                <span class="socialicons ico2"></span>
                                <span class="socialicons_h ico2h"></span>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="process">
        <div class="container">
            <div class="section_header">
                <h3>Processos</h3>
            </div>
            <div class="row services_circles">
                <div class="span4 description">
                    <div class="text active">
                        <h4>Planejamento.</h4>
                        <p>
                            O embarca Fácil foi planejado durante um ano, com o a meta de integrar a cadeia lógista criando uma grande rede social do transporte de cargas.
                        </p>
                    </div>
                    <div class="text">
                        <h4>Desenvolvimento do produto.</h4>
                        <p>
                            O desenvolvimento foi realizado com a mais alta tecnologia no mercado, trazendo a facilidade de utilizar e receber informações em qualquer dispositivo móvel. Temos uma equipe de consultores em TI na área logística.
                        </p>
                    </div>
                    <div class="text">
                        <h4>Design.</h4>
                        <p>
                            Design projetado para o usuário final, com interface bonita e fácil de utilizar, temos o compromisso com acessibilidade e nossa plataforma comtempla estas possibilidades.
                        </p>
                    </div>
                </div>

                <div class="span7 areas">
                    <div class="circle active">
                        <img src="img/plan.png" />
                        <span>Planejamento</span>
                    </div>
                    <div class="circle">
                        <img src="img/develop.png" />
                        <span>Desenvolvimento</span>
                    </div>
                    <div class="circle last_circle">
                        <img src="img/design.png" />
                        <span>Design</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>

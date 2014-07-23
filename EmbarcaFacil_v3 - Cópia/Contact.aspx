<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Contact.aspx.vb" Inherits="EmbarcaFacil_v3.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div id="contact">
        <div class="container">
            <div class="section_header">
                 <h3>Entre em contato</h3>
            </div>
            <div class="row contact">
                <p>
                    Entre em contato, em caso de duvidas, sugestões ou esclarecimentos, estaremos a disposição para pronto atendimento.</p>

              
                    <div class="row form">
                        <div class="span6 box">
                            <input class="name" type="text" placeholder="Name"/>
                            <input class="mail" type="text" placeholder="Email"/>
                            <input class="phone" type="text" placeholder="Phone"/>
                        </div>
                        <div class="span6 box box_r">
                            <textarea placeholder="Escreva sua mensagem..."></textarea>
                        </div>
                    </div>

                    <div class="row submit">
                        <div class="span5 box">
                            <label class="checkbox">
                               <input type="checkbox"/>
                                    Assine nosso newslatter
                            </label>
                        </div>
                        <div class="span3 right">
                            <input type="submit" value="Enviar mensagem"/>
                        </div>
                    </div>
               
            </div>
        </div>

        <div class="row map">
                <div class="container">
                    <div class="span5 box_wrapp">
                        <div class="box_cont">
                            <div class="head">
                                <h6>Contato</h6>
                            </div>
                            <ul class="street">
                                <li>Rua imperatriz leopoldina, 362.</li>
                                <li>Caieiras, São Paulo. Brasil,</li>
                                <li>Cep, 07700-000.</li>
                                <li class="icon icontop">
                                    <span class="contacticos ico1"></span>
                                    <span class="text">1 817 274 2933</span>
                                </li>
                                <li class="icon">
                                    <span class="contacticos ico2"></span>
                                    <a class="text" href="#">contato@embarcafacil.com.br</a>
                                </li>
                            </ul>

                            <div class="head headbottom">
                                <h6>Contato telefonico</h6>
                            </div>
                            <p>Fale com um atendente.</p>

                            <a href="#" class="btn">Entre em contato</a>
                        </div>
                    </div>
                </div>
            <iframe width="100%" height="600" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com.mx/maps?f=q&amp;source=embed&amp;hl=pt-BR&amp;geocode=&amp;q=Rua+Imperatriz+Leopoldina,+Caieiras+-+S%C3%A3o+Paulo,+Rep%C3%BAblica+Federativa+do+Brasil&amp;aq=0&amp;oq=Caieiras+-+Rua+imp,+S%C3%A3o+Paulo,+Rep%C3%BAblica+Federativa+do+Brasil&amp;sll=-23.383357,-46.720321&amp;sspn=0.010478,0.013797&amp;ie=UTF8&amp;hq=&amp;hnear=R.+Imperatriz+Leopoldina,+Caieiras+-+S%C3%A3o+Paulo,+07700-000,+Rep%C3%BAblica+Federativa+do+Brasil&amp;t=m&amp;ll=-23.339655,-46.761589&amp;spn=0.037828,0.054932&amp;z=14&amp;iwloc=A&amp;output=embed"></iframe>
        </div>
    </div>

</asp:Content>

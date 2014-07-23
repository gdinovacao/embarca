<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Application/Transportador/Transportador.Master" CodeBehind="CalendarioTransportador.aspx.vb" Inherits="EmbarcaFacil_v3.CalendarioTransportador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header position-relative">
        <h1>Calendário
					<small>
                        <i>(Arraste o evento para seu calendário)</i>
                    </small>
        </h1>
    </div>
    <!--/.page-header-->


    <!--PAGE CONTENT BEGINS HERE-->

    <div class="row-fluid">
        <div class="span9">
            <div class="space"></div>

            <div id="calendar"></div>
        </div>

        <div class="span3">
            <div class="widget-box transparent">
                <div class="widget-header">
                    <h4>Eventos</h4>
                </div>

                <div class="widget-main">
                    <div id="external-events">
                        <div class="external-event label-grey" data-class="label-grey">
                            <i class="icon-move"></i>
                            Evento 01
                        </div>

                        <div class="external-event label-success" data-class="label-success">
                            <i class="icon-move"></i>
                            Evento 02
                        </div>

                        <div class="external-event label-important" data-class="label-important">
                            <i class="icon-move"></i>
                            Evento 03
                        </div>

                        <div class="external-event label-purple" data-class="label-purple">
                            <i class="icon-move"></i>
                            Evento 04
                        </div>

                        <div class="external-event label-yellow" data-class="label-yellow">
                            <i class="icon-move"></i>
                            Evento 05
                        </div>

                        <div class="external-event label-pink" data-class="label-pink">
                            <i class="icon-move"></i>
                            Evento 06
                        </div>

                        <div class="external-event label-info" data-class="label-info">
                            <i class="icon-move"></i>
                            Evento 07
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Application/Painel.Master" CodeBehind="Quotation.aspx.vb" Inherits="EmbarcaFacil_v3.Quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="header smaller lighter blue">
        <h3>Encontre seu frete</h3>
    </div>
    <p>
        <asp:TextBox ID="txtCepOrigem" class="input-xlarge" placeholder="Cep de origem" runat="server"></asp:TextBox>
    </p>
    <p>

        <asp:TextBox ID="txtCepDestino" class="input-xlarge" placeholder="Ce de destino" runat="server"></asp:TextBox>
    </p>

    <div class="header smaller lighter blue">
        <h3>Dados da carga</h3>
    </div>
    <a href="#" class="adicionarCampo">Adicionar volume</a>
    <br />
    <br />

    <div class="telefones">
        <p class="campoTelefone">
            <asp:TextBox ID="txtQtdeCaixas" class="input-medium" placeholder="Nº de caixas" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtComprimento" class="input-mini" placeholder="Comp" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtLargura" class="input-mini" placeholder="Largura" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtAltura" class="input-mini" placeholder="Altura" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPesoUnit" class="input-medium" placeholder="Peso cada caixa" runat="server"></asp:TextBox>

            <a href="#" class="removerCampo">Remover</a>
        </p>
    </div>
    <div class="header smaller lighter blue">
        <h3>Dados da nota fiscal</h3>
    </div>

    <div class="controls">
        <asp:TextBox ID="txtValorNotaFiscal" class="large" placeholder="Valor nota fiscal" required="" runat="server"></asp:TextBox>
    </div>

    <br />
    <div class="controls">
        <asp:DropDownList class="input-xlarge" ID="cmbMercadoria" runat="server">
            <asp:ListItem>Tipo de Transporte</asp:ListItem>
            <asp:ListItem>CIF(Pagante é o Remetente)</asp:ListItem>
            <asp:ListItem>FOB(Pagante é o Destinatário)</asp:ListItem>
        </asp:DropDownList>
    </div>


    <div class="controls">
        <asp:Button ID="cmdLocalizar" class="btn btn-small btn-primary" runat="server" Text="Localizar" />
    </div>


</asp:Content>

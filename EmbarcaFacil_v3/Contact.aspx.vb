Public Class Contact
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        Dim gdi As New clsGDI
        Dim strnome As String
        Dim stremail As String
        Dim strdesc As String
        Dim strphone As String



        strnome = Request.Form("nome").ToString
        stremail = Request.Form("email").ToString
        strdesc = Request.Form("desc").ToString
        strphone = Request.Form("phone").ToString



        'ENVIO DE EMAIL DE USUÁRIO PARA CONTATO
        gdi.fenviaMensagemEmailTXT("gdi@gdinovacao.com.br", "Email: " + stremail, "Nome: " + strnome + vbNewLine + "telefone: " + strphone + vbNewLine + vbNewLine + "Assunto: " + strdesc)

        Request.Form("desc") = "E-mail enviado com sucesso!" + vbNewLine + vbNewLine + " Retornaremos seu contato em breve."
        Request.Form("email") = ""
        Request.Form("nome") = ""
        Request.Form("strphone") = ""

    End Sub
End Class
Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        Dim gdi As New clsGDI

        If Trim(txtEmailUser.Text) = "" Then
            MsgBox("informe um email válido")
            Exit Sub
        End If

        If Trim(txtUser.Text) = "" Then
            MsgBox("informe seu nome")
            Exit Sub
        End If

        If Trim(txtMsgUser.Text) = "" Then
            MsgBox("escreva uma mensagem")
            Exit Sub
        End If

        'ENVIO DE EMAIL DE USUÁRIO PARA CONTATO
        gdi.fenviaMensagemEmailTXT("gdi@gdinovacao.com.br", "Email: " + txtEmailUser.Text, "Nome: " + txtUser.Text + vbNewLine + vbNewLine + "Assunto: " + txtMsgUser.Text)

        txtMsgUser.Text = "E-mail enviado com sucesso!" + vbNewLine + vbNewLine + " Retornaremos seu contato em breve."
        txtEmailUser.Text = ""
        txtUser.Text = ""
    End Sub
End Class
Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click

        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strpassord As String
        Dim strEmail As String
        Dim strlink As String


        strpassord = "0"
        'email do usuário
        strEmail = Trim(txtEmail.Text)
        Dim dtRead As IDataReader
        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = odb.Select_Table("tbdPessoa", "str_senha", "str_email='" + strEmail + "' and str_ativo='V'")
        dtRead = odb.fRertornaCampos(SQL)

        'Inicia ponteiro
        Do While dtRead.Read
            strpassord = dtRead("str_senha")
        Loop

        If strpassord = "0" Then

            lblmsg.Text = "Email não cadastrado"

        End If
      
        strEmail = Trim(txtEmail.Text)


        'link de ativação
        strlink = Request.Url.GetLeftPart(UriPartial.Authority) & Page.ResolveUrl("~/ResetPassword.aspx?ID=" & strpassord)
        'envio do email
        GDI.fenviaMensagemEmail(strEmail, strlink, "ForgotPassword.htm")

        'redirecional para pagina de informação
        HttpContext.Current.Response.Redirect("~/ForgotPasswordMessage.aspx")


    End Sub
End Class
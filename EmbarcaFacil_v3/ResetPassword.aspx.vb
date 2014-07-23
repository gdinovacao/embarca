Public Class ResetPasswordE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strKey As String
        Dim Str_email As String
        'Validações de cadastro

        Str_email = ""

        strKey = Request.QueryString("ID")

        'label guarda a senha do usuário para efetuar o update, ja que a senha é formada pela senha e o email concatenado
        lblkey.Text = strKey

        If IsNothing(strKey) Then Exit Sub


        Dim dtRead As IDataReader
        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = "select id_pessoa, str_email from  tbdPessoa where str_senha='" + strKey + "'"
        dtRead = odb.fRertornaCampos(SQL)

        'Inicia ponteiro
        Do While dtRead.Read
            If dtRead("id_pessoa") Is DBNull.Value Then
                HttpContext.Current.Response.Redirect("~/index.html")

            Else
                lblmail.Text = dtRead("str_email")
            End If

        Loop
    End Sub
    Protected Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        Dim SQL As String
        Dim odb = New clsDB
        Dim strsenha As String
        Dim gdi = New clsGDI


        If Trim(txtNovaSenhaReset.Text) <> Trim(TxtNovaSenhaConfirmeReset.Text) Then
            lblmsg.Text = "Senhas não conferem!"
            Exit Sub
        End If
        strsenha = Trim(txtNovaSenhaReset.Text) + lblmail.Text

        strsenha = gdi.Encrypt(strsenha)

        If lblkey.Text = "" Then
            lblmsg.Text = "Desculpe, acesse o link que foi passado por email"
            Exit Sub
        End If


        SQL = "UPDATE tbdpessoa SET str_senha= '" + strsenha + "'  WHERE str_senha='" + lblkey.Text + "' "
        If Not odb.fExecutarSql(SQL) Then Exit Sub

        'redirecional para pagina de informação
        HttpContext.Current.Response.Redirect("~/ForgotPasswordInfo.aspx")

    End Sub
End Class
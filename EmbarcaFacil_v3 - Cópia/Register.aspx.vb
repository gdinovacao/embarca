
Public Class Register
    Inherits BasePage

    Public gdi As New clsGDI
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
    End Sub
    Protected Sub cmdRegister_Click(sender As Object, e As EventArgs) Handles cmdRegister.Click

        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strpassord As String
        Dim stremail As String
        Dim str_ativo As String
        Dim strLink As String

        'Validações de cadastro




        'Razão Social
        If Trim(Request.Form("iptemail").ToString) = "" Then
            lblMsg.Text = "Informe o email"
            Exit Sub

        End If

        If Trim(Request.Form("iptsenha").ToString) = "" Then
            lblMsg.Text = "Informa a senha!"
            Exit Sub
        End If

        If Len(Request.Form("iptsenha").ToString) < 6 Then
            lblMsg.Text = "A senha deve conter ao menos seis dígitos!"
            Exit Sub
        End If

        If Trim(Request.Form("iptconfsenha").ToString) = "" Then
            lblMsg.Text = "Informe a confirmação da senha!"
            Exit Sub
        End If


        If Trim(Request.Form("iptsenha").ToString) <> Trim(Request.Form("iptconfsenha").ToString) Then
            lblMsg.Text = "Senhas não coicidem!"
            Exit Sub
        End If

        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = "select id_pessoa from  tbdPessoa where str_email='" + Replace(Trim(Request.Form("iptemail").ToString), "'", "") + "'"
        Dim StrID As String = odb.fRetornaID(SQL)

        If StrID <> 0 Then
            lblMsg.Text = "Email já cadastrado!"
            Exit Sub
        End If

        'senha do usuário
        strpassord = GDI.Cifrar(Trim(Request.Form("iptemail")).ToString, Trim(Request.Form("iptsenha")).ToString)
        'email do usuário
        stremail = Trim(Request.Form("iptemail")).ToString
        'usuário ativo  = false(F)
        str_ativo = "F"

        'USUÁRIO CADASTRADO MAS NÃO ATIVO NO SITE

        SQL = "INSERT INTO tbdpessoa(str_email, str_senha, str_ativo) values ('" + Replace(Trim(Request.Form("iptemail")).ToString, "'", "") + "', + '" + strpassord + "', + '" + str_ativo + "')"
        If Not odb.fExecutarSql(SQL) Then Exit Sub


        'fim do insert ------------------------------------

        'link de ativação
        strLink = Request.Url.GetLeftPart(UriPartial.Authority) & Page.ResolveUrl("~/Verify.aspx?ID=" & strpassord)
        'envio do email
        gdi.fenviaMensagemEmail(Trim(Request.Form("iptemail").ToString), strLink)

        'redirecional para pagina de informação
        Server.Transfer("RegisterInfo.aspx")


        'Criar Cookie de consulta
        '  Dim dtRead As IDataReader
        ' SQL = "select id_pessoa,str_email,str_DsUser from tbdPessoa where str_email='" + Replace(Trim(txtEmail.Text), "'", "") + "' "
        'dtRead = odb.fRertornaCampos(SQL)

        'Inicia ponteiro
        'Do While dtRead.Read
        'If Not GDI.fCriarCookies(dtRead("id_pessoa"), dtRead("str_email"), dtRead("str_dsuser")) Then Exit Sub
        'Loop


        'HttpContext.Current.Items.Add("email", Replace(Trim(txtEmail.Text), "'", ""))

        'Chama a classe e autenticação de usuários
        'If Not GDI.fAutenticationUser(txtEmail.Text) Then Exit Sub



    End Sub
End Class
Public Class LoginE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
    End Sub

    Protected Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strpassord As String
        Dim strEmail As String


        If Trim(txtEmail.Text) = "" Then
            lblMsg.Text = "Informe o email"
            Exit Sub

        End If

        If Trim(TxtSenha.Text) = "" Then
            lblmsg.Text = "Informe a senha!"
            Exit Sub
        End If

        If Len(TxtSenha.Text) < 6 Then
            lblMsg.Text = "A senha deve conter ao menos seis dígitos!"
            Exit Sub
        End If

        'senha do usuário
        strpassord = Trim(TxtSenha.Text) + Trim(txtEmail.Text)
        strpassord = GDI.Encrypt(strpassord)
        'email do usuário
        strEmail = Trim(txtEmail.Text)

        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = odb.Select_Table("tbdPessoa", "id_Pessoa", "str_senha= '" + strpassord + "' and str_ativo='V'")
        Dim StrID As String = odb.fRetornaID(SQL)

        If StrID = 0 Then
            lblMsg.Text = "Dados não conferem!"
            Exit Sub
        End If

        'Chama a classe e autenticação de usuários
        If Not GDI.fAutenticationUser(Replace(Trim(txtEmail.Text), "'", "")) Then Exit Sub
    End Sub

End Class
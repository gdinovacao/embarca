Public Class Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strpassord As String
       


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

        'senha do usuário
        strpassord = GDI.Cifrar(Trim(Request.Form("iptsenha")).ToString, Trim(Request.Form("iptsenha")).ToString)

        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = "select id_pessoa from  tbdPessoa where str_email='" + Replace(Trim(Request.Form("iptemail").ToString), "'", "") + "' and str_ativo='V'"
        Dim StrID As String = odb.fRetornaID(SQL)

        If StrID = 0 Then
            lblMsg.Text = "Dados não conferem!"
            Exit Sub
        End If


        'Chama a classe e autenticação de usuários
        If Not GDI.fAutenticationUser(Replace(Trim(Request.Form("iptemail").ToString), "'", "")) Then Exit Sub
    End Sub
End Class
Public Class Login
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


        If IsNothing(strKey) Then Exit Sub


        Dim dtRead As IDataReader
        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = "select id_pessoa from  tbdPessoa where str_senha='" + strKey + "'"
        dtRead = odb.fRertornaCampos(SQL)

       

        'Inicia ponteiro
        Do While dtRead.Read
            If dtRead("id_pessoa") Is DBNull.Value Then
                HttpContext.Current.Response.Redirect("~/404.html")

            Else
                SQL = "UPDATE tbdpessoa SET str_ativo='V'  WHERE id_pessoa='" + dtRead("id_pessoa").ToString() + "' "
                If Not odb.fExecutarSql(SQL) Then Exit Sub
            End If
        Loop


        
    End Sub
    Protected Sub txtlogin_Click(sender As Object, e As EventArgs) Handles txtlogin.Click

        HttpContext.Current.Response.Redirect("~/login.aspx")
    End Sub
End Class
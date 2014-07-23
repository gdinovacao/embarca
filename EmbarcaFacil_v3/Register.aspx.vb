Public Class RegisterE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        Dim odb As New clsDB
        Dim gdi As New clsGDI

        On Error GoTo Erro_Tratamento

        If Page.IsPostBack = False Then

            'Verifica se o Cep existe na base de dados
            SQL = "select id_tipo, str_tipo from tbdTipoEmpresa "
            If Not odb.fPreencheListView(SQL, "id_tipo", "str_tipo", cmbTipoPessoa) Then GoTo Erro_Tratamento

        End If
Exit_Procedure:

        'Sair do Procedimento
        Exit Sub
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If



    End Sub
    Protected Sub cmdRegister_Click(sender As Object, e As EventArgs) Handles cmdRegister.Click
        Dim SQL As String
        Dim odb As New clsDB
        Dim GDI As New clsGDI
        Dim strpassord As String
        Dim stremail As String
        Dim str_ativo As String
        Dim strRazao As String
        Dim strNomeFantasia As String
        Dim strCNPJ As String
        Dim strCEP As String
        Dim strCelular As String
        Dim strTelefone As String
        Dim IDTipoEmpresa As Integer

        On Error GoTo Erro_Tratamento

        Dim strLink As String
        Dim aCampos As Object

        'Validações de cadastro


        'Razão Social
        If Trim(txtEmailRegister.Text) = "" Then
            lblmsg.Text = "Informe o email"
            GoTo Exit_Procedure

        End If

        If Trim(txtSenhaRegister.Text) = "" Then
            lblmsg.Text = "Informa a senha!"
            GoTo Exit_Procedure
        End If

        If Len(txtSenhaRegister.Text) < 6 Then
            lblmsg.Text = "A senha deve conter ao menos seis dígitos!"
            GoTo Exit_Procedure
        End If

        If Trim(txtConfirmSenhaRegister.Text) = "" Then
            lblmsg.Text = "Informe a confirmação da senha!"
            GoTo Exit_Procedure
        End If

        If Trim(txtConfirmSenhaRegister.Text) <> Trim(txtSenhaRegister.Text) Then
            lblmsg.Text = "Senhas não conferem!"
            GoTo Exit_Procedure
        End If


        If cmbTipoPessoa.SelectedIndex = -1 Then
            lblmsg.Text = "Informe o tipo da empresa!"
            GoTo Exit_Procedure
        End If

        IDTipoEmpresa = cmbTipoPessoa.SelectedItem.Value

        'Verifica se o cnpj já está cadastrado e retorna o id da aplica
        SQL = "select id_pessoa from  tbdPessoa where str_email='" + Replace(Trim(txtEmailRegister.Text), "'", "") + "'"
        Dim StrID As String = odb.fRetornaID(SQL)

        If StrID <> 0 Then
            lblmsg.Text = "Email já cadastrado!"
            GoTo Exit_Procedure
        End If

        '--------------- PREENCHENDO AS VARIAVEIS -----------------------

        'Senha do usuário concatenado com o email, pois na validação, não terá perigo de dois usuários com a mesma senha
        strpassord = Trim(txtSenhaRegister.Text) + Trim(txtEmailRegister.Text)
        strpassord = GDI.Encrypt(strpassord)
        'Email do usuário
        stremail = Replace(Trim(txtEmailRegister.Text), "'", "")
        'Usuário ativo  = false(F)
        str_ativo = "F"
        'Razão social
        strRazao = Replace(Trim(TxtRazãoSocial.Text), "'", "")
        'Nome fantasia
        strNomeFantasia = Replace(Trim(txtNomeFantasia.Text), "'", "")
        'Cnpj
        strCNPJ = GDI.CarRemove(Trim(txtCNPJ.Text))

        strCEP = Replace(Trim(txtCep.Text), "'", "")
        'Se for formato de cpf
        If Len(GDI.CarRemove(Trim(txtCNPJ.Text)) = 11) Then

            If GDI.fValidaCPF(strCNPJ) Then
                lblmsg.Text = "Informe um cpf válido!"
            End If

            'Se for formato de cnpj
        ElseIf Len(GDI.CarRemove(Trim(txtCNPJ.Text)) = 14) Then
            If Not GDI.fValidaCNPJ(strCNPJ) Then
                lblmsg.Text = "Informe um cnpj válido!"
            End If
        End If

        'Cep
        'Verifica se o Cep existe na base de dados
        SQL = odb.Select_Table("log_logradouro", "CEP", "CEP='" + strCEP + "' ")
        strCEP = odb.fRetornaID(SQL)

        If strCEP = 0 Then
            lblmsg.Text = "Informe um CEP válido!"
            GoTo Exit_Procedure
        End If

        'Celular
        strCelular = Replace(Trim(txtTelefone.Text), "'", "")
        'Tipo empresa


        strTelefone = Trim(txtTelefone.Text)
        '------------------------------------------------------------------
        aCampos = {stremail, strpassord, str_ativo, strRazao, strNomeFantasia, strCNPJ, strCEP, strTelefone, IDTipoEmpresa}
        If odb.Insert_Table("tbdPessoa", "str_email, str_senha, str_ativo, str_razaosocial, str_nomefantasia, str_cnpj, str_cep, str_telefone, id_tipoempresa", "", aCampos) = -1 Then
            lblmsg.Text = "Ocorreu um erro na gravação."
            GoTo Exit_Procedure
        End If

        'fim do insert ------------------------------------

        'link de ativação
        strLink = Request.Url.GetLeftPart(UriPartial.Authority) & Page.ResolveUrl("~/Verify.aspx?ID=" & strpassord)
        'envio do email
        GDI.fenviaMensagemEmail(stremail, strLink, "NewAccountTemplate.htm")

        'redirecional para pagina de informação
        HttpContext.Current.Response.Redirect("~/RegisterInfo.aspx")

      
Exit_Procedure:

        'Sair do Procedimento
        Exit Sub
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If
    End Sub
End Class
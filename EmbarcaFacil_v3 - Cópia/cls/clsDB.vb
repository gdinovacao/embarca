Imports System.Data.SqlClient
Imports System.Data

Public Class clsDB

    'Objeto de Banco de Dados
    Public cnnDB As Object 'objeto SQL
    Public SQLcmd As Object 'Objeto executa string
    Public blnConexaoBD As Boolean 'variavel boleana
    Public gdi As New clsGDI
    Public strStringConn As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Public Function fExecutarSql(SQL As String) As Boolean


        'Iniciar procedimento com não executado com sucesso
        fExecutarSql = False

        'Validar se existe estrutura SQL
        If Len(Trim(SQL)) = 0 Then Exit Function

        'Limpar erros vb
        Err.Clear()

        Dim SQLconn As SqlConnection = New SqlConnection() 'objeto SQL Server
        Dim SQLcmd As SqlCommand = New SqlCommand 'objeto de comando SQL
        SQLcmd = SQLconn.CreateCommand

        'Retira as aspas quando houver campos do tipo nulo
        SQL = Replace(SQL, "'null'", "null")
        'Obtem string de conexão
        SQLconn.ConnectionString = strStringConn
        'Abre conexão com banco de dados
        SQLconn.Open()
        'Comando SQL
        SQLcmd.CommandText = SQL
        'Executa comando SQL
        SQLcmd.ExecuteReader()
        'Fecha banco de dados
        SQLconn.Close()

        'Retornar execução com sucesso
        fExecutarSql = True


    End Function
    Public Function fPreencheGridViewSQL(ByVal StringSQL As String, _
                                  ByVal GridVName As GridView) As Boolean


        'Iniciar procedimento com não executado com sucesso
        fPreencheGridViewSQL = False

        'Validar se existe estrutura SQL
        If Len(Trim(StringSQL)) = 0 Then Exit Function


        Dim connection As New SqlConnection(strStringConn)
        Dim dataadapter As New SqlDataAdapter(StringSQL, connection)
        Dim ds As New DataSet()
        connection.Open()
        dataadapter.Fill(ds, "Authors_table")
        connection.Close()
        GridVName.DataSource = ds
        GridVName.DataMember = "Authors_table"

        GridVName.DataBind()

        'Retornar execução com sucesso
        fPreencheGridViewSQL = True


    End Function
    Public Function fRetornaID(StringSQL As String)




        'Iniciar procedimento com não executado com sucesso
        fRetornaID = False

        Dim resultado As String
        Dim SQLconn As SqlConnection = New SqlConnection(strStringConn)
        Dim SQLCmd As SqlCommand = SQLconn.CreateCommand()
        'define o tipo do comando como texto 
        SQLCmd.CommandText = StringSQL
        ' Executa o comando SQL
        SQLconn.Open()
        resultado = Convert.ToString(SQLCmd.ExecuteScalar())
        SQLconn.Close()

        If resultado = "" Then
            resultado = "0"
        End If
        Return resultado


        'Retornar execução com sucesso
        fRetornaID = True



    End Function

    Public Function fRetornaUsuario(EmailUsuario As String, Senha As String)



        'Iniciar procedimento com não executado com sucesso
        fRetornaUsuario = False




        'Retornar execução com sucesso
        fRetornaUsuario = True


    End Function

    Public Function fPreencheListView(ByVal StringSQL As String, StrId As String, _
                                      STRdescricao As String, ByVal DropdowName As DropDownList) As Boolean


        'Iniciar procedimento com não executado com sucesso.
        fPreencheListView = False

        'Validar se existe estrutura SQL
        If Len(Trim(StringSQL)) = 0 Then Exit Function

        Dim connection As New SqlConnection(strStringConn)
        Dim dataadapter As New SqlDataAdapter(StringSQL, connection)

        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = connection
        connection.Open()
        cmd.CommandText = StringSQL
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        DropdowName.DataSource = dr
        DropdowName.DataTextField = STRdescricao
        DropdowName.DataValueField = StrId
        DropdowName.DataBind()
        dr.Close()
        connection.Close()

        'Retornar execução com sucesso
        fPreencheListView = True


    End Function

    Public Function fRertornaCampos(StringSQL As String)

        'Dim oStrCampo As String


        fRertornaCampos = False

        'Validar se existe estrutura SQL
        If Len(Trim(StringSQL)) = 0 Then Exit Function

        'Limpar erros vb
        Err.Clear()

        Dim SQLConn As New SqlConnection(strStringConn)
        Dim SQLcmd As New SqlCommand
        SQLcmd = SQLConn.CreateCommand()
        'define o tipo do comando como texto 
        SQLcmd.CommandText = StringSQL
        'Executa o comando SQL
        SQLConn.Open()
        Dim dr As SqlDataReader
        dr = SQLcmd.ExecuteReader

        If dr.FieldCount = 0 Then
            fRertornaCampos = True
        End If

        Return dr


        'Do While dr.Read
        'oStrCampo = dr(str_DsParametro).ToString

        'Return oStrCampo
        'Loop


        'SQLconn.Close()
        'Retornar execução com sucesso
        fRertornaCampos = True


    End Function

End Class

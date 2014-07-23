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

        On Error GoTo Erro_Tratamento
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

Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            fExecutarSql = False
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function
    Public Function fPreencheGridViewSQL(ByVal StringSQL As String, _
                                  ByVal GridVName As GridView) As Boolean

        On Error GoTo Erro_Tratamento
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


Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            fPreencheGridViewSQL = False
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function
    Public Function fRetornaID(StringSQL As String)

        On Error GoTo Erro_Tratamento
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

Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            fRetornaID = False
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function
    Public Function fPreencheListView(ByVal StringSQL As String, StrId As String, _
                                      STRdescricao As String, ByVal DropdowName As DropDownList) As Boolean

        On Error GoTo Erro_Tratamento
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

Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            fPreencheListView = False
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function

    Public Function fRertornaCampos(StringSQL As String)

        'Dim oStrCampo As String

        On Error GoTo Erro_Tratamento
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


Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            fRertornaCampos = False
            Resume Exit_Procedure
        Else
            Resume Next
        End If
    End Function

    Public Function ColocarNolock(ByVal sSQL) As String
        Dim iPosicao As Integer
        Dim iPosicao2 As Integer
        Dim bTerminou As Boolean
        Dim sSQLInicio As String
        Dim sSQLFim As String
        Dim bAchouAlias As Boolean

        On Error GoTo Erro_Tratamento

        ColocarNolock = ""

        'Procurando final do comando SQL
        iPosicao = InStr(1, sSQL, " WHERE ", vbTextCompare)
        If iPosicao = 0 Then
            iPosicao = InStr(1, sSQL, " WHERE(", vbTextCompare)
            If iPosicao = 0 Then
                iPosicao = InStr(1, sSQL, " GROUP BY", vbTextCompare)
                If iPosicao = 0 Then
                    iPosicao = InStr(1, sSQL, " ORDER BY", vbTextCompare)
                    If iPosicao = 0 Then
                        iPosicao = Len(sSQL) + 1
                    End If
                End If
            End If
        End If
        sSQLInicio = Trim(Mid(sSQL, 1, iPosicao - 1))
        sSQLFim = Trim(Mid(sSQL, iPosicao))

        'Procurando inicio do comando SQL
        iPosicao = InStr(1, sSQLInicio, " FROM ", vbTextCompare)
        If iPosicao = 0 Then
            iPosicao = InStr(1, sSQLInicio, " FROM(", vbTextCompare)
            If iPosicao = 0 Then
                ColocarNolock = "-1"
                'MsgBox("Cláusula não encontrada!", vbExclamation, App.Title)
                Exit Function
            End If
        End If

        iPosicao = iPosicao + 5
        Do While iPosicao <= Len(sSQLInicio)
            iPosicao2 = 0
            bTerminou = False
            bAchouAlias = False
            Do While Not bTerminou
                Select Case Mid(sSQLInicio, iPosicao + iPosicao2, 1)
                    'Case "a" To "z", "A" To "Z", "_", "-", "0" To "9"
                    Case "a" To "z", "A" To "Z", ".", "_", "-", "0" To "9"    'Acrescentado o ponto para joins com dois bancos
                        iPosicao2 = iPosicao2 + 1
                    Case Else
                        If iPosicao2 = 0 Then
                            iPosicao = iPosicao + 1
                        Else
                            bTerminou = True
                            'Verificando se a tabela não recebeu um alias
                            If Not bAchouAlias Then
                                Do While Mid(sSQLInicio, iPosicao + iPosicao2, 1) = " "
                                    iPosicao2 = iPosicao2 + IIf(Mid(sSQLInicio, iPosicao + iPosicao2, 1) = " ", 1, 0)
                                    If Mid(sSQLInicio, iPosicao + iPosicao2) = " " Then
                                        'Não faz nada
                                    ElseIf UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 11)) = "INNER JOIN " _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 11)) = "INNER JOIN(" _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 10)) = "LEFT JOIN " _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 10)) = "LEFT JOIN(" _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 5)) = "JOIN " _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 5)) = "JOIN(" _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 3)) = "ON " _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 3)) = "ON(" _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 1)) = ")" _
                                           Or UCase(Mid(sSQLInicio, iPosicao + iPosicao2, 1)) = "," Then
                                        iPosicao2 = iPosicao2 - 1
                                        Exit Do
                                        bTerminou = True
                                    Else
                                        bAchouAlias = True
                                        bTerminou = False   'Se entrar aqui, é porque é o alias da tabela
                                    End If
                                Loop
                            End If
                        End If
                End Select
            Loop

            sSQLInicio = Mid(sSQLInicio, 1, iPosicao + iPosicao2 - 1) & " (NOLOCK)" & Mid(sSQLInicio, iPosicao + iPosicao2)

            If UCase(Mid(sSQLInicio, iPosicao + iPosicao2 + 9, 1)) = "," Then
                iPosicao = iPosicao + iPosicao2 + 1 + 9
            Else
                iPosicao = iPosicao + iPosicao2 + 1

                'Procurando próximo join
                iPosicao2 = InStr(iPosicao, sSQLInicio, " JOIN ", vbTextCompare)
                If iPosicao2 = 0 Then
                    iPosicao2 = InStr(iPosicao, sSQLInicio, " JOIN(", vbTextCompare)
                    If iPosicao2 = 0 Then
                        iPosicao2 = InStr(iPosicao, sSQLInicio, ")JOIN(", vbTextCompare)
                        If iPosicao2 = 0 Then
                            iPosicao2 = InStr(iPosicao, sSQLInicio, ")JOIN ", vbTextCompare)
                        End If
                    End If
                End If

                If iPosicao2 = 0 Then
                    iPosicao = Len(sSQLInicio) + 1
                Else
                    iPosicao = iPosicao2 + 5
                End If
            End If
        Loop

        ColocarNolock = sSQLInicio & " " & sSQLFim

Exit_Procedure:
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If


    End Function

    Public Function AcertaSql(ByRef sSQL As String) As String

        Dim bAchou As Boolean
        Dim iPosInicial As Long
        Dim iPosSinal1 As Long
        Dim iPosSinal2 As Long
        Dim iPosVirg1 As Long
        Dim iPosVirg2 As Long

        Dim iPosFinal As Long
        Dim iPosAux1 As Long
        Dim iPosAux2 As Long
        Dim iPosAux3 As Long
        Dim iCont As Long
        Dim iCont1 As Long
        Dim iRound As Long
        Dim iQtParenteses As Long
        'pega o cdbl(format(
        '    iRound = 0

        On Error GoTo Erro_Tratamento

        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "cdbl(format(", vbTextCompare)
            If iPosInicial > 0 Then
                iPosVirg1 = InStr(iPosInicial, sSQL, ",", vbTextCompare)
                iPosFinal = InStr(iPosVirg1 + 1, sSQL, "))", vbTextCompare)

                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "ROUND(" & Mid(sSQL, iPosInicial + 12, (iPosVirg1) - (iPosInicial + 11)) & "2) " & Mid(sSQL, iPosFinal + 2)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        'Mid
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "Mid(", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 4
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "SUBSTRING(" & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        'val
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "val(", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 4
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "CONVERT(INT," & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        'Time
        sSQL = Replace(sSQL, "Time()", "trim(convert(char(2), datepart(hh,date()))) + ':' + trim(convert(char(2), datepart(n,date()))) + ':' + trim(convert(char(2), datepart(s,date())))", , , vbTextCompare)
        '    bAchou = True
        '    Do While bAchou
        '        iPosInicial = InStr(1, sSQL, "Time()", vbTextCompare)
        '        If iPosInicial > 0 Then
        '            iPosFinal = iPosInicial + 6
        '            sSQL = Mid(sSQL, 1, iPosInicial - 1) & "trim(convert(char(2), datepart(hh,date()))) + ':' + trim(convert(char(2), datepart(n,date()))) + ':' + trim(convert(char(2), datepart(s,date())))" & Mid(sSQL, iPosFinal)
        '            bAchou = True
        '        Else
        '            bAchou = False
        '        End If
        '    Loop

        'date
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "date()", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 6
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "getdatt()" & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop
        sSQL = Replace(sSQL, "getdatt()", "getdate()", , , vbTextCompare)
        '    bAchou = True
        '    Do While bAchou
        '        iPosInicial = InStr(1, sSQL, "getdatt()", vbTextCompare)
        '        If iPosInicial > 0 Then
        '            iPosFinal = iPosInicial + 9
        '            sSQL = Mid(sSQL, 1, iPosInicial - 1) & "getdate()" & Mid(sSQL, iPosFinal)
        '            bAchou = True
        '        Else
        '            bAchou = False
        '        End If
        '    Loop

        'dateadd('h'
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "dateadd('h'", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 11
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "dateadd(hour" & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        'dateadd('n'
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "dateadd('n'", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 11
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "dateadd(minute" & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        'datediff('d'
        bAchou = True
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "datediff('d'", vbTextCompare)
            If iPosInicial > 0 Then
                iPosFinal = iPosInicial + 12
                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "datediff(day" & Mid(sSQL, iPosFinal)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop


        'trim
        bAchou = True
        iPosFinal = 1
        Do While bAchou
            iPosInicial = InStr(iPosFinal, sSQL, "trim(", vbTextCompare)
            If iPosInicial > 0 Then
                If UCase(Mid(sSQL, iPosInicial - 1, 5)) <> "RTRIM" Then
                    iPosFinal = iPosInicial + 5
                    If UCase(Mid(sSQL, iPosInicial - 1, 1)) <> "L" Then
                        sSQL = Mid(sSQL, 1, iPosInicial - 1) & "RTRIN(" & Mid(sSQL, iPosFinal)
                    End If
                    bAchou = True
                Else
                    bAchou = False
                End If
            Else
                bAchou = False
            End If
        Loop
        sSQL = Replace(sSQL, "RTRIN(", "RTRIM(", , , vbTextCompare)
        '    bAchou = True
        '    Do While bAchou
        '        iPosInicial = InStr(1, sSQL, "RTRIN(", vbTextCompare)
        '        If iPosInicial > 0 Then
        '            iPosFinal = iPosInicial + 6
        '            sSQL = Mid(sSQL, 1, iPosInicial - 1) & "RTRIM(" & Mid(sSQL, iPosFinal)
        '            bAchou = True
        '        Else
        '            bAchou = False
        '        End If
        '    Loop

        'iif
        bAchou = True
        iQtParenteses = 0
        Do While bAchou
            iPosInicial = InStr(1, sSQL, "iif(", vbTextCompare)
            If iPosInicial > 0 Then
                For iCont1 = iPosInicial + 4 To Len(sSQL)
                    If Mid(sSQL, iCont1, 1) = "(" Then
                        iQtParenteses = iQtParenteses + 1
                    End If
                    If Mid(sSQL, iCont1, 1) = ")" Then
                        iQtParenteses = iQtParenteses - 1
                    End If
                    If Mid(sSQL, iCont1, 1) = "," And iQtParenteses = 0 Then
                        iPosVirg1 = iCont1
                        Exit For
                    End If
                Next
                'iPosVirg1 = InStr(iPosInicial, sSql, ",", vbTextCompare)

                iQtParenteses = 0
                For iCont1 = iPosVirg1 + 1 To Len(sSQL)
                    If Mid(sSQL, iCont1, 1) = "(" Then
                        iQtParenteses = iQtParenteses + 1
                    End If
                    If Mid(sSQL, iCont1, 1) = ")" Then
                        iQtParenteses = iQtParenteses - 1
                    End If
                    If Mid(sSQL, iCont1, 1) = "," And iQtParenteses = 0 Then
                        iPosVirg2 = iCont1
                        Exit For
                    End If
                Next
                'iPosVirg2 = InStr(iPosVirg1 + 1, sSql, ",", vbTextCompare)

                iQtParenteses = 0
                For iCont1 = iPosVirg2 + 1 To Len(sSQL)
                    If Mid(sSQL, iCont1, 1) = ")" And iQtParenteses = 0 Then
                        iPosFinal = iCont1
                        Exit For
                    End If
                    If Mid(sSQL, iCont1, 1) = "(" Then
                        iQtParenteses = iQtParenteses + 1
                    End If
                    If Mid(sSQL, iCont1, 1) = ")" Then
                        iQtParenteses = iQtParenteses - 1
                    End If
                Next
                'iPosFinal = InStr(iPosVirg2 + 1, sSql, ")", vbTextCompare)

                sSQL = Mid(sSQL, 1, iPosInicial - 1) & "CASE WHEN " & Mid(sSQL, iPosInicial + 4, (iPosVirg1 - 1) - (iPosInicial + 3)) & " THEN " & Mid(sSQL, iPosVirg1 + 1, (iPosVirg2 - 1) - iPosVirg1) & " ELSE " & Mid(sSQL, iPosVirg2 + 1, (iPosFinal - 1) - iPosVirg2) & " END " & Mid(sSQL, iPosFinal + 1)
                bAchou = True
            Else
                bAchou = False
            End If
        Loop

        '#99/99/9999#  campo data do access p/ sql
        bAchou = True
        iPosAux1 = 1
        Do While bAchou
            iPosInicial = InStr(iPosAux1, sSQL, "#", vbTextCompare)
            If iPosInicial > 0 Then
                If Mid(sSQL, iPosInicial + 11, 1) = "#" And Mid(sSQL, iPosInicial + 3, 1) = "/" And Mid(sSQL, iPosInicial + 6, 1) = "/" And IsDate(Mid(sSQL, iPosInicial + 1, 10)) Then
                    sSQL = Mid(sSQL, 1, iPosInicial - 1) & "'" & Mid(sSQL, iPosInicial + 1, 10) & "'" & Mid(sSQL, iPosInicial + 12)
                ElseIf Mid(sSQL, iPosInicial + 20, 1) = "#" And Mid(sSQL, iPosInicial + 3, 1) = "/" And Mid(sSQL, iPosInicial + 6, 1) = "/" And IsDate(Mid(sSQL, iPosInicial + 1, 10)) Then
                    sSQL = Mid(sSQL, 1, iPosInicial - 1) & "'" & Mid(sSQL, iPosInicial + 1, 19) & "'" & Mid(sSQL, iPosInicial + 21)
                ElseIf Mid(sSQL, iPosInicial + 11, 1) = "#" And Mid(sSQL, iPosInicial + 3, 1) = "-" And Mid(sSQL, iPosInicial + 6, 1) = "-" And IsDate(Mid(sSQL, iPosInicial + 1, 10)) Then
                    sSQL = Mid(sSQL, 1, iPosInicial - 1) & "'" & Mid(sSQL, iPosInicial + 1, 10) & "'" & Mid(sSQL, iPosInicial + 12)
                ElseIf Mid(sSQL, iPosInicial + 20, 1) = "#" And Mid(sSQL, iPosInicial + 3, 1) = "-" And Mid(sSQL, iPosInicial + 6, 1) = "-" And IsDate(Mid(sSQL, iPosInicial + 1, 10)) Then
                    sSQL = Mid(sSQL, 1, iPosInicial - 1) & "'" & Mid(sSQL, iPosInicial + 1, 19) & "'" & Mid(sSQL, iPosInicial + 21)
                Else
                    iPosAux1 = iPosInicial + 1
                End If
                bAchou = True
            Else
                bAchou = False
            End If
        Loop



Exit_Procedure:
        AcertaSql = "-1"
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function

    Public Function TirarAspas(sTexto As Object)
        On Error GoTo err_TirarAspas

        Dim i As Long
        Dim sRetorno As String

        sRetorno = ""
        For i = 1 To Len(sTexto)
            If Mid(sTexto, i, 1) <> "'" And Mid(sTexto, i, 1) <> Chr(34) Then
                sRetorno = sRetorno & Mid(sTexto, i, 1)
            Else
                If Len(sTexto) <> i Then
                    If Mid(sTexto, i + 1, 1) <> " " Then
                        sRetorno = sRetorno & " "
                    End If
                End If
            End If
        Next i

        TirarAspas = sRetorno
        Exit Function
err_TirarAspas:
        TirarAspas = "-1"
    End Function

    Public Function Select_Table(sTabela As String, Optional sCampos As String = "", Optional sWhere As String = "", Optional sOrder As String = "", Optional bNaoColocaNolock As Boolean = True, Optional sGrupo As String = "")
        Dim sspName As String
        Dim iCont As Integer
        Dim dt_Inicio As Date
        Dim dt_Termino As Date

        'On Error GoTo err_Select_Table
        On Error GoTo Erro_Tratamento

        If IsNothing(sCampos) Or sCampos = "" Then
            sCampos = "*"
        End If
        If IsNothing(sWhere) Or sWhere = "" Then
            sWhere = ""
        End If
        If IsNothing(sOrder) Or sOrder = "" Then
            sOrder = ""
        End If
        If IsNothing(sGrupo) Or sGrupo = "" Then
            sGrupo = ""
        End If
        If IsNothing(bNaoColocaNolock) Then
            bNaoColocaNolock = False
        End If
        'If tp_BancoDados = Const_Interbase Or tp_BancoDados = Const_Oracle Then
        '    For iCont = 1 To Len(sCampos)
        '        If Mid(sCampos, iCont, 1) = "+" Then
        '            If Mid(sCampos, iCont + 1, 1) = "'" Or Mid(sCampos, iCont + 2, 1) = "'" Or Mid(sCampos, iCont - 1, 1) = "'" Or Mid(sCampos, iCont - 2, 1) = "'" Then
        '                sCampos = Mid(sCampos, 1, iCont - 1) & "||" & Mid(sCampos, iCont + 1)
        '            End If
        '        End If
        '    Next
        'End If

        'If bLockSomenteFrom Then
        ' If tp_BancoDados = Const_SqlServer Then
        sTabela = ColocarNolock("FROM FROM " & sTabela & " WHERE(")
        sTabela = Replace(sTabela, "FROM FROM ", "")
        sTabela = Replace(sTabela, " WHERE(", "")
        'End If
        'End If

        sspName = "SELECT " & sCampos & " FROM " & sTabela

        If Trim(sWhere) <> "" Then
            sspName = sspName & " WHERE " & sWhere
        End If
        If Trim(sGrupo) <> "" Then
            sspName = sspName & " GROUP BY " & sGrupo
        End If
        If Trim(sOrder) <> "" Then
            sspName = sspName & " ORDER BY " & sOrder
        End If

        'acerta o comando para o banco desejado

        'If tp_BancoDados = Const_Interbase Then
        '    sspName = UCase(sspName)
        '    Call AcertaInterbase(sspName)
        'End If
        'If tp_BancoDados = Const_SqlServer Then
        Call AcertaSql(sspName)
        If Not bNaoColocaNolock Then
            sspName = ColocarNolock(sspName)
        End If
        'End If
        'If tp_BancoDados = Const_Oracle Then
        '    Call AcertaOracle(sspName)
        'End If
        'If tp_BancoDados = Const_MySql Then
        '    Call AcertaSql(sspName)
        '    Call AcertaMySQL(sspName)
        'End If
        If InStr(1, UCase(sspName), "DELETE", vbTextCompare) > 0 Then
            GoTo Erro_Tratamento
        End If
        If InStr(1, UCase(sspName), "INSERT", vbTextCompare) > 0 Then
            GoTo Erro_Tratamento
        End If
        If InStr(1, UCase(sspName), "UPDATE", vbTextCompare) > 0 Then
            GoTo Erro_Tratamento
        End If
        If InStr(1, UCase(sspName), "DROP", vbTextCompare) > 0 Then
            GoTo Erro_Tratamento
        End If
        If InStr(1, UCase(sspName), "ALTER", vbTextCompare) > 0 Then
            GoTo Erro_Tratamento
        End If
        Select_Table = sspName

'err_Select_Table:
        'Select_Table = "-1"

Exit_Procedure:

        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then
            Select_Table = "-1"
            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If


    End Function

    Public Function Delete_Table(sTabela As String, Optional sWhere As String = "")
        Dim sspName As String
        Dim dt_Inicio As Date
        Dim dt_Termino As Date

        'On Error GoTo err_Delete_Table

        On Error GoTo Erro_Tratamento

        Delete_Table = 0
        If IsNothing(sWhere) Or sWhere = "" Then
            sWhere = ""
        End If

        sspName = "DELETE FROM " & sTabela
        If Trim(sWhere) <> "" Then
            sspName = sspName & " WHERE " & sWhere
        End If

        'acerta o comando para o banco desejado
        'If tp_BancoDados = Const_Interbase Then
        '    sspName = UCase(sspName)
        '    Call AcertaInterbase(sspName)
        'End If
        'If tp_BancoDados = Const_SqlServer Then
        Call AcertaSql(sspName)
        'End If
        'If tp_BancoDados = Const_Oracle Then
        '    Call AcertaOracle(sspName)
        'End If
        'If tp_BancoDados = Const_MySql Then
        '    Call AcertaSql(sspName)
        '    Call AcertaMySQL(sspName)
        'End If

  
        If Not fExecutarSql(sspName) Then
            GoTo Erro_Tratamento
        End If



        'err_Delete_Table:
        'Delete_Table = -1



Exit_Procedure:
        Delete_Table = -1
        'Sair do Procedimento
        Exit Function
Erro_Tratamento:
        If Err.Number <> 0 Then

            HttpContext.Current.Response.Redirect("~/404.html")
            Resume Exit_Procedure
        Else
            Resume Next
        End If

    End Function

    Public Function Update_Table(sTabela As String, sCampos As String, aConteudo As Object, sWhere As String, Optional bNaoTirarAspas As Boolean = False, Optional ByVal bPermiteIDZerado As Boolean = False, Optional ByVal sFrom As String = "", Optional ByVal bIgnoraConfiguracaoMaiusculo As Boolean = False)
        On Error GoTo err_Update_Table

        Dim i As Integer
        Dim ID As Long
        Dim iInicio As Integer
        Dim iFim As Integer
        Dim sspName As String
        Dim dt_Inicio As Date
        Dim dt_Termino As Date

        Update_Table = 0

err_Truncate:
        On Error GoTo err_Update_Table

        'Monta o SQL para alterar
        sspName = "UPDATE " & sTabela & " SET "

        iInicio = 1
        iFim = 0
        i = 0
        Do While iFim < Len(sCampos)
            iFim = InStr(iInicio, sCampos, ",")
            If iFim = 0 Then iFim = Len(sCampos) + 1
            sspName = sspName & Mid(sCampos, iInicio, iFim - iInicio)
            sspName = sspName & "="

            If VarType(aConteudo(i)) = vbString Then
                'If Mid(aConteudo(i), 1, 1) = "#" Then
                'If tp_BancoDados = Const_SqlServer Then
                sspName = sspName & Mid(aConteudo(i), 2)
                'Else
                '    sspName = sspName & Mid(aConteudo(i), 2)
                'End If
                If Not bNaoTirarAspas Then
                    sspName = sspName & "'" & TirarAspas(aConteudo(i)) & "'"
                Else
                    sspName = sspName & "'" & aConteudo(i) & "'"
                End If
                'End If
            ElseIf VarType(aConteudo(i)) = vbDate Then
                If aConteudo(i) = gdi.CDateEspecial("") Or aConteudo(i) = "00:00:00" Then
                    sspName = sspName & "Null"
                Else
                    sspName = sspName & gdi.ConverterData(aConteudo(i), "'")
                End If
            ElseIf UCase(Left(Trim(Mid(sCampos, iInicio, iFim - iInicio)), 3)) = "ID_" And aConteudo(i) = 0 And Not bPermiteIDZerado Then
                sspName = sspName & "Null"
            ElseIf VarType(aConteudo(i)) = vbCurrency Or VarType(aConteudo(i)) = vbDecimal _
                   Or VarType(aConteudo(i)) = vbDouble Or VarType(aConteudo(i)) = vbSingle Then
                sspName = sspName & Str(aConteudo(i))
            Else
                sspName = sspName & IIf(IsNothing(aConteudo(i)), "Null", aConteudo(i))
            End If
            If i < UBound(aConteudo, 1) Then
                sspName = sspName & ","
            End If

            iInicio = iFim + 1
            i = i + 1
        Loop
        'If bStatus Then
        '    If sspName <> "UPDATE " & sTabela & " SET " Then
        '        sspName = sspName & ","
        '    End If
        '    sspName = sspName & " ds_Alteracao = '" & sUsuario & "'+' - '+"
        '    'sspName = sspName & " ds_Alteracao = '" & sSistemaUsuario & "'+' - '+"
        '    If iSistemaBancoDados = Const_SqlServer Then
        '        sspName = sspName & " convert(char(11),CURRENT_TIMESTAMP,103) + convert(char(8),CURRENT_TIMESTAMP,108)"
        '    Else
        '        sspName = sspName & "'" & DataAtual(True, True) & "'"
        '    End If
        'End If
        If Trim(sWhere) <> "" Then
            sspName = sspName & " WHERE " & sWhere
        End If
        If Trim(sFrom) <> "" Then
            sspName = sspName & " FROM " & sFrom
        End If

        'acerta o comando para o banco desejado
        'If tp_BancoDados = Const_Interbase Then
        '    sspName = UCase(sspName)
        '    Call AcertaInterbase(sspName)
        'End If
        'If tp_BancoDados = Const_SqlServer Then
        Call AcertaSql(sspName)
        'End If
        'If tp_BancoDados = Const_Oracle Then
        '    Call AcertaOracle(sspName)
        'End If
        'If tp_BancoDados = Const_MySql Then
        '    Call AcertaSql(sspName)
        '    Call AcertaMySQL(sspName)
        'End If
        If Not bIgnoraConfiguracaoMaiusculo Then
            sspName = UCase(sspName)
        End If

        'dt_Inicio = Date & " " & Mid(Time, 1, 8)
        'Executa a inserção
        'If cConexao Is Nothing Then
        '    Call cnAdo.Execute(sspName)
        'Else
        '    Call cConexao.Execute(sspName)
        'End If
        If Not fExecutarSql(sspName) Then
            GoTo err_Update_Table
        End If
        'Insert no Log de transferencia
        'cm 19353 - acrescentado o tp_ConfigReplicaLogTransfer no comparativo abaixo
        '    If ((tp_ConfigReplicar = "S" And Not bNaoReplicar) Or tp_ConfigReplicaLogTransfer = "S") And UCase(Mid(sTabela, 1, 7)) <> "TBD_RPT" And UCase(Mid(sTabela, 1, 6)) <> "TBDREL" And UCase(Mid(sTabela, 1, 7)) <> "TBD_13_" Then
        '        If Not AtualizarLogTransferencia(sspName) Then
        '            GoTo err_Update_Table
        '        End If
        '    End If
        'dt_Termino = Date & " " & Mid(Time, 1, 8)

        '    If Not ValidarComando(dt_Inicio, dt_Termino, sspName) Then
        '        GoTo err_Update_Table
        '    End If

        Exit Function

err_Update_Table:
        Update_Table = -1
    End Function

    Public Function Insert_Table(sTabela As String, sCampos As String, Optional sNomeID_Tabela As String = "", Optional aConteudo As Object = Nothing, Optional sSelect As String = "", Optional bNaoTirarAspas As Boolean = False, Optional ByVal bStatus As Boolean = False, Optional ByVal bPermiteIDZerado As Boolean = True, Optional ByRef bSubIdSelect As Boolean = False, Optional ByVal bNaoExibirErro As Boolean = False) As Long
        On Error GoTo err_insert_table

        Dim i As Integer
        Dim ID As Long
        Dim bRet As Boolean
        Dim sWhere As String
        Dim bAchouID As Boolean
        Dim sspName As String
        Dim sNomeIDAux As String
        Dim aCampos As Object
        Dim iContErro As Integer
        Dim dt_Inicio As Date
        Dim dt_Termino As Date
        Dim sChavePrimaria As String
        Dim bStatusAdicionado As Boolean

        sNomeIDAux = sNomeID_Tabela
        iContErro = 0
        bStatusAdicionado = False

err_Truncate:
        sNomeID_Tabela = sNomeIDAux

        bRet = False
        Insert_Table = 0
        sWhere = ""
        aCampos = Split(sCampos, ",")
        'Pega o ID Max da Tabela
        If Trim(sNomeID_Tabela) <> "" Then
            sChavePrimaria = "SELECT MAX(" & sNomeID_Tabela & ") + 1 FROM " & sTabela
            ID = fRetornaID(sChavePrimaria)
            If ID = 0 Then
                ID = 1
            End If
            bRet = True
        End If
        'Monta o SQL para inserir
        If Trim(sNomeID_Tabela) <> "" Then
            sspName = "INSERT INTO " & sTabela & "(" & sNomeID_Tabela & "," & sCampos & ") "
        Else
            sspName = "INSERT INTO " & sTabela & "(" & sCampos & ") "
        End If
        If Not IsNothing(aConteudo) Then
            sspName = sspName & "VALUES("
            For i = 0 To UBound(aConteudo, 1)
                If Trim(sNomeID_Tabela) <> "" Then
                    sspName = sspName & ID & ","
                    sNomeID_Tabela = ""
                End If
                If VarType(aConteudo(i)) = vbString Then
                    If Mid(aConteudo(i), 1, 1) = "#" Then
                        'If tp_BancoDados = Const_SqlServer Then
                        sspName = sspName & "Round(" & Mid(aConteudo(i), 2) & ", 2)"
                        'Else
                        '    sspName = sspName & "CDBL(Format(" & Mid(aConteudo(i), 2) & "," & Chr(34) & "0.00" & Chr(34) & "))"
                        'End If
                    Else
                        If Not bNaoTirarAspas Then
                            sspName = sspName & "'" & TirarAspas(aConteudo(i)) & "'"
                        Else
                            sspName = sspName & "'" & aConteudo(i) & "'"
                        End If
                    End If
                ElseIf VarType(aConteudo(i)) = vbDate Then
                    'If tp_BancoDados = Const_Interbase Then
                    '    aConteudo(i) = Mid(aConteudo(i), 1, 10)
                    'End If
                    If aConteudo(i) = gdi.CDateEspecial("") Or aConteudo(i) = "00:00:00" Then
                        sspName = sspName & "Null"
                    Else
                        sspName = sspName & gdi.ConverterData(aConteudo(i), IIf(True, "'", ""))
                    End If
                ElseIf UCase(Left(Trim(aCampos(i)), 3)) = "ID_" And aConteudo(i) = 0 And Not bPermiteIDZerado Then
                    sspName = sspName & "Null"
                ElseIf VarType(aConteudo(i)) = vbCurrency Or VarType(aConteudo(i)) = vbDecimal _
                       Or VarType(aConteudo(i)) = vbDouble Or VarType(aConteudo(i)) = vbSingle Then
                    sspName = sspName & Str(aConteudo(i))
                ElseIf IsNothing(aConteudo(i)) Then
                    sspName = sspName & "Null"
                Else
                    sspName = sspName & aConteudo(i)
                End If
                If i < UBound(aConteudo, 1) Then
                    sspName = sspName & ","
                End If
            Next i
            'If bStatus Then
            '    'sspName = sspName & ", '" & sSistemaUsuario & "'+ ' - '+"
            '    sspName = sspName & ", '" & sUsuario & "'+ ' - '+"
            '    If iSistemaBancoDados = Const_SqlServer Then
            '        sspName = sspName & " convert(char(11),CURRENT_TIMESTAMP,103) + convert(char(8),CURRENT_TIMESTAMP,108)"
            '    Else
            '        sspName = sspName & "'" & DataAtual(True, True) & "'"
            '    End If

            '    'sspName = sspName & ", '" & sSistemaUsuario & "'+ ' - '+"
            '    sspName = sspName & ", '" & sUsuario & "'+ ' - '+"
            '    If iSistemaBancoDados = Const_SqlServer Then
            '        sspName = sspName & " convert(char(11),CURRENT_TIMESTAMP,103) + convert(char(8),CURRENT_TIMESTAMP,108)"
            '    Else
            '        sspName = sspName & "'" & DataAtual(True, True) & "'"
            '    End If
            'End If
            sspName = sspName & ")"
        Else
            'If bStatus Then
            '    'sSelect = sSelect & ", '" & sSistemaUsuario & "'+ ' - '+"
            '    sSelect = sSelect & ", '" & sUsuario & "'+ ' - '+"
            '    If iSistemaBancoDados = Const_SqlServer Then
            '        sSelect = sSelect & " convert(char(11),CURRENT_TIMESTAMP,103) + convert(char(8),CURRENT_TIMESTAMP,108)"
            '    Else
            '        sSelect = sSelect & "'" & ConverterData(DataAtual(True, True), "") & "'"
            '    End If

            '    sSelect = sSelect & ", '" & sUsuario & "'+ ' - '+"
            '    'sSelect = sSelect & ", '" & sSistemaUsuario & "'+ ' - '+"
            '    If iSistemaBancoDados = Const_SqlServer Then
            '        sSelect = sSelect & " convert(char(11),CURRENT_TIMESTAMP,103) + convert(char(8),CURRENT_TIMESTAMP,108)"
            '    Else
            '        sSelect = sSelect & "'" & ConverterData(DataAtual(True, True), "") & "'"
            '    End If
            'End If
            If Trim(sNomeID_Tabela) <> "" Then
                i = InStr(1, sSelect, " ", vbTextCompare)
                sSelect = Mid(sSelect, 1, i) & ID & "," & Mid(sSelect, i + 1)
                sNomeID_Tabela = ""
            End If

            sspName = sspName & sSelect
        End If

        'acerta o comando para o banco desejado
        'If tp_BancoDados = Const_Interbase Then
        '    sspName = UCase(sspName)
        '    Call AcertaInterbase(sspName)
        'End If
        'If tp_BancoDados = Const_SqlServer Then
        Call AcertaSql(sspName)
        'End If
        'If tp_BancoDados = Const_Oracle Then
        '    Call AcertaOracle(sspName)
        'End If
        'If tp_BancoDados = Const_MySql Then
        '    Call AcertaSql(sspName)
        '    Call AcertaMySQL(sspName)
        'End If
        'If tp_ConfigGravarDadosMaiusculo = "S" And Not bIgnoraConfiguracaoMaiusculo Then
        '    sspName = UCase(sspName)
        'End If

        'dt_Inicio = Date & " " & Mid(Time, 1, 8)
        '    'Executa a inserção
        '    If cConexao Is Nothing Then
        '        Call cnAdo.Execute(sspName)
        '    Else
        '        Call cConexao.Execute(sspName)
        '    End If
        If Not fExecutarSql(sspName) Then
            GoTo err_insert_table
        End If
        'Insert no log de transferencia
        'cm 19353 - acrescentado o tp_ConfigReplicaLogTransfer no comparativo abaixo
        'Retorna o ID
        If bRet Then
            Insert_Table = ID
        End If

        Exit Function
err_insert_table:
        Insert_Table = -1
    End Function

End Class

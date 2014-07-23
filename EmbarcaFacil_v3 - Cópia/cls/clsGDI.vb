﻿Imports System.Net.Mail
Imports System.Net
Imports System
Imports System.IO
Imports System.Security.Cryptography


Public Class clsGDI

    Public cnnDB As Object 'objeto SQL
    Public SQLcmd As Object 'Objeto executa string
    Public strErro As String
    Public bValida As Boolean
    Public sCPF As String
    Public sCNPJ As String
    Public Function fAutenticationUser(ByVal StringEmail As String) As Boolean


        'Iniciar procedimento com não executado com sucesso
        fAutenticationUser = False

        'Validar se existe estrutura SQL
        If Len(Trim(StringEmail)) = 0 Then Exit Function

        FormsAuthentication.Initialize()
        'Definimos quanto tempo o usuário irá permanecer logado após deixar o site sem efetuar o logout
        Dim fat As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, _
                                               StringEmail, DateTime.Now, _
                                               DateTime.Now.AddMinutes(30), False, StringEmail, _
                                               FormsAuthentication.FormsCookiePath)


        HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)))
        HttpContext.Current.Response.Redirect("~/index.aspx")

        'Retornar execução com sucesso
        fAutenticationUser = True




    End Function
    Function CarRemove(Texto As String) As String

        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+!@#$'%&*()+{`}^:?>/-._"
        Temp = Texto
        For i = 1 To Len(Remover)
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next
        CarRemove = Temp

    End Function
    Public Function fValidaCNPJ(ByVal CNPJ As String) As Boolean

        Dim i As Integer
        Dim valida As Boolean

        CNPJ = CNPJ.Trim

        For i = 0 To dadosArray.Length - 1
            If CNPJ.Length <> 18 Or dadosArray(i).Equals(CNPJ) Then
                Return False
            End If
        Next

        'remove a maskara
        CNPJ = CNPJ.Substring(0, 2) + CNPJ.Substring(3, 3) + CNPJ.Substring(7, 3) + CNPJ.Substring(11, 4) + CNPJ.Substring(16)
        valida = fefetivaValidacao(CNPJ)

        If valida Then
            fValidaCNPJ = True
        Else
            fValidaCNPJ = False
        End If

    End Function
    Public Function fefetivaValidacao(ByVal cnpj As String)
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        'Dim valida As Boolean
        Dim resultado1 As Integer
        Dim resultado2 As Integer

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next

        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Public dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                        "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
    Public Function fCriarCookies(intID As Integer, Str_Email As String, str_DescricaoUser As String) As Boolean

        fCriarCookies = False

        Dim Cookie As New HttpCookie("User")
        Cookie.HttpOnly = True
        Cookie.Values.Add("Email", Str_Email.ToString)
        Cookie.Values.Add("id", intID)
        Cookie.Values.Add("nome", str_DescricaoUser.ToString)

        Cookie.Expires.AddDays(5)
        HttpContext.Current.Response.AppendCookie(Cookie)

        fCriarCookies = True


    End Function
    Public Function fCriarLogErro(str_erro As String, _
                                  str_numErro As String, _
                                  str_procedimento As String, _
                                  str_dataErro As String) As Boolean

        fCriarLogErro = False
        Dim SQL As String
        Dim odb As New clsDB

        SQL = "INSERT INTO tbd_erro_temp( " +
                "str_erro, " +
                "str_numErro, " +
                "str_procedimento, " +
                "str_dataErro) " +
                "values ('" +
                        Replace(str_erro, "'", "_") + "', '" +
                        str_numErro + "', '" +
                        Replace(str_procedimento, "'", "") + "', '" +
                        str_dataErro + "')"
        If Not odb.fExecutarSql(SQL) Then Exit Function

        fCriarLogErro = True

    End Function

    Public Function fenviaMensagemEmail(ByVal Str_Destinatario As String, VerifyUrl As String) As Boolean

        'ENVIO DE EMAILS COM TEMPLATE EM HTML, O CAMPO <%VerifyUrl%> É UM CAMPO RESERVADO PARA HTML, ONDE DEVE CONTER A CHAVE 
        'PARA AUTENTICAÇÃO DO USUÁRIO

        Using reader As StreamReader = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("EmailTemplates\NewAccountTemplate.htm"))
            Dim SmtpServer As New SmtpClient("173.194.67.108", 587)

            SmtpServer.UseDefaultCredentials = False
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
            SmtpServer.Credentials = New System.Net.NetworkCredential("ricardo@gdinovacao.com.br", "telnet@123")
            'SmtpServer.Port = 587;.
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True
            Dim message = New MailMessage()
            'message.Body = 
            message.Subject = "Bem vindo ao Embarca Fácil"
            'message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = True
            'message.Body = "<%VerifyUrl%>"
            'message.BodyEncoding = System.Text.Encoding.UTF8;
            message.From = New MailAddress("ricardo@gdinovacao.com.br")
            message.[To].Add(Str_Destinatario)
            message.Priority = MailPriority.Normal
            message.Body = reader.ReadToEnd()
            message.Body = message.Body.Replace("<%VerifyUrl%>", VerifyUrl)
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            SmtpServer.Send(message)
            fenviaMensagemEmail = True
        End Using
    End Function
    Public Function Cifrar(ByVal vstrTextToBeEncrypted As String, ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ****** Descarta todos os caracteres nulos da palavra a ser cifrada****  
        '   **********************************************************************

        vstrTextToBeEncrypted = TiraCaracteresNulos(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  O valor deve estar dentro da tabela ASCII (i.e., no DBCS chars)
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   A chave cifrada será de 256 bits long (32 bytes)     ******
        '   ******   Se for maior que 32 bytes então será truncado.       ******
        '   ******   Se for menor que 32 bytes será alocado.              ******
        '   ******   Usando upper-case Xs.                                ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged

        '   ***********************************************************************
        '   ******  Cria o valor a ser crifrado e depois escreve             ******
        '   ******  Convertido em uma disposição do byte                     ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch

        End Try

        '   ***********************************************************************
        '   ****** Retorna o valor cifrado (convertido de byte para base64 )  *****
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    '   *********************************************************************
    '   ***** Função Responsável por Decifrar a sua String Cifrada       *****
    '   ***** Use da seguinte forma:                                    *****
    '   ***** Call Decifrar("Palavra", "SuaChaveSecreta(Ex.2345)")      *****
    '   *********************************************************************

    Public Function Decifrar(ByVal vstrStringToBeDecrypted As String, ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim intCtr As Integer
        Dim strReturnString As String = String.Empty
        Dim achrCharacterArray() As Char
        Dim intIndex As Integer

        '   *****************************************************************
        '   ******   Convert base64 cifrada para byte array            ******
        '   ******   Convert base64 cifrada para byte array            ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   A chave cifrada sera de 256 bits long (32 bytes)     ******
        '   ******   Se for maior que 32 bytes então será truncado.       ******
        '   ******   Se for menor que 32 bytes será alocado.              ******
        '   ******   Usando upper-case Xs.                                ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Escrever o valor decifrado depois que é convertido       ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   ***********************************************************************
        '   ******  Retorna o valor decifrado                                ******
        '   ***********************************************************************

        Return TiraCaracteresNulos(Encoding.ASCII.GetString(bytTemp))

    End Function

    '   *********************************************************************
    '   ***** Função responvel por tirar os espaços em branco da        *****
    '   ***** variável a ser cifrada                                    *****
    '   ***** Esta função é chamada internamente                        *****
    '   *********************************************************************

    Public Function TiraCaracteresNulos(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

    Public Function CryptPassword(Text As String) As String

        Dim strTempChar As String
        strTempChar = ""
        For i = 1 To Len(Text)

            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If

            Mid$(Text, i, 1) = Chr(strTempChar)

        Next i

        CryptPassword = Text

    End Function

End Class

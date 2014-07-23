Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        '' Fires when an error occurs
        Dim exc As Exception = Server.GetLastError

        If (exc.GetType Is GetType(HttpException)) Then

            If exc.Message.Contains("NoCatch") Then
                Return
            End If
            HttpContext.Current.Response.Redirect("~/404.html")
        End If


        ' ''Response.Write("<h2>Global Page Error</h2>" & vbLf)
        ' ''Response.Write("<p>" & exc.Message + "</p>" & vbLf)
        ' ''Response.Write(("Retorne para a página inicial <a href='index.html'>" _
        ' ''  & "Página principal</a>" & vbLf))

        ' '' ''ExceptionUtility.LogException(exc, "DefaultPage")
        ' '' ''ExceptionUtility.NotifySystemOps(exc)

        'HttpContext.Current.Response.Redirect("~/404.html")
        Server.ClearError()
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
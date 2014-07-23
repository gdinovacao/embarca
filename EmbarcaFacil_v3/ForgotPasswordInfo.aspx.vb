Public Class ForgotPasswordInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       


    End Sub
    Protected Sub txtlogin_Click(sender As Object, e As EventArgs) Handles txtlogin.Click

        HttpContext.Current.Response.Redirect("~/login.aspx")
    End Sub
End Class
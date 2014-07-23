Imports System.Data
Imports System.Data.SqlClient

Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Sub LogActivity(ByVal action As String)
        'Only proceed if the user is authenticated
        If Request.IsAuthenticated Then
            'Get information about the currently logged on user
            Dim usr As MembershipUser = Membership.GetUser
            If usr Is Nothing Then
                'Whoops, we don't know who this user is!
                Exit Sub
            End If

            'Read in the user's UserId value
            Dim UserId As Guid = CType(usr.ProviderUserKey, Guid)


            'Call the sproc_UpdateUsersCurrentActivity sproc
            Using myConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("MembershipConnectionString").ConnectionString)
                Dim myCommand As New SqlCommand("sproc_UpdateUsersCurrentActivity", myConnection)
                myCommand.CommandType = CommandType.StoredProcedure

                myCommand.Parameters.AddWithValue("@UserId", UserId)
                myCommand.Parameters.AddWithValue("@Action", action)
                myCommand.Parameters.AddWithValue("@CurrentTimeUtc", DateTime.UtcNow)

                'Execute the sproc
                myConnection.Open()
                myCommand.ExecuteNonQuery()
                myConnection.Close()
            End Using
        End If
    End Sub
End Class

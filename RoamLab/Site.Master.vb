Imports RoamLab.BLL.DTO

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim dataUser = CType(Session("UserData"), LoginUserDTO)
        lbProfile.Text = dataUser.FirstName & " " & dataUser.LastName
    End Sub

    Protected Sub ProfileClick(sender As Object, e As EventArgs)
        Response.Redirect("ProfilePage.aspx")
    End Sub
End Class
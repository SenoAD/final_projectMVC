Imports RoamLab.BLL
Imports RoamLab.BLL.DTO

Public Class RegisterPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RegisterButtonClick(sender As Object, e As EventArgs)
        Dim createUser As New UserBLL
        Dim newUser As New UserCreateDTO
        newUser.FirstName = tbFirstName.Text
        newUser.LastName = tbLastName.Text
        newUser.Location = tbLocation.Text
        newUser.Email = tbEmail.Text
        newUser.Username = tbUsername.Text
        newUser.Password = tbPassword.Text
        newUser.Repassword = tbRePassword.Text
        createUser.Insert(newUser)
        Response.Redirect("LoginPage.aspx")
    End Sub
End Class
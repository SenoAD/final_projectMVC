Imports RoamLab.BLL

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LoginClick(sender As Object, e As EventArgs)
        Dim loginUser As New UserBLL
        Session("UserData") = loginUser.Login(tbUsername.Text, tbPassword.Text)
        Response.Redirect("HomePage.aspx")
    End Sub
End Class
Imports RoamLab.BLL.DTO

Public Class ProfilePage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            Dim dataUser = CType(Session("UserData"), LoginUserDTO)
            tbFirstName.Text = dataUser.FirstName
            tbLastName.Text = dataUser.LastName
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

    End Sub
End Class
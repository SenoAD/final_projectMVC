Imports RoamLab.BLL

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbltes.Text = "Post Back"
        If Not Page.IsPostBack Then
            Dim _locationBLL As New LocationBLL
            Dim results = _locationBLL.GetAll
            ddLocation.DataSource = results
            ddLocation.DataTextField = "City"
            ddLocation.DataValueField = "LocationID"
            ddLocation.DataBind()
            lbltes.Text = "Bukan Post Back"
        End If

    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        lbltes2.Text = ddLocation.SelectedIndex.ToString
    End Sub

End Class
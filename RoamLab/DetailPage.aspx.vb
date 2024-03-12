Public Class DetailPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim placeID As String = Request.QueryString("PlaceID")
            ' Use placeID to retrieve place details from your data source
            ' Populate controls on the page with the retrieved details
        End If
    End Sub

End Class
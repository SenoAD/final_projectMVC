Imports Microsoft.Ajax.Utilities
Imports RoamLab.BLL
Imports RoamLab.BLL.DTO
Imports RoamLab.BLL.Interface

Public Class HomePage
    Inherits System.Web.UI.Page

    Sub LoadInitialData()
        Dim _locationBLL As New LocationBLL
        Dim results = _locationBLL.GetAll
        ddLocation.DataSource = results
        ddLocation.DataTextField = "City"
        ddLocation.DataValueField = "LocationID"
        ddLocation.DataBind()

        Dim _placeBLL As New PlaceBLL
        Dim place = _placeBLL.GetAll()
        gvPlace.DataSource = place
        gvPlace.DataBind()
    End Sub
    Sub LoadNewPlace()
        Dim _placeBLL As New PlaceBLL
        Dim selectedValue = ddLocation.SelectedValue
        Dim place = _placeBLL.GetPlaceByLocationID(CInt(selectedValue))
        gvPlace.DataSource = place
        gvPlace.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadInitialData()

        End If
    End Sub

    Protected Sub gvPlace_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvPlace.PageIndex = e.NewPageIndex
        LoadNewPlace()

    End Sub
    Private dataList As New List(Of PlanItemCartDTO)()

    Protected Sub ProductsGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "AddtoPlan" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim IDIndex = index - (gvPlace.PageIndex * gvPlace.PageSize)
            Dim row As GridViewRow = gvPlace.Rows(IDIndex)

            Dim PlaceID As String = gvPlace.DataKeys(IDIndex)("PlaceID").ToString()
            Dim Name As String = row.Cells(2).Text
            Dim textBox As TextBox = TryCast(row.FindControl("tbTanggal"), TextBox)

            Dim itemList As New List(Of PlanItemCartDTO)()
            For Each row2 As GridViewRow In gvPlanItem.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim rowData As New PlanItemCartDTO()
                    ' Assuming you have two columns 'Column1' and 'Column2', adjust accordingly
                    rowData.Name = row2.Cells(0).Text
                    rowData.Tanggal = row2.Cells(1).Text
                    rowData.PlaceID = Integer.Parse(row2.Cells(2).Text)
                    ' Access more columns if needed

                    itemList.Add(rowData)
                End If
            Next

            ' Access the value of the TextBox
            Dim item As New PlanItemCartDTO()
            item.Name = Name
            item.PlaceID = PlaceID
            item.Tanggal = textBox.Text

            itemList.Add(item)


            gvPlanItem.DataSource = itemList
            gvPlanItem.DataBind()
            ' Do something with the value
            ' For example, you can store it in a list or process it further
        End If
    End Sub

    Protected Sub SaveButton_Click(sender As Object, e As EventArgs)
        Dim planitemList As New List(Of InsertPlanItemDTO)()
        For Each row2 As GridViewRow In gvPlanItem.Rows
            Dim rowData As New InsertPlanItemDTO()
            ' Assuming you have two columns 'Column1' and 'Column2', adjust accordingly
            rowData.DatePlace = row2.Cells(1).Text
            rowData.PlaceID = Integer.Parse(row2.Cells(2).Text)
            ' Access more columns if needed

            planitemList.Add(rowData)
        Next
        Dim dataUser = CType(Session("UserData"), LoginUserDTO)
        Dim selectedValue = ddLocation.SelectedValue

        Dim planName = tbPlanName.Text
        Dim planDescription = tbDescription.Text
        Dim planUserID = dataUser.UserID
        Dim planDestinationLocationID = selectedValue

        Dim planVacation As New InsertVacationPlanDTO With
        {
        .UserID = planUserID,
        .Name = planName,
        .Description = planDescription,
        .DestinationLocationID = planDestinationLocationID,
        .PlanItems = planitemList
        }

        'For Each listtes As InsertPlanItemDTO In planVacation.PlanItems
        '    lbPlaceID2.Text = listtes.PlaceID
        '    lbDate2.Text = listtes.DatePlace
        'Next
        'lbNama.Text = planVacation.Name
        'lbUserID.Text = planVacation.UserID.ToString
        'lbDestinationLocationID.Text = planVacation.DestinationLocationID
        'lbDescription.Text = planVacation.Description
        Dim vacationPlanBLL As New VacationPlanBLL
        vacationPlanBLL.Insert(planVacation)
    End Sub

    Protected Sub ddLocation_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadNewPlace()
    End Sub
End Class

Imports RoamLab.BLL
Imports RoamLab.BLL.DTO

Public Class VacationPlan
    Inherits System.Web.UI.Page

    Sub LoadInitialData()
        Dim dataUser = CType(Session("UserData"), LoginUserDTO)
        Dim userID = dataUser.UserID
        Dim _vacationBLL As New VacationPlanBLL
        Dim vacationPlan = _vacationBLL.GetVacationPlanByUserID(userID)
        gvVacationPlan.DataSource = vacationPlan
        gvVacationPlan.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadInitialData()

        End If
    End Sub

    Protected Sub NewVP_Click(sender As Object, e As EventArgs)
        Response.Redirect("NewVacationPlan.aspx")
    End Sub
End Class
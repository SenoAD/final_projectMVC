<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VacationPlan.aspx.vb" Inherits="RoamLab.VacationPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">My Vacation Plan</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <asp:Button Text="New Vacation Plan" class="btn btn-primary" runat="server" OnClick="NewVP_Click" />
                <br />
                <asp:Label Text="List of Plan" runat="server" ID="lbltes" />
                <asp:GridView ID="gvVacationPlan" runat="server" DataKeyNames="PlanID" AutoGenerateColumns="False" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"  />
                        <asp:BoundField DataField="Description" HeaderText="Description"  />
                        <asp:BoundField DataField="DestinationLocationID" HeaderText="Destination Location"  />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date of Creation"  />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>

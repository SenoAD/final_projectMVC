<%@ Page Title="" Language="vb" EnableSessionState="true" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NewVacationPlan.aspx.vb" Inherits="RoamLab.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">New Vacation Plan</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <asp:Label runat="server" Text="Plan Name:"></asp:Label>
                <asp:TextBox ID="tbPlanName" runat="server"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Description:"></asp:Label>
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
                <br />
                <asp:Label Text="List of Location" runat="server" ID="lbl1" />
                <asp:DropDownList ID="ddLocation" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddLocation_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:Label Text="List of Place" runat="server" ID="lbltes" />
                <asp:GridView ID="gvPlace" runat="server" DataKeyNames="PlaceID" AutoGenerateColumns="False" CssClass="table table-hover" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvPlace_PageIndexChanging" OnRowCommand="ProductsGridView_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="PlaceID" HeaderText="PlaceID" Visible="false" />
                        <asp:ImageField DataImageUrlField="Preview" HeaderText="Preview" ControlStyle-Width="100" ControlStyle-Height="100" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:TemplateField HeaderText="Review">
                            <ItemTemplate>
                                <asp:Label ID="tes" Text="Stars" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink Text="Details" runat="server" NavigateUrl='<%# "DetailPage.aspx?PlaceID=" + Eval("PlaceID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbTanggal" Text="Enter Vacation Date" runat="server" />
                                <asp:TextBox runat="server" ID="tbTanggal" PlaceHolder="Ex : 2024-01-01" />
                                <asp:Button Text="Add to Plan" runat="server" class="btn btn-primary" CommandName="AddtoPlan" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label runat="server" Text="My Plan Item : "></asp:Label>
                <asp:GridView ID="gvPlanItem" DataKeyNames="PlaceID" runat="server" AutoGenerateColumns="False" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Tanggal" HeaderText="Date" />
                         <asp:BoundField DataField="PlaceID" HeaderText="PlaceID"/>
                    </Columns>
                </asp:GridView>
         <%--       <asp:Label ID="lbNama" Text="text" runat="server" />
                <asp:Label ID="lbDescription" Text="text" runat="server" />
                <asp:Label ID="lbUserID" Text="text" runat="server" />
                <asp:Label ID="lbDestinationLocationID" Text="text" runat="server" />
                <asp:Label ID="lbPlaceID1" Text="text" runat="server" />
                <asp:Label ID="lbPlaceID2" Text="text" runat="server" />
                <asp:Label ID="lbDate1" Text="text" runat="server" />
                <asp:Label ID="lbDate2" Text="text" runat="server" />--%>
                <asp:Button ID="SaveButton" Text="Save" class="btn btn-primary" runat="server" OnClick="SaveButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>

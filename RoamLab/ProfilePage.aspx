<%@ Page Title="" Language="vb" EnableSessionState="true" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProfilePage.aspx.vb" Inherits="RoamLab.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">User Profile</h1>
            <asp:Image ImageUrl="" runat="server" class="img-profile p-4" Width="100px" Height="100px" />
        </div>
        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow p-lg-2">
                <asp:Label runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                <br />
                <asp:Label  runat="server" Text="Location:"></asp:Label>
                <asp:TextBox ID="tbLocation" runat="server"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Bio:"></asp:Label>
                <asp:TextBox ID="tbBio" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox>
                <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClick="btnUpdate_Click" />

            </div>
        </div>
</asp:Content>

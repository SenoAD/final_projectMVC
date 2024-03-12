<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.vb" Inherits="TesDropDown.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList runat="server" ID="ddLocation">
    </asp:DropDownList>
    <asp:Button Text="text" runat="server" OnClick="Unnamed_Click" />
    <asp:Label Text="text" runat="server" ID="lbltes" />
    <asp:Label Text="text" runat="server" ID="lbltes2" />
</asp:Content>

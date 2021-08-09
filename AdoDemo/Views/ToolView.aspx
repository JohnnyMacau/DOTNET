<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToolView.aspx.cs" Inherits="AdoDemo.Views.ToolView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script runat="server">

</script>
    <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlclass_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:DropDownList ID="ddlstudent" runat="server">
    </asp:DropDownList>


    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewStudent.aspx.cs" Inherits="WebDemo.Views.AddNewStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr><td>姓名</td><td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="姓名!" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
        <tr><td>地址</td><td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="地址!" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator></td></tr></td></tr>
        <tr><td>班级</td><td>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请选择班级" ControlToValidate="DropDownList1" ForeColor="Red" ValidationExpression="(^\d*[1-9]\d*$)"></asp:RegularExpressionValidator>
            </td></tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" CausesValidation="False" />
</asp:Content>

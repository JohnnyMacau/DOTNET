<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassStudents.aspx.cs" Inherits="WebDemo.Views.ClassStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>

</style>
            <asp:ListView ID="studentList" runat="server" 
                DataKeyNames="StudentID" GroupItemCount="4"
                ItemType="WebDemo.Models.Student" SelectMethod="GetClassStudents1">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                   <%#:Item.StudentID%>
                                </td>
                                <td>
                                   <%#:Item.StudentName%>
                                </td>
                                <td>
                                   <%#:Item.Address%>
                                </td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>




</asp:Content>

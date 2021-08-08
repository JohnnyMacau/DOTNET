<%@ Page Title="欢迎" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WingtipToys._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.6.0.js"></script>
     <script>
         $().ready(function () {
             //alert('hello!');
         });

     </script>
       <style>
       h1{
           color:crimson;
       }
</style>
        <h1><%: Title %>.</h1>
        <h2>Wingtip Toys can help you find the perfect gift.</h2>
        <p class="lead">We're all about transportation toys. You can order 
                any of our toys today. Each toy listing has detailed 
                information to help you choose the right toy.</p>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>

<ul>
<li><a href="EntityDataSource.aspx">Products using EntityDataSource</a></li>
<li><a href="Repository.aspx">Customers using a Repository</a></li>
<li><%: Html.ActionLink("Customers with MVC", "Index", "Customers")%></li>
</ul>

</asp:Content>

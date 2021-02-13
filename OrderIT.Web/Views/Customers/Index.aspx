<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OrderIT.Model.Customer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Customers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Customers</h2>

	<table width="100%">
	<tr>
		<td>Name</td>
		<td>Username</td>
		<td>Shipping Address</td>
	</tr>
	<%foreach (var item in Model) {%>
		<tr>
			<td><%:Html.DisplayTextFor(x=> item.Name) %></td>
			<td><%:Html.DisplayTextFor(x=> item.WSUserName) %></td>
			<td><%:Html.DisplayTextFor(x=> item.ShippingAddress) %></td>
		</tr>
	<%} %>
	</table>

</asp:Content>
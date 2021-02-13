<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityDataSource.aspx.cs" Inherits="OrderIT.Web._EntityDataSource" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OrderIT</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<asp:ListView ID="ListView1" runat="server" DataKeyNames="ProductId" 
			DataSourceID="EntityDataSource1">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" 
                            Text='<%# Eval("Description") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BrandLabel" runat="server" Text='<%# Eval("Brand") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AvailableItemsLabel" runat="server" 
                            Text='<%# Eval("AvailableItems") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReorderLevelLabel" runat="server" 
                            Text='<%# Eval("ReorderLevel") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SuppliersLabel" runat="server" Text='<%# Eval("Suppliers") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="ProductIdLabel1" runat="server" 
                            Text='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DescriptionTextBox" runat="server" 
                            Text='<%# Bind("Description") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AvailableItemsTextBox" runat="server" 
                            Text='<%# Bind("AvailableItems") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReorderLevelTextBox" runat="server" 
                            Text='<%# Bind("ReorderLevel") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="SuppliersTextBox" runat="server" 
                            Text='<%# Bind("Suppliers") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="ProductIdTextBox" runat="server" 
                            Text='<%# Bind("ProductId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DescriptionTextBox" runat="server" 
                            Text='<%# Bind("Description") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BrandTextBox" runat="server" Text='<%# Bind("Brand") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AvailableItemsTextBox" runat="server" 
                            Text='<%# Bind("AvailableItems") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReorderLevelTextBox" runat="server" 
                            Text='<%# Bind("ReorderLevel") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="SuppliersTextBox" runat="server" 
                            Text='<%# Bind("Suppliers") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" 
                            Text='<%# Eval("Description") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BrandLabel" runat="server" Text='<%# Eval("Brand") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AvailableItemsLabel" runat="server" 
                            Text='<%# Eval("AvailableItems") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReorderLevelLabel" runat="server" 
                            Text='<%# Eval("ReorderLevel") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SuppliersLabel" runat="server" Text='<%# Eval("Suppliers") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">
                                        ProductId</th>
                                    <th runat="server">
                                        Name</th>
                                    <th runat="server">
                                        Description</th>
                                    <th runat="server">
                                        Brand</th>
                                    <th runat="server">
                                        Price</th>
                                    <th runat="server">
                                        AvailableItems</th>
                                    <th runat="server">
                                        ReorderLevel</th>
                                    <th runat="server">
                                        Suppliers</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" 
                            Text='<%# Eval("Description") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BrandLabel" runat="server" Text='<%# Eval("Brand") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AvailableItemsLabel" runat="server" 
                            Text='<%# Eval("AvailableItems") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReorderLevelLabel" runat="server" 
                            Text='<%# Eval("ReorderLevel") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SuppliersLabel" runat="server" Text='<%# Eval("Suppliers") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
		</asp:ListView>
    
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=OrderITEntities" DefaultContainerName="OrderITEntities" 
            EnableFlattening="False" EntitySetName="Products">
        </asp:EntityDataSource>
    
    </div>
    </form>
</body>
</html>

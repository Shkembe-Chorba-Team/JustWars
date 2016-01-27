<%@ Page Title="Administrate Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="JustWars.Web.Admin.Items" %>

<asp:Content ID="AdminItemsContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <asp:GridView runat="server" ID="GridViewItems" ItemType="JustWars.Web.Models.Item" SelectMethod="GridViewItems_GetData" UpdateMethod="GridViewItems_UpdateItem" DeleteMethod="GridViewItems_DeleteItem" AllowSorting="True" AllowPaging="True" PageSize="5" AutoGenerateColumns="false" DataKeyNames="Id">
                    <Columns>
                        <asp:DynamicField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:DynamicField DataField="Strength" HeaderText="Strength" SortExpression="Strength" />
                        <asp:DynamicField DataField="Defence" HeaderText="Defence" SortExpression="Defence" />
                        <asp:DynamicField DataField="Stamina" HeaderText="Stamina" SortExpression="Stamina" />
                        <asp:DynamicField DataField="Agility" HeaderText="Agility" SortExpression="Agility" />
                        <asp:DynamicField DataField="Charisma" HeaderText="Charisma" SortExpression="Charisma" />
                        <asp:CommandField HeaderText="Actions" ShowEditButton="true" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
                <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

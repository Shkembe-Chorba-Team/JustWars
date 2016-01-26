<%@ Page Title="Administrate Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="JustWars.Web.Admin.Users" %>

<asp:Content ID="AdminUsersContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:GridView runat="server" ID="GridViewUsers" ItemType="JustWars.Web.Models.User" SelectMethod="GridViewUsers_GetData" UpdateMethod="GridViewUsers_UpdateItem" DeleteMethod="GridViewUsers_DeleteItem" AllowSorting="True" AllowPaging="True" PageSize="5" AutoGenerateColumns="false" DataKeyNames="Id">
            <Columns>
                <asp:DynamicField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:DynamicField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:DynamicField DataField="Gold" HeaderText="Gold" SortExpression="Gold" />
                <asp:DynamicField DataField="Color" HeaderText="Color" SortExpression="Color" />
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
</asp:Content>

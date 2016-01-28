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
                        <asp:DynamicField DataField="Gold" HeaderText="Gold" SortExpression="Gold" />
                        <asp:CommandField HeaderText="Actions" ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
                <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row container">
        <fieldset>
            <legend>Add new item</legend>
            <div class="col-lg-12 centered">
                <div class="col-md-2">
                    Name
                            <asp:TextBox ID="AddItemName" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Strength
                            <asp:TextBox ID="AddItemStrength" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Defence
                            <asp:TextBox ID="AddItemDefense" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Stamina
                            <asp:TextBox ID="AddItemStamina" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Agility
                            <asp:TextBox ID="AddItemAgility" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Charisma
                            <asp:TextBox ID="AddItemCharisma" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    Gold Cost
                            <asp:TextBox ID="AddItemGold" runat="server" CssClass="item-add-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    Picture
                                <asp:FileUpload ID="FileUploadControl" runat="server" />
                </div>
            </div>
            <div class="row pull-right">
                <div>
                    <asp:Button ID="AddItemButton" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddItemButton_Click" />
                </div>
            </div>
        </fieldset>
    </div>
    <br />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="JustWars.Web.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Shop</h1>
    <h3>Your gold is  <strong id="gold" runat="server"></strong></h3>
    <h3 id="error" runat="server" visible="false">You don't have enough gold!</h3>
    <asp:GridView runat="server" ID="ShopItemsGrid"
        AllowPaging="true"
        PageSize="10"
        ItemType="JustWars.Web.Models.Item" DataKeyNames="Id"
        AllowSorting="true"
        AutoGenerateColumns="false"
        OnPageIndexChanging="ShopItemsGrid_PageIndexChanging"
        OnSorting="ShopItemsGrid_Sorting"
        CssClass="col-md-9">
        <Columns>
            <asp:DynamicField DataField="Name" />
            <asp:DynamicField DataField="Strength" />
            <asp:DynamicField DataField="Defence" />
            <asp:DynamicField DataField="Stamina" />
            <asp:DynamicField DataField="Agility" />
            <asp:DynamicField DataField="Charisma" />
            <asp:DynamicField DataField="Gold" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ShowUserButton" runat="server"
                        Text="Buy" OnCommand="BuyItem" CommandArgument="<%# Item.Id %>" CssClass="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

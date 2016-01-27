<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="JustWars.Web.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>Shop</h1>
            <h4>Your gold is  <strong id="gold" runat="server"></strong></h4>
            <h3 id="success" runat="server" class="text-success" visible="false"></h3>
            <h3 id="error" runat="server" class="text-danger" visible="false"></h3>
            <div class="row">
                <asp:GridView runat="server" ID="ShopItemsGrid"
                    AllowPaging="true"
                    PageSize="10"
                    ItemType="JustWars.Web.Models.Item"
                    DataKeyNames="Id"
                    AllowSorting="true"
                    AutoGenerateColumns="false"
                    SelectMethod="GridViewItems_GetData"
                    CssClass="col-md-12">
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
                                <asp:Button ID="BuyItemButton" runat="server"
                                    Text="Buy" OnCommand="BuyItem" CommandArgument="<%# Item.Id %>" CssClass="btn btn-success" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

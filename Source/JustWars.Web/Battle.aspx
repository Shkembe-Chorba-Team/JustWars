<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Battle.aspx.cs" Inherits="JustWars.Web.Battle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Battle</h1>
    <asp:GridView runat="server" ID="usersGrid"
        AllowPaging="true"
        PageSize="10"
        ItemType="JustWars.Web.Models.User" DataKeyNames="Id"
        AllowSorting="true"
        AutoGenerateColumns="false"
        OnPageIndexChanging="UsersGrid_PageIndexChanging"
        OnSorting="UsersGrid_Sorting"
        CssClass="col-md-9">
        <Columns>
            <asp:DynamicField DataField="Id" Visible="false" />
            <asp:DynamicField DataField="UserName" HeaderText="Username" />
            <asp:DynamicField DataField="Wins" />
            <asp:DynamicField DataField="Losses" />
            <asp:DynamicField DataField="Color" />
            <asp:DynamicField DataField="Strength" />
            <asp:DynamicField DataField="Defence" />
            <asp:DynamicField DataField="Stamina" />
            <asp:DynamicField DataField="Agility" />
            <asp:DynamicField DataField="Charisma" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ShowUserButton" runat="server"
                        Text="View" OnClick="ShowUser" CssClass="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="pull-left col-md-3" runat="server" visible="false" id="ShowUserField">
        <h1 id="UserName" runat="server"></h1>
        <div class="container">
            <div class="row">
                <div class="col-sm-2">
                    Strength:
                </div>
                <div class="col-sm-1">
                    <asp:Label ID="Strength" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Defence:
                </div>
                <div class="col-sm-1">
                    <asp:Label ID="Defence" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Agility:
                </div>
                <div class="col-sm-1">
                    <asp:Label ID="Agility" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Stamina:
                </div>
                <div class="col-sm-1">
                    <asp:Label ID="Stamina" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Charisma:
                </div>
                <div class="col-sm-1">
                    <asp:Label ID="Charisma" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Battle.aspx.cs" Inherits="JustWars.Web.Battle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Battle</h1>
    <div class="row">
        <asp:GridView runat="server" ID="usersGrid"
            AllowPaging="true"
            PageSize="10"
            ItemType="JustWars.Web.Models.User" DataKeyNames="Id"
            AllowSorting="true"
            AutoGenerateColumns="false"
            OnPageIndexChanging="UsersGrid_PageIndexChanging"
            OnSorting="UsersGrid_Sorting"
            CssClass="col-md-8">
            <Columns>
                <asp:DynamicField DataField="Id" Visible="false" />
                <asp:DynamicField DataField="UserName" HeaderText="Username" />
                <asp:DynamicField DataField="Wins" />
                <asp:DynamicField DataField="Losses" />
                <asp:DynamicField DataField="Color" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ShowUserButton" runat="server"
                            Text="View" OnCommand="ShowUser" CommandArgument="<%# Item.Id %>" CssClass="btn btn-success" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="col-md-4" runat="server" visible="false" id="ShowUserField">
            <h3 id="UserName" runat="server"></h3>
            <div class="hidden"><asp:Label ID="Id" runat="server"></asp:Label></div>
                <div class="row">
                    <div class="col-sm-6">
                        Strength:
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="Strength" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Defence:
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="Defence" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Agility:
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="Agility" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Stamina:
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="Stamina" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Charisma:
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="Charisma" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:Button ID="FightUserButton" runat="server"
                    Text="Fight" OnClick="FightUser" CssClass="btn btn-danger pull-right" />
            </div>
    </div>
</asp:Content>

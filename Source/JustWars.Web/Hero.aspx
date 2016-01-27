<%@ Page Title="Hero" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hero.aspx.cs" Inherits="JustWars.Web.Hero" %>

<asp:Content ID="HeroContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="UserName" runat="server"></h1>
    <h3 id="error" runat="server" visible="false" class="text-danger">You don't have enough gold!</h3>

    <div class="container">
        <div class="row">
            <div class="col-sm-2">
                Strength:
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Strength" runat="server"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Button runat="server" CssClass="btn btn-success" Text="+" OnCommand="UpdateStat" CommandArgument="Strength" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                Defence:
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Defence" runat="server"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Button runat="server" CssClass="btn btn-success" Text="+" OnCommand="UpdateStat" CommandArgument="Defence" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                Agility:
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Agility" runat="server"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Button runat="server" CssClass="btn btn-success" Text="+" OnCommand="UpdateStat" CommandArgument="Agility" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                Stamina:
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Stamina" runat="server"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Button runat="server" CssClass="btn btn-success"  Text="+" OnCommand="UpdateStat" CommandArgument="Stamina" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                Charisma:
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Charisma" runat="server"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Button runat="server" CssClass="btn btn-success" Text="+" OnCommand="UpdateStat" CommandArgument="Charisma" />
            </div>
        </div>        
        <br />
        <div class="row">
            <div class="col-sm-2">
                Next Stat Price:
            </div>
            <div class="col-sm-10">
                <asp:Label ID="NextStatPrice" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-2">
                Gold:
            </div>
            <div class="col-sm-10">
                <asp:Label ID="Gold" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>


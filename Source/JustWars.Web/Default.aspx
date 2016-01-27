<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JustWars.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron centered">
        <h1>JustWars</h1>
        <p class="lead"><em>May the <strong>--force</strong> be with you!</em></p>
    </div>
    <div class="row">
        <div class="col-md-4 text-center">
            <div>
                <strong>Items</strong>
            </div>
            <div>
                <asp:Label ID="ItemsNumber" runat="server"></asp:Label>
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div>
                <strong>Battles</strong>
            </div>
            <div>
                <asp:Label ID="BattlesNumber" runat="server"></asp:Label>
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div>
                <strong>Users</strong>
            </div>
            <div>
                <asp:Label ID="UsersNumber" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JustWars.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron centered">
        <h1>JustWars</h1>
        <p class="lead"><em>May the <strong>--force</strong> be with you!</em></p>
    </div>
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2 class="panel-title white-text centered">How many?</h2>
        </div>
        <div class="panel-body">
            <table class="table table-bordered">
                <tr>
                    <th class="col-md-6 centered" >Users</th>
                    <th class="col-md-6 centered">Battles</th>
                </tr>
                <tr>
                    <td id="UsersNumber" runat="server" class="col-md-6 centered"></td>
                    <td id="BattlesNumber" runat="server" class="col-md-6 centered"></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

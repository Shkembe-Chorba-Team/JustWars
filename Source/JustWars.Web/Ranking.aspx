<%@ Page Title="Ranking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="JustWars.Web.Ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>Ranking</h1>
            <div class="row">
                <div class="panel panel-info centered">
                    <div class="panel-heading">
                        Top Five Users
                    </div>
                    <div class="panel-body">
                        <asp:GridView CssClass="col-md-12" runat="server" ID="GridViewUsers" ItemType="JustWars.Web.Models.User" SelectMethod="GridViewUsers_GetData" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="false" DataKeyNames="Id">
                            <Columns>
                                <asp:DynamicField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                <asp:DynamicField DataField="Wins" HeaderText="Wins" SortExpression="Wins" />
                                <asp:DynamicField DataField="Losses" HeaderText="Losses" SortExpression="Losses" />
                                <asp:DynamicField DataField="Gold" HeaderText="Gold" SortExpression="Gold" />
                                <asp:DynamicField DataField="Color" HeaderText="Color" SortExpression="Color" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

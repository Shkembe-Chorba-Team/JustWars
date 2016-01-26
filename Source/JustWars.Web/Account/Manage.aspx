﻿<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="JustWars.Web.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-error"><%: ErrorMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Email: </dt>
                    <dd>
                        <asp:TextBox ID="UserEmail" ValidationGroup="accountInfo" runat="server"></asp:TextBox>
                    </dd>
                    <br />
                    <!--First Name-->
                    <dt>First Name: </dt>
                    <dd>
                        <asp:TextBox ID="UserFirstName" runat="server"></asp:TextBox>
                    </dd>
                    <br />
                    <!--Last Name-->
                    <dt>Last Name: </dt>
                    <dd>
                        <asp:TextBox ID="UserLastName" runat="server"></asp:TextBox>
                    </dd>
                    <br />
                    <!--Last Name-->

                    <%--<dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>--%>
                    <dd>
                        <asp:Button ID="SaveChanges" CssClass="btn btn-primary" runat="server" Text="Save Changes" CausesValidation="true" ValidationGroup="accountInfo" OnClick="SaveChanges_Click" />
                    </dd>
                    <br />
                    <dd>
                        <asp:HyperLink CssClass="btn btn-primary" NavigateUrl="/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>

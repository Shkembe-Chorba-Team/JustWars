using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using JustWars.Web.Models;
using System.Web.UI.WebControls;

namespace JustWars.Web.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!(String.IsNullOrEmpty(Password.Text.Trim())))
                {
                    Password.Attributes["value"] = Password.Text;
                    //or txtPwd.Attributes.Add("value",txtPwd.Text);
                }
                if (!(String.IsNullOrEmpty(ConfirmPassword.Text.Trim())))
                {
                    ConfirmPassword.Attributes["value"] = ConfirmPassword.Text;
                    //or txtConfirmPwd.Attributes.Add("value", txtConfirmPwd.Text);
                }
                return;
            }

            var itemValues = Enum.GetValues(typeof(Color));

            foreach (var value in itemValues)
            {
                var name = Enum.GetName(typeof(Color), value);
                TeamColor.Items.Add(new ListItem(name, value.ToString()));
            }
        }

        protected void LoadImage(object sender, EventArgs e)
        {
            Color choice;
            if (!Enum.TryParse<Color>(TeamColor.SelectedValue, out choice))
            {
                return;
            }

            BannerPreview.ImageUrl = GetImagePath(choice);
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            Color color = Color.Green;
            Color choice;
            if (Enum.TryParse<Color>(TeamColor.SelectedValue, out choice))
            {
                color = (Color)choice;
            }

            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text, Color = color };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private string GetImagePath(Color color)
        {
            return @"/Content/imgs/" + color.ToString() + "Ninja.png";
        }
    }
}
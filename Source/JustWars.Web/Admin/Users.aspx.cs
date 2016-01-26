using JustWars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustWars.Web.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        public JustWarsDbContext dbContext;

        public Users()
        {
            this.dbContext = new JustWarsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<User> GridViewUsers_GetData()
        {
            return this.dbContext.Users.OrderBy(b => b.UserName);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewUsers_UpdateItem(string id)
        {
            var item = this.dbContext.Users.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewUsers_DeleteItem(string id)
        {
            var item = this.dbContext.Users.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.dbContext.Users.Remove(item);
            this.dbContext.SaveChanges();
        }

        public void FormViewIsertUser_InsertItem()
        {
            var item = new User();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.Users.Add(item);
                this.dbContext.SaveChanges();
            }
        }

        /*
        public IEnumerable<Color> DropDownListColorsCreate_GetData()
        {
            return Enum.GetValues(typeof(Color));
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.btnWrapper.Visible = false;

            var fv = this.UpdatePanelInsertBook.FindControl("FormViewIsertBook") as FormView;
            fv.Visible = true;
        }*/
    }
}
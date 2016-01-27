using JustWars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustWars.Web.Admin
{
    public partial class Items : System.Web.UI.Page
    {
        public JustWarsDbContext dbContext;

        public Items()
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
        public IQueryable<Item> GridViewItems_GetData()
        {
            return this.dbContext.Items.OrderBy(b => b.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewItems_UpdateItem(string id)
        {
            var item = this.dbContext.Items.Find(id);
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
        public void GridViewItems_DeleteItem(string id)
        {
            var item = this.dbContext.Items.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.dbContext.Items.Remove(item);
            this.dbContext.SaveChanges();
        }

        public void FormViewIsertItem_InsertItem()
        {
            var item = new Item();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.Items.Add(item);
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
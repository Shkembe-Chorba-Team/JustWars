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
        public void GridViewItems_UpdateItem(int id)
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
        public void GridViewItems_DeleteItem(int id)
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
            var itemName = this.AddItemName.Text;
            // This will either get the value or set it to 0.
            var itemStrength = 0;
            var hasSetStrength = int.TryParse(this.AddItemStrength.Text, out itemStrength);
            var itemDefense = 0;
            var hasSetDefense = int.TryParse(this.AddItemDefense.Text, out itemDefense);
            var itemStamina = 0;
            var hasSetStamina = int.TryParse(this.AddItemStamina.Text, out itemStamina);
            var itemAgility = 0;
            var hasSetAgility = int.TryParse(this.AddItemAgility.Text, out itemAgility);
            var itemCharisma = 0;
            var hasSetCharisma = int.TryParse(this.AddItemCharisma.Text, out itemCharisma);
            var itemGold = (itemStrength + itemDefense + itemStamina + itemAgility + itemCharisma + 5) * 55;
            var hasSetGold = int.TryParse(this.AddItemGold.Text, out itemGold);

            var itemToAdd = new Item()
            {
                Name = itemName,
                Gold = itemGold,
                Strength = itemStrength,
                Defence = itemDefense,
                Stamina = itemStamina,
                Agility = itemAgility,
                Charisma = itemCharisma,
            };

            TryUpdateModel(itemToAdd);
            if (ModelState.IsValid)
            {
                this.dbContext.Items.Add(itemToAdd);
                this.dbContext.SaveChanges();
            }
        }

        protected void AddItemButton_Click(object sender, EventArgs e)
        {
            var itemName = this.AddItemName.Text;
            // This will either get the value or set it to 0.
            var itemStrength = 0;
            var hasSetStrength = int.TryParse(this.AddItemStrength.Text, out itemStrength);
            var itemDefense = 0;
            var hasSetDefense = int.TryParse(this.AddItemDefense.Text, out itemDefense);
            var itemStamina = 0;
            var hasSetStamina = int.TryParse(this.AddItemStamina.Text, out itemStamina);
            var itemAgility = 0;
            var hasSetAgility = int.TryParse(this.AddItemAgility.Text, out itemAgility);
            var itemCharisma = 0;
            var hasSetCharisma = int.TryParse(this.AddItemCharisma.Text, out itemCharisma);
            var itemGold = 0;
            var hasSetGold = int.TryParse(this.AddItemGold.Text, out itemGold);
            if (itemGold == 0)
            {
                itemGold = (itemStrength + itemDefense + itemStamina + itemAgility + itemCharisma + 5) * 55;
            }

            var itemToAdd = new Item()
            {
                Name = itemName,
                Gold = itemGold,
                Strength = itemStrength,
                Defence = itemDefense,
                Stamina = itemStamina,
                Agility = itemAgility,
                Charisma = itemCharisma,
            };

            this.dbContext.Items.Add(itemToAdd);
            this.dbContext.SaveChanges();

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
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
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InventoryMobileApp.Views
{
    public class CommonToolBarPage : ContentPage
    {
        public CommonToolBarPage() : base()
        {

        }

        private void Init()
        {
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Users"});
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Products" });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Racks" });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Designation" });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Sync" });
        }


        protected void AddToolBar(Grid contentGrid)
        {
            Grid.SetRow(contentGrid, 0);
            var toolBarView = new ToolBarView();
            contentGrid.Children.Add(toolBarView);
        }
    }
}

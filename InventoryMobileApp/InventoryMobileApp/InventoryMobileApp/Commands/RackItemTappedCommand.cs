using InventoryMobileApp.NativeServices;
using InventoryMobileApp.ViewModels;
using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InventoryMobileApp.Commands
{
   public class RackItemTappedCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Manage Products", "Cancel", "Ok", new[] { "Add", "Edit", "Delete" });
            if (result != null)
            {
                var rackViewModel = (RackViewModel)parameter;
                if (result.Contains(RackItemAction.Add))
                {
                    var productDetailPage = new RackDetailPage(rackViewModel.SelectedItem, RackItemAction.Add);
                    await App.Current.MainPage.Navigation.PushAsync(productDetailPage);
                }
                else if (result.Contains(RackItemAction.Edit))
                {
                    var productDetailPage = new RackDetailPage(rackViewModel.SelectedItem, RackItemAction.Edit);
                    await App.Current.MainPage.Navigation.PushAsync(productDetailPage);
                }
                else if (result.Contains(RackItemAction.Delete))
                {
                    var database = DependencyService.Get<ISQLite>().GetConnection();
                    database.CreateTable<DataModels.Product>();
                    DataModels.Product product = new DataModels.Product();
                    product.ProductId = (rackViewModel.SelectedItem as Models.Product).ProductId;
                    database.Delete(product);
                }
            }
        }
    }

    internal static class RackItemAction
    {
        public const string Add = "Add";
        public const string Edit = "Edit";
        public const string Delete = "Delete";
    }
}

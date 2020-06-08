using InventoryMobileApp.NativeServices;
using InventoryMobileApp.ViewModels;
using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InventoryMobileApp.Commands
{
    public class ProductItemTappedCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Manage Products", "Cancel", "Ok", new[] { "Add", "Edit", "Delete" });
            if (result != null)
            {
                var productViewModel = (ProductViewModel)parameter;
                if (result.Contains(ProductItemAction.Add))
                {
                    var productDetailPage = new ProductDetailPage(productViewModel.SelectedItem, ProductItemAction.Add);
                    await App.Current.MainPage.Navigation.PushAsync(productDetailPage);
                }
                else if (result.Contains(ProductItemAction.Edit))
                {
                    var productDetailPage = new ProductDetailPage(productViewModel.SelectedItem, ProductItemAction.Edit);
                    await App.Current.MainPage.Navigation.PushAsync(productDetailPage);
                }
                else if (result.Contains(ProductItemAction.Delete))
                {
                    var database = DependencyService.Get<ISQLite>().GetConnection();
                    database.CreateTable<DataModels.Product>();
                    DataModels.Product product = new DataModels.Product();
                    product.ProductId = (productViewModel.SelectedItem as Models.Product).ProductId;
                    database.Delete(product);
                }
            }
        }
    }

    internal static class ProductItemAction
    {
        public const string Add = "Add";
        public const string Edit = "Edit";
        public const string Delete = "Delete";
    }
}

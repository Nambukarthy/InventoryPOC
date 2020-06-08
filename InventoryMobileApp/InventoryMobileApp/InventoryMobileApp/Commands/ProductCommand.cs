using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class ProductCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
                var productPage = new ProductPage();
                await App.Current.MainPage.Navigation.PushAsync(productPage);
        }
    }
}

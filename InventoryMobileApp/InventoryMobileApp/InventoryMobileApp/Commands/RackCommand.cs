using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class RackCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var rackPage = new RackPage();
            await App.Current.MainPage.Navigation.PushAsync(rackPage);
        }
    }
}

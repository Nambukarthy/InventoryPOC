using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class UserCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var userPage = new UserPage();
            await App.Current.MainPage.Navigation.PushAsync(userPage);
        }
    }
}

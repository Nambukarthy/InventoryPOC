using InventoryMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class DesignationCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var designationPage = new DesignationPage();
            await App.Current.MainPage.Navigation.PushAsync(designationPage);
        }
    }
}

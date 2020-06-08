using InventoryMobileApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class ForgetPasswordCommand : CommandBase
    {   
        public override void Execute(object parameter)
        {
            var forgetPasswordPage = new ForgetPasswordPage();
            //forgetPasswordPage.BindingContext = parameter;
            PopupNavigation.Instance.PushAsync(forgetPasswordPage);
        }
    }
}

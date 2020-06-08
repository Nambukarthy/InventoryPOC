using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class ForgetPwdCancelCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}

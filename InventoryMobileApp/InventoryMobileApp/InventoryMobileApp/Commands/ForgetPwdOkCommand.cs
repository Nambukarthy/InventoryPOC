using InventoryMobileApp.Services;
using InventoryMobileApp.ViewModels;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class ForgetPwdOkCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            var loginViewModel = (LoginViewModel)parameter;

            if (string.IsNullOrEmpty(loginViewModel.ForgetUserName) || string.IsNullOrEmpty(loginViewModel.NewPassword))
            {
                loginViewModel.NewPwdErrorMessage = Messages.LoginMessage;
                return;
            }

            var credentials = new { UserName = loginViewModel.ForgetUserName, Password = loginViewModel.NewPassword };

            var jsonData = JsonConvert.SerializeObject(credentials);

            InventoryWebClient webClient = new InventoryWebClient();
            var result = await webClient.PostDetails("api/login/ChangePassword", jsonData);

            if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Navigate to next page.
                loginViewModel.NewPwdErrorMessage = "Password changed Successfully";
                loginViewModel.ErrorMessage = "Password changed Successfully";
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                loginViewModel.NewPwdErrorMessage = Messages.InvalidUser;
                await PopupNavigation.Instance.PopAsync();
            }
        }

        internal static class Messages
        {
            public const string LoginMessage = "Please enter username and password";
            public const string InvalidUser = "UserName is not valid";
        }
    }
}

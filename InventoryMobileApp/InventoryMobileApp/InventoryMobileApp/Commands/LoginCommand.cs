using InventoryMobileApp.Services;
using InventoryMobileApp.ViewModels;
using InventoryMobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.Commands
{
    public class LoginCommand : CommandBase
    {
        public override async void Execute(object parameter)    
        {
            var loginViewModel = (LoginViewModel)parameter;

            if (string.IsNullOrEmpty(loginViewModel.UserName) || string.IsNullOrEmpty(loginViewModel.Password))
            {
                loginViewModel.ErrorMessage = Messages.LoginMessage;
                return;
            }

            var credentials = new { UserName = loginViewModel.UserName, Password = loginViewModel.Password };

            var jsonData = JsonConvert.SerializeObject(credentials);

            InventoryWebClient webClient = new InventoryWebClient();
            var result = await webClient.PostDetails("api/login/LoginUser", jsonData);

            if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var productPage = new ProductPage();
                await App.Current.MainPage.Navigation.PushAsync(productPage);
            }
            else
            {
                loginViewModel.ErrorMessage = Messages.InvalidUser;
            }
        }

        internal static class Messages
        {
            public const string LoginMessage = "Please enter username and password";
            public const string InvalidUser = "UserName or Password is incorrect";
        }
    }
}

using InventoryMobileApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace InventoryMobileApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
            ForgetPasswordCommand = new ForgetPasswordCommand();
            ForgetPwdCancelCommand = new ForgetPwdCancelCommand();
            ForgetPwdOkCommand = new ForgetPwdOkCommand();
        }

        public ICommand LoginCommand
        {
            get; private set;
        }

        public ICommand ForgetPasswordCommand
        {
            get; private set;
        }

        public ICommand ForgetPwdCancelCommand
        {
            get; private set;
        }

        public ICommand ForgetPwdOkCommand
        {
            get; private set;
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        private string forgetUserName;

        public string ForgetUserName
        {
            get { return forgetUserName; }
            set
            {
                forgetUserName = value;
                NotifyPropertyChanged();
            }
        }

        private string newPassword;

        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                NotifyPropertyChanged();
            }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged();
            }
        }

        private string newPwderrorMessage;

        public string NewPwdErrorMessage
        {
            get { return newPwderrorMessage; }
            set
            {
                newPwderrorMessage = value;
                NotifyPropertyChanged();
            }
        }

    }
}

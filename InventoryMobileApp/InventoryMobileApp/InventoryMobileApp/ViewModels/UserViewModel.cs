using InventoryMobileApp.Models;
using InventoryMobileApp.NativeServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InventoryMobileApp.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set
            {
                if (value != userList)
                {
                    userList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private object selectedItem;

        public object SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }


        public UserViewModel()
        {
            //ProductItemTappedCommand = new ProductItemTappedCommand();

            //TODO-Need to create data access layer.
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.User>();
            var result = database.Table<DataModels.User>().ToList();

            UserList = new ObservableCollection<User>();

            foreach (var item in result)
            {
                UserList.Add(new User()
                {
                    UserId = item.UserId,
                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Password = item.Password,
                    EmailId = item.EmailId,
                    MobileNumber = item.MobileNumber,
                    Address = item.Address,
                    CreateDate = item.CreateDate,
                    DesignationId = item.DesignationId,
                    StatementType = item.StatementType,
                    IsServerData = item.IsServerData
                });
            }
        }

        public ICommand UserItemTappedCommand
        {
            get; private set;
        }
    }
}

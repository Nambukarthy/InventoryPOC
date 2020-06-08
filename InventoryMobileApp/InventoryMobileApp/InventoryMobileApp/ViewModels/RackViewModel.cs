using InventoryMobileApp.Commands;
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
   public class RackViewModel : ViewModelBase
    {

        private ObservableCollection<Rack> rackList;

        public ObservableCollection<Rack> RackList
        {
            get { return rackList; }
            set
            {
                if (value != rackList)
                {
                    rackList = value;
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

        public RackViewModel()
        {
            RackItemTappedCommand = new RackItemTappedCommand();

            //TODO-Need to create data access layer.
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.Rack>();
            var result = database.Table<DataModels.Rack>().ToList();

            RackList = new ObservableCollection<Rack>();

            foreach (var item in result)
            {
                RackList.Add(new Rack()
                {
                    RackId = item.RackId,
                    RackName = item.RackName,
                    RackCapacity = item.RackCapacity,
                    ShelvedItems = item.ShelvedItems,
                    CreateDate = item.CreateDate,
                    CreateBy = item.CreateBy,
                    RackOwner = item.RackOwner,
                    StatementType = item.StatementType,
                    IsServerData = item.IsServerData
                });
            }
        }



        public ICommand RackItemTappedCommand
        {
            get; private set;
        }
    }
}

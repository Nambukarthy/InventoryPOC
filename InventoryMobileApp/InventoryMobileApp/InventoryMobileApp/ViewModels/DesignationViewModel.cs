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
    public class DesignationViewModel : ViewModelBase
    {
        private ObservableCollection<Designation> designationList;

        public ObservableCollection<Designation> DesignationList
        {
            get { return designationList; }
            set
            {
                if (value != designationList)
                {
                    designationList = value;
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


        public DesignationViewModel()
        {
            //ProductItemTappedCommand = new ProductItemTappedCommand();

            //TODO-Need to create data access layer.
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.Designation>();
            var result = database.Table<DataModels.Designation>().ToList();

            DesignationList = new ObservableCollection<Designation>();

            foreach (var item in result)
            {
                DesignationList.Add(new Designation()
                {
                    DesignationId = item.DesignationId,
                    DesignationName = item.DesignationName,
                    StatementType = item.StatementType,
                    IsServerData = item.IsServerData
                });
            }
        }

        public ICommand DesignationItemTappedCommand
        {
            get; private set;
        }
    }
}
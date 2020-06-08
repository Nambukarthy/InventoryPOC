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
    public class ProductViewModel : ViewModelBase
    {      
        private ObservableCollection<Product> productList;

        public ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set
            {
                if (value != productList)
                {
                    productList = value;
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


        public ProductViewModel()
        {
            ProductItemTappedCommand = new ProductItemTappedCommand();

            //TODO-Need to create data access layer.
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.Product>();  
            var result = database.Table<DataModels.Product>().ToList();

            ProductList = new ObservableCollection<Product>();

            foreach (var item in result)
            {
                ProductList.Add(new Product() {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    SKU = item.SKU,
                    UPC = item.UPC,
                    IsSKULabled = item.IsSKULabled,
                    IsDamaged = item.IsDamaged,
                    IsSold = item.IsSold,
                    RackId = item.RackId,
                    IsShelved = item.IsShelved,
                    CreateBy = item.CreateBy,
                    ShelvedBy = item.ShelvedBy,
                    IsServerData = item.IsServerData
                });
            }
        }

        public ICommand ProductItemTappedCommand
        {
            get; private set;
        }
    }
}

using InventoryMobileApp.Commands;
using InventoryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryMobileApp.ViewModels
{
    public class ProductDetailViewModel : ViewModelBase
    {
        public ProductDetailViewModel()
        {
            ProductSaveCommand = new ProductSaveCommand();
            ProductCancelCommand = new ProductCancelCommand();
            ProductItem = new Product();
        }

        private Product productItem;

        public Product ProductItem
        {
            get { return productItem; }
            set {
                productItem = value;
                NotifyPropertyChanged();
            }
        }

        private string productAction;

        public string ProductAction
        {
            get { return productAction; }
            set
            {
                productAction = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand ProductSaveCommand
        {
            get; private set;
        }

        public ICommand ProductCancelCommand
        {
            get; private set;
        }
    }
}

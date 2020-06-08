using InventoryMobileApp.DataModels;
using InventoryMobileApp.NativeServices;
using InventoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InventoryMobileApp.Commands
{
    public class ProductSaveCommand : CommandBase
    {
        private ProductDetailViewModel productDetailViewModel;

        public override void Execute(object parameter)
        {
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.Product>();

            productDetailViewModel = (ProductDetailViewModel)parameter;
            var product = AssignToDataModel(productDetailViewModel.ProductItem);

            if (productDetailViewModel.ProductAction == "Add")
            {
                database.Insert(product);
            }
            else if (productDetailViewModel.ProductAction == "Edit")
            {
                database.Update(product);
            }
            else if (productDetailViewModel.ProductAction == "Delete")
            {
                database.Delete(product);
            }
        }


        private DataModels.Product AssignToDataModel(Models.Product product)
        {
            DataModels.Product dmProduct = new DataModels.Product();

            dmProduct.ProductId = product.ProductId;
            dmProduct.ProductName = product.ProductName;
            dmProduct.SKU = product.SKU;
            dmProduct.UPC = product.UPC;
            dmProduct.IsSKULabled = product.IsSKULabled;
            dmProduct.IsDamaged = product.IsDamaged;
            dmProduct.IsSold = product.IsSold;
            dmProduct.RackId = product.RackId;
            dmProduct.IsShelved = product.IsShelved;
            dmProduct.CreateBy = product.CreateBy;
            dmProduct.ShelvedBy = product.ShelvedBy;
            if (productDetailViewModel.ProductAction == "Add")
                dmProduct.StatementType = "Insert";
            else if (productDetailViewModel.ProductAction == "Edit")
                dmProduct.StatementType = "Update";

            dmProduct.IsServerData = false;

            return dmProduct;

        }
    }
}

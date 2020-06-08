using InventoryMobileApp.Models;
using InventoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : CommonToolBarPage
    {
		public ProductDetailPage (object parameter, string action)
		{
            var product = (Product)parameter;
            InitializeComponent ();
            AddToolBar(contentGrid);

            var viewModel = this.BindingContext;
            var productDetailViewModel = (ProductDetailViewModel)viewModel;
            productDetailViewModel.ProductAction = action;
           
            if (action == "Edit")
            {              
                productDetailViewModel.ProductItem = product;
            }
        }
	}
}
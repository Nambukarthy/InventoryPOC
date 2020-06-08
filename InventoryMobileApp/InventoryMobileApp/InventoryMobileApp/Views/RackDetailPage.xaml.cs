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
	public partial class RackDetailPage : CommonToolBarPage
    {
		public RackDetailPage (object parameter, string action)
		{
            var rack = (Rack)parameter;
            InitializeComponent();
            AddToolBar(contentGrid);

            var viewModel = this.BindingContext;
            var rackDetailViewModel = (RackDetailViewModel)viewModel;
            rackDetailViewModel.RackAction = action;

            if (action == "Edit")
            {
                rackDetailViewModel.RackItem = rack;
            }
        }
	}
}
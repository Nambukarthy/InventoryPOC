using InventoryMobileApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolBarView : ContentView
	{
		public ToolBarView ()
		{
			InitializeComponent ();
            this.BindingContext = this;
		}

        public ICommand SyncCommand { get { return CommonToolbarCommands.Instance.SyncCommand; } }

        public ICommand LogoutCommand { get { return CommonToolbarCommands.Instance.LogoutCommand; } }

        public ICommand ProductCommand { get { return CommonToolbarCommands.Instance.ProductCommand; } }

        public ICommand UserCommand { get { return CommonToolbarCommands.Instance.UserCommand; } }

        public ICommand DesignationCommand { get { return CommonToolbarCommands.Instance.DesignationCommand; } }

        public ICommand RackCommand { get { return CommonToolbarCommands.Instance.RackCommand; } }
    }
}
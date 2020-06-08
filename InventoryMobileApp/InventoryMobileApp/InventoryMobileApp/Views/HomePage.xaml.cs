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
	public partial class HomePage : CommonToolBarPage
    {
		public HomePage ()
		{
			InitializeComponent ();
            AddToolBar(contentGrid);
		}
	}
}
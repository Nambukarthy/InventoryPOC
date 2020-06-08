using InventoryMobileApp.Commands;
using InventoryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryMobileApp.ViewModels
{
    public class RackDetailViewModel : ViewModelBase
    {
        public RackDetailViewModel()
        {
            RackSaveCommand = new RackSaveCommand();
            RackItem = new Rack();
        }

        private Rack rackItem;

        public Rack RackItem
        {
            get { return rackItem; }
            set
            {
                rackItem = value;
                NotifyPropertyChanged();
            }
        }

        private string rackAction;

        public string RackAction
        {
            get { return rackAction; }
            set
            {
                rackAction = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand RackSaveCommand
        {
            get; private set;
        }

        public ICommand RackCancelCommand
        {
            get; private set;
        }
    }
}

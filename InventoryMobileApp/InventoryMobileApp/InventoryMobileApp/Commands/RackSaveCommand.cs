using InventoryMobileApp.NativeServices;
using InventoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InventoryMobileApp.Commands
{
    public class RackSaveCommand : CommandBase
    {
        private RackDetailViewModel rackDetailViewModel;

        public override void Execute(object parameter)
        {
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DataModels.Product>();

            rackDetailViewModel = (RackDetailViewModel)parameter;
            var rack = AssignToDataModel(rackDetailViewModel.RackItem);

            if (rackDetailViewModel.RackAction == "Add")
            {
                database.Insert(rack);
            }
            else if (rackDetailViewModel.RackAction == "Edit")
            {
                database.Update(rack);
            }
            else if (rackDetailViewModel.RackAction == "Delete")
            {
                database.Delete(rack);
            }
        }


        private DataModels.Rack AssignToDataModel(Models.Rack rack)
        {
            DataModels.Rack dmRack = new DataModels.Rack();

            dmRack.RackId = rack.RackId;
            dmRack.RackName = rack.RackName;
            dmRack.RackCapacity = rack.RackCapacity;
            dmRack.ShelvedItems = rack.ShelvedItems;
            dmRack.CreateBy = rack.CreateBy;
            dmRack.RackOwner = rack.RackOwner;
            
            if (rackDetailViewModel.RackAction == "Add")
                dmRack.StatementType = "Insert";
            else if (rackDetailViewModel.RackAction == "Edit")
                dmRack.StatementType = "Update";

            dmRack.IsServerData = false;

            return dmRack;

        }
    }
}

using InventoryMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.DataModels
{
    public class Rack : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int RackId { get; set; }

        public string RackName { get; set; }

        public int RackCapacity { get; set; }

        public int ShelvedItems { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateBy { get; set; }

        public int RackOwner { get; set; }

        public string StatementType { get; set; }

        public bool IsServerData { get; set; }
    }
}

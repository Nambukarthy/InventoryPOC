using InventoryMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.DataModels
{
    public class Product : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string SKU { get; set; }

        public string UPC { get; set; }

        public bool IsSKULabled { get; set; }

        public bool IsDamaged { get; set; }

        public bool IsSold { get; set; }

        public int RackId { get; set; }

        public bool IsShelved { get; set; }

        public int CreateBy { get; set; }

        public int ShelvedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ShelvedDate { get; set; }

        public string StatementType { get; set; }

        public bool IsServerData { get; set; }
    }
}

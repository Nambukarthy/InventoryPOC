using InventoryMobileApp.Models;
using SQLite;
using System;

namespace InventoryMobileApp.DataModels
{
    public class Designation : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public DateTime CreateDate { get; set; }

        public string StatementType { get; set; }

        public bool IsServerData { get; set; }
    }
}

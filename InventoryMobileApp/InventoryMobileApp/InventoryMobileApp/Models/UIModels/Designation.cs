using SQLite;
using System;

namespace InventoryMobileApp.Models
{
    public class Designation : ModelBase
    {
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public DateTime CreateDate { get; set; }

        public string StatementType { get; set; }

        public bool IsServerData { get; set; }
    }
}

using InventoryMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMobileApp.DataModels
{
    public class User : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public int DesignationId { get; set; }

        public string StatementType { get; set; }

        public bool IsServerData { get; set; }
    }
}

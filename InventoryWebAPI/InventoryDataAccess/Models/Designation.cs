using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Models
{
    public class Designation
    {
        private int designationId;

        public int DesignationId
        {
            get { return designationId; }
            set { designationId = value; }
        }


        private string designationName;

        public string DesignationName
        {
            get { return designationName; }
            set { designationName = value; }
        }


        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

    }
}

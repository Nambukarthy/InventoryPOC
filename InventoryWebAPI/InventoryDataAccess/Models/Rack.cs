using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Models
{
   public class Rack
    {

        private int rackId;

        public int RackId
        {
            get { return rackId; }
            set { rackId = value; }
        }

        private string rackName;

        public string RackName
        {
            get { return rackName; }
            set { rackName = value; }
        }

        private int rackCapacity;

        public int RackCapacity
        {
            get { return rackCapacity; }
            set { rackCapacity = value; }
        }

        private int shelvedItems;

        public int ShelvedItems
        {
            get { return shelvedItems; }
            set { shelvedItems = value; }
        }

        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        private int createBy;

        public int CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }

        private int rackOwner;

        public int RackOwner
        {
            get { return rackOwner; }
            set { rackOwner = value; }
        }
    }
}

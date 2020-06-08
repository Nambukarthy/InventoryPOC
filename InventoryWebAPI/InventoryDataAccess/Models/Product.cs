using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Models
{
    public class Product
    {
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string sku;

        public string SKU
        {
            get { return sku; }
            set { sku = value; }
        }


        private string upc;

        public string UPC
        {
            get { return upc; }
            set { upc = value; }
        }


        private bool isSKULabled;

        public bool IsSKULabled
        {
            get { return isSKULabled; }
            set { isSKULabled = value; }
        }

        private bool isDamaged;

        public bool IsDamaged
        {
            get { return isDamaged; }
            set { isDamaged = value; }
        }

        private bool isSold;

        public bool IsSold
        {
            get { return isSold; }
            set { isSold = value; }
        }

        private int rackId;

        public int RackId
        {
            get { return rackId; }
            set { rackId = value; }
        }

        private bool isShelved;

        public bool IsShelved
        {
            get { return isShelved; }
            set { isShelved = value; }
        }


        private int createBy;

        public int CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }

        private int shelvedBy;

        public int ShelvedBy
        {
            get { return shelvedBy; }
            set { shelvedBy = value; }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        private DateTime shelvedDate;

        public DateTime ShelvedDate
        {
            get { return shelvedDate; }
            set { shelvedDate = value; }
        }
    }
}

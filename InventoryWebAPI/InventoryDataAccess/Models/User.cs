using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Models
{
    public class User
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string emailId;

        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }

        private string mobileNumber;

        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        private int designationId;

        public int DesignationId
        {
            get { return designationId; }
            set { designationId = value; }
        }
    }
}

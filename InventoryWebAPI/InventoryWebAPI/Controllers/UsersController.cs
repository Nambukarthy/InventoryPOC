using InventoryDataAccess;
using InventoryDataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Temp1WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/Users
        public string Get()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", 1);
            parameters.Add("@username", string.Empty);
            parameters.Add("@firstname", string.Empty);
            parameters.Add("@lastname", string.Empty);
            parameters.Add("@password", 0);
            parameters.Add("@emailid ", 0);
            parameters.Add("@mobilenumber", 0);
            parameters.Add("@address", 0);
            parameters.Add("@designationid", 0);
            parameters.Add("@StatementType", "Select");

            DAL dal = new DAL();
            var userList = dal.GetRecords<User>("SP_Users", parameters);
            return JsonConvert.SerializeObject(userList);
        }

        // POST api/Users
        public string Post([FromBody]JObject jObject)
        {

            var jtokenUserId = jObject["UserId"];
            var userId = jtokenUserId.Value<int>();

            var jtokenUserName = jObject["UserName"];
            var userName = jtokenUserName.Value<string>();

            var jtokenFirstName = jObject["FirstName"];
            var firstName = jtokenFirstName.Value<string>();

            var jtokenLastName = jObject["LastName"];
            var lastName = jtokenLastName.Value<string>();

            var jtokenPassword = jObject["Password"];
            var password = jtokenPassword.Value<string>();

            var jtokenEmailId = jObject["EmailId"];
            var emailId = jtokenEmailId.Value<string>();

            var jtokenMobileNumber = jObject["MobileNumber"];
            var mobileNumber = jtokenMobileNumber.Value<string>();

            var jtokenAddress = jObject["Address"];
            var address = jtokenAddress.Value<string>();

            var jtokenCreateDate = jObject["CreateDate"];
            var createDate = jtokenCreateDate.Value<DateTime>();

            var jtokenDesignationId = jObject["DesignationId"];
            var designationId = jtokenDesignationId.Value<int>();

            var jtokenStatementType = jObject["StatementType"];
            var statementType = jtokenStatementType.Value<string>();


            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", userId);
            parameters.Add("@username", userName);
            parameters.Add("@firstname", firstName);
            parameters.Add("@lastname", lastName);
            parameters.Add("@password", password);
            parameters.Add("@emailid ", emailId);
            parameters.Add("@mobilenumber", mobileNumber);
            parameters.Add("@address", address);
            parameters.Add("@designationid", designationId);
            parameters.Add("@StatementType", statementType);

            DAL dal = new DAL();
            dal.InsertUpdateDeleteRecord("SP_Users", parameters);

            return "Record " + statementType + " Sucessfully";
        }


       
    }
}

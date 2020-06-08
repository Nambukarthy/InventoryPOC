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

namespace InventoryWebAPI.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("LoginUser")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public HttpResponseMessage LoginUser([FromBody] JObject jObject)
        {
            var jtokenUserName = jObject["UserName"];
            var userName = jtokenUserName.Value<string>();

            var jtokenPassword = jObject["Password"];
            var password = jtokenPassword.Value<string>();
 
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@username", userName);
            parameters.Add("@password", password);

            DAL dal = new DAL();
            var user = dal.GetRecords<User>("SP_CheckValidUser", parameters);

            if (user.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK); 
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user");          
        }


        [Route("ChangePassword")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public HttpResponseMessage ChangePassword([FromBody]JObject jObject)
        {
            var jtokenUserName = jObject["UserName"];
            var userName = jtokenUserName.Value<string>();

            var jtokenPassword = jObject["Password"];
            var password = jtokenPassword.Value<string>();

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@username", userName);

            DAL dal = new DAL();
            var user = dal.GetRecords<User>("[SP_CheckUserExist]", parameters);

            if (user.Count > 0)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("@id", user[0].UserId);
                parameters.Add("@username", user[0].UserName);
                parameters.Add("@firstname", user[0].FirstName);
                parameters.Add("@lastname", user[0].LastName);
                parameters.Add("@password", password);
                parameters.Add("@emailid ", user[0].EmailId);
                parameters.Add("@mobilenumber", user[0].MobileNumber);
                parameters.Add("@address", user[0].Address);
                parameters.Add("@designationid", user[0].DesignationId);
                parameters.Add("@StatementType", "Update");

                dal = new DAL();
                dal.InsertUpdateDeleteRecord("SP_Users", parameters);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid user");
            }
        }
    }
}

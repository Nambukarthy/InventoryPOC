using InventoryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryDataAccess.Helper;
using InventoryDataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Temp1WebAPI.Controllers
{
    public class RacksController : ApiController
    {
        // GET api/Racks
        public string Get()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", 1);
            parameters.Add("@rackname ", string.Empty);
            parameters.Add("@rackcapacity ", 0);
            parameters.Add("@shelvedItems ", 0);
            parameters.Add("@createdby ", 0);
            parameters.Add("@rackowner ", 0);
            parameters.Add("@StatementType ", "Select");

            DAL dal = new DAL();
            var rackList = dal.GetRecords<Rack>("SP_Racks", parameters);

            string output = JsonConvert.SerializeObject(rackList);
            return output;
        }

        // POST api/racks
        public string Post([FromBody]JObject jObject)
        {
            var jtokenRackId = jObject["RackId"];
            var rackId = jtokenRackId.Value<int>();

            var jtokenRackName = jObject["RackName"];
            var rackName = jtokenRackName.Value<string>();

            var jtokenRackCapacity = jObject["RackCapacity"];
            var rackCapacity = jtokenRackCapacity.Value<int>();

            var jtokenShelvedItems = jObject["ShelvedItems"];
            var shelvedItems = jtokenShelvedItems.Value<int>();

            var jtokenCreateBy = jObject["CreateBy"];
            var createBy = jtokenCreateBy.Value<int>();

            var jtokenRackOwner = jObject["RackOwner"];
            var rackOwner = jtokenRackOwner.Value<int>();

            var jtokenStatementType = jObject["StatementType"];
            var statementType = jtokenStatementType.Value<string>();


            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", rackId);
            parameters.Add("@rackname ", rackName);
            parameters.Add("@rackcapacity ",rackCapacity);
            parameters.Add("@shelvedItems ", shelvedItems);
            parameters.Add("@createdby ", createBy);
            parameters.Add("@rackowner ", rackOwner);
            parameters.Add("@StatementType ", statementType);

            DAL dal = new DAL();
            dal.InsertUpdateDeleteRecord("SP_Racks", parameters);

            return "Record " + statementType + " Sucessfully";
       }
    }
}

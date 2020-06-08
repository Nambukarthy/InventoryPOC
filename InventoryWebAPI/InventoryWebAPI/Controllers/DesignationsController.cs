using InventoryDataAccess;
using InventoryDataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Temp1WebAPI.Controllers
{
    public class DesignationsController : ApiController
    {
        // GET api/Racks
        public string Get()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", 1);
            parameters.Add("@designationname", string.Empty);
            parameters.Add("@StatementType", "Select");

            DAL dal = new DAL();
            var designationList = dal.GetRecords<Designation>("SP_Designation", parameters);
            return JsonConvert.SerializeObject(designationList);
        }

        // POST api/racks
        public string Post([FromBody]string input)
        {
            dynamic obj = JsonConvert.DeserializeObject(input);

            List<Designation> designationList = JsonConvert.DeserializeObject<List<Designation>>(input);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", designationList[0].DesignationId);
            parameters.Add("@designationname", designationList[0].DesignationName);
            parameters.Add("@StatementType", obj[0].StatementType.ToString());

            DAL dal = new DAL();
            dal.InsertUpdateDeleteRecord("SP_Designation", parameters);

            return "Record " + obj[0].StatementType.ToString() + " Sucessfully";
        }
    }
}

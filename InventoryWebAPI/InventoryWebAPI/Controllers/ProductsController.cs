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
    public class ProductsController : ApiController
    {
        // GET api/Racks
        public string Get()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", 1);
            parameters.Add("@productName", string.Empty);
            parameters.Add("@sku", string.Empty);
            parameters.Add("@upc", string.Empty);
            parameters.Add("@isskulabled", 0);
            parameters.Add("@isdamaged", 0);
            parameters.Add("@issold", 0);
            parameters.Add("@rackid", 0);
            parameters.Add("@isshelved", 0);
            parameters.Add("@createdby", 0);
            parameters.Add("@shelvedby", 0);
            parameters.Add("@StatementType", "Select");

            DAL dal = new DAL();
            var productList = dal.GetRecords<Product>("SP_Products", parameters);
            return JsonConvert.SerializeObject(productList);
        }

        // POST api/racks
        public string Post([FromBody]JObject jObject)
        {

            var jtokenProductId = jObject["ProductId"];
            var productId = jtokenProductId.Value<int>();

            var jtokenProductName = jObject["ProductName"];
            var productName = jtokenProductName.Value<string>();

            var jtokenSKU = jObject["SKU"];
            var sku = jtokenSKU.Value<string>();

            var jtokenUPC = jObject["UPC"];
            var upc = jtokenUPC.Value<string>();

            var jtokenIsSKULabled = jObject["IsSKULabled"];
            var isSKULabled = jtokenIsSKULabled.Value<string>();

            var jtokenIsDamaged = jObject["IsDamaged"];
            var isDamaged = jtokenIsDamaged.Value<string>();

            var jtokenIsSold = jObject["IsSold"];
            var isSold = jtokenIsSold.Value<string>();

            var jtokenRackId = jObject["RackId"];
            var rackId = jtokenRackId.Value<string>();

            var jtokenIsShelved = jObject["IsShelved"];
            var isShelved = jtokenIsShelved.Value<string>();

            var jtokenCreateBy = jObject["CreateBy"];
            var createdBy = jtokenCreateBy.Value<string>();

            var jtokenShelvedBy = jObject["ShelvedBy"];
            var shelvedBy = jtokenShelvedBy.Value<string>();

            var jtokenStatementType = jObject["StatementType"];
            var statementType = jtokenStatementType.Value<string>();

           

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", productId);
            parameters.Add("@productName", productName);
            parameters.Add("@sku", sku);
            parameters.Add("@upc", upc);
            parameters.Add("@isskulabled", isSKULabled);
            parameters.Add("@isdamaged", isDamaged);
            parameters.Add("@issold", isSold);
            parameters.Add("@rackid", rackId);
            parameters.Add("@isshelved", isShelved);
            parameters.Add("@createdby", createdBy);
            parameters.Add("@shelvedby", shelvedBy);
            parameters.Add("@StatementType", statementType);

            DAL dal = new DAL();
            dal.InsertUpdateDeleteRecord("SP_Products", parameters);

            return "Record " + statementType + " Sucessfully";
        }
    }
}

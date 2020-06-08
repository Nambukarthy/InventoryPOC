using InventoryMobileApp.DataModels;
using InventoryMobileApp.NativeServices;
using InventoryMobileApp.Services;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InventoryMobileApp.Commands
{
    public class SyncCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            await InsertOfflineDataToServer();
            await GetServerData();
        }

        private async Task InsertOfflineDataToServer()
        {
            var database = DependencyService.Get<ISQLite>().GetConnection();

            #region Insert Product
            database.CreateTable<DataModels.Product>();
            var productOffline = database.Table<DataModels.Product>().ToList();

            foreach (var item in productOffline)
            {
                if (item != null && !item.IsServerData)
                {
                    var jsonModel = new
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        SKU = item.SKU,
                        UPC = item.UPC,
                        IsSKULabled = item.IsSKULabled,
                        IsDamaged = item.IsDamaged,
                        IsSold = item.IsSold,
                        RackId = item.RackId,
                        IsShelved = item.IsShelved,
                        CreateBy = item.CreateBy,
                        ShelvedBy = item.ShelvedBy,
                        CreatedDate = item.CreatedDate,
                        ShelvedDate = item.ShelvedDate,
                        StatementType = item.StatementType
                    };

                    var jsonData = JsonConvert.SerializeObject(jsonModel);

                    InventoryWebClient webClient = new InventoryWebClient();
                    var result = await webClient.PostDetails("api/products", jsonData);
                }
            }
            #endregion

            #region Insert Rack
            database.CreateTable<DataModels.Rack>();
            var rackOffline = database.Table<DataModels.Rack>().ToList();

            foreach (var item in rackOffline)
            {
                if (item != null && !item.IsServerData)
                {
                    var jsonModel = new
                    {
                        RackId = item.RackId,
                        RackName = item.RackName,
                        RackCapacity = item.RackCapacity,
                        ShelvedItems = item.ShelvedItems,
                        CreateDate = item.CreateDate,
                        CreateBy = item.CreateBy,
                        RackOwner = item.RackOwner,
                        StatementType = item.StatementType
                    };

                    var jsonData = JsonConvert.SerializeObject(jsonModel);

                    InventoryWebClient webClient = new InventoryWebClient();
                    var result = await webClient.PostDetails("api/racks", jsonData);
                }
            }
            #endregion

            #region Insert User
            database.CreateTable<DataModels.User>();
            var userOffline = database.Table<DataModels.User>().ToList();

            foreach (var item in userOffline)
            {
                if (item != null && !item.IsServerData)
                {
                    var jsonModel = new
                    {
                        UserId = item.UserId,
                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        EmailId = item.EmailId,
                        MobileNumber = item.MobileNumber,
                        Address = item.Address,
                        CreateDate = item.CreateDate,
                        DesignationId = item.DesignationId,
                        StatementType = item.StatementType,                       
                    };

                    var jsonData = JsonConvert.SerializeObject(jsonModel);

                    InventoryWebClient webClient = new InventoryWebClient();
                    var result = await webClient.PostDetails("api/users", jsonData);
                }
            }
            #endregion
        }

        private async Task GetServerData()
        {
            InventoryWebClient webClient = new InventoryWebClient();

            //Products
            var productsResponse = await webClient.GetDetails("api/Products");
            if (productsResponse != null && productsResponse.IsSuccessStatusCode)
            {
                var jsonProduct = productsResponse.Content.ReadAsStringAsync().Result;
                var jProducts = JsonConvert.DeserializeObject(jsonProduct).ToString();
                Products = JsonConvert.DeserializeObject<List<Product>>(jProducts);
            }

            //Users
            var usersResponse = await webClient.GetDetails("api/Users");
            if (usersResponse != null && usersResponse.IsSuccessStatusCode)
            {
                var jsonUsers = usersResponse.Content.ReadAsStringAsync().Result;
                var jUsers = JsonConvert.DeserializeObject(jsonUsers).ToString();
                Users = JsonConvert.DeserializeObject<List<User>>(jUsers);
            }

            //Racks
            var racksResponse = await webClient.GetDetails("api/Racks");
            if (racksResponse != null && racksResponse.IsSuccessStatusCode)
            {
                var jsonRacks = racksResponse.Content.ReadAsStringAsync().Result;
                var jRacks = JsonConvert.DeserializeObject(jsonRacks).ToString();
                Racks = JsonConvert.DeserializeObject<List<Rack>>(jRacks);
            }

            //Designations
            var designationsResponse = await webClient.GetDetails("api/Designations");
            if (designationsResponse != null && designationsResponse.IsSuccessStatusCode)
            {
                var jsonDesignations = designationsResponse.Content.ReadAsStringAsync().Result;
                var jDesignations = JsonConvert.DeserializeObject(jsonDesignations).ToString();
                Designations = JsonConvert.DeserializeObject<List<Designation>>(jDesignations);
            }

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.DropTable<Product>();
            database.DropTable<User>();
            database.DropTable<Designation>();
            database.DropTable<Rack>();

            database.CreateTable<Product>();
            database.CreateTable<User>();
            database.CreateTable<Designation>();
            database.CreateTable<Rack>();

            //Insert Product to local db
            foreach (var product in Products)
            {
                product.IsServerData = true;
                database.Insert(product);
            }

            //Insert Users to local db
            foreach (var user in Users)
            {
                user.IsServerData = true;
                database.Insert(user);
            }

            //Insert Rack to local db
            foreach (var rack in Racks)
            {
                rack.IsServerData = true;
                database.Insert(rack);
            }

            //Insert Designation to local db
            foreach (var designation in Designations)
            {
                designation.IsServerData = true;
                database.Insert(designation);
            }

        }

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private List<Designation> designations;

        public List<Designation> Designations
        {
            get { return designations; }
            set { designations = value; }
        }

        private List<Rack> racks;

        public List<Rack> Racks
        {
            get { return racks; }
            set { racks = value; }
        }
    }
}

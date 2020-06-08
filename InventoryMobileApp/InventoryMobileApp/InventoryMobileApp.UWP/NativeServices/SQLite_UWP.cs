using InventoryMobileApp.NativeServices;
using InventoryMobileApp.UWP.NativeServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace InventoryMobileApp.UWP.NativeServices
{
    public class SQLite_UWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "ABBInventoryDb.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}

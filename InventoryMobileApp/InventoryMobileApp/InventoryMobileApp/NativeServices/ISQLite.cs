using SQLite;

namespace InventoryMobileApp.NativeServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

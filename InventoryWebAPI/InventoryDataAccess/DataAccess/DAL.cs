using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess
{
    public class DAL
    {   
        string strConn = "Data Source=LAPTOP-5P6QUU5P;Initial Catalog=TempPOCInventory;Integrated Security=true";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader reader;

        public DAL()
        {
            sqlConnection = new SqlConnection(strConn);
            sqlCommand = new SqlCommand();
        }

        private void CreateCommand(string cmdText, Dictionary<string, object> parameters)
        {
            sqlCommand.CommandText = cmdText;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            foreach (var item in parameters)
            {
                var commandParameter = sqlCommand.CreateParameter();
                commandParameter.ParameterName = item.Key;
                commandParameter.Value = item.Value;
                sqlCommand.Parameters.Add(commandParameter);
            }
        }

        public void InsertUpdateDeleteRecord(string cmdText, Dictionary<string, object> parameters)
        {
            try
            {
                CreateCommand(cmdText, parameters);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();                
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public List<T> GetRecords<T>(string cmdText, Dictionary<string, object> parameters)
        {
            try
            {
                CreateCommand(cmdText, parameters);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                var result = Helper.Helper.DataReaderMapToList<T>(reader);  
                sqlConnection.Close();
                return result;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }
    }
}

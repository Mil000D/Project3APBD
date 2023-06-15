using System.Data.SqlClient;
using Zadanie4.Enums;

namespace Zadanie4.Handlers
{
    public static class ConnectionHandler
    {
        //Method that handles connection and returns appropriate enum
        //if connection was successful - SQL_CONNECTED and if not SQL_COULD_NOT_CONNECT,
        //SQL_ERROR is returned if other error occured
        public static EnumToReturn HandleConnection(SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Open();
                return EnumToReturn.SQL_CONNECTED;
            }
            catch (SqlException)
            {
                return EnumToReturn.SQL_COULD_NOT_CONNECT;
            }
            catch (Exception)
            {
                return EnumToReturn.SQL_ERROR;
            }
        }
    }
}

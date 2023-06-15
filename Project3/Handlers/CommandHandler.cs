using System.Data.SqlClient;
using Zadanie4.DTOs;
using Zadanie4.Enums;

namespace Zadanie4.Handlers
{
    public static class CommandHandler
    {
        //Method that handles DML command provided as parameter and returns appropriate enum
        //if operation was successful SQL_DATA_OPERATION_SUCCESSFUL
        //and if not SQL_DATA_OPERATION_FAILURE,
        //SQL_ERROR is returned if other error occured
        public static EnumToReturn HandleDMLCommand(SqlCommand command)
        {
            try
            {
                var rows = command.ExecuteNonQuery();
                if (rows == 1)
                {
                    return EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL;
                }
                else
                {
                    return EnumToReturn.SQL_DATA_OPERATION_FAILURE;
                }
            }
            catch (Exception)
            {
                return EnumToReturn.SQL_ERROR;
            }
        }

        //Method that handles DQL command provided as parameter and returns appropriate enum
        //if operation was successful SQL_DATA_OPERATION_SUCCESSFUL
        //and if not SQL_DATA_OPERATION_FAILURE,
        //SQL_ERROR is returned if other error occured
        public static EnumToReturn HandleDQLCommand(SqlCommand command, List<AnimalDTO> animals)
        {
            try
            {
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AnimalDTO animal = new AnimalDTO
                    {
                        ID = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1),
                        Description = (string)reader.GetValue(2),
                        Category = (string)reader.GetValue(3),
                        Area = (string)reader.GetValue(4),
                    };
                    animals.Add(animal);
                }
                return EnumToReturn.SQL_DATA_OPERATION_SUCCESSFUL;
            }
            catch (SqlException)
            {
                return EnumToReturn.SQL_DATA_OPERATION_FAILURE;
            }
            catch (Exception)
            {
                return EnumToReturn.SQL_ERROR;
            }
        }
    }
}

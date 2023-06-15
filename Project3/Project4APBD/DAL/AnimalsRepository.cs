using System.Data.SqlClient;
using Zadanie4.DTOs;
using Zadanie4.Enums;
using Zadanie4.Handlers;

namespace Zadanie4.DAL
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly string connection = "connection string";
        
        //Method that returns appropriate enums depending on success or failure
        //of select statement (if operation succeded Animals also are added to list provided as parameter)
        public EnumToReturn SelectAnimals(List<AnimalDTO> animals, string orderBy)
        {
            using SqlConnection sqlConnection = new SqlConnection(connection);
            var enumToReturn = ConnectionHandler.HandleConnection(sqlConnection);
            if(enumToReturn != EnumToReturn.SQL_CONNECTED)
            {
                return enumToReturn;
            }
            using SqlCommand command = new SqlCommand($"SELECT * FROM Animal ORDER BY {orderBy} ASC", sqlConnection);
            
            return CommandHandler.HandleDQLCommand(command, animals);
        }

        //Method that returns appropriate enums depending on success or failure
        //of insert statement done with the use of Animal specified as parameter
        public EnumToReturn InsertAnimal(AnimalDTO animal)
        {
            using SqlConnection sqlConnection = new SqlConnection(connection);
            var enumToReturn = ConnectionHandler.HandleConnection(sqlConnection);
            if (enumToReturn != EnumToReturn.SQL_CONNECTED)
            {
                return enumToReturn;
            }
            using SqlCommand command = new SqlCommand($"INSERT INTO Animal (Name, Description, Category, Area)" +
                                                                  $"VALUES (@Name, @Description, @Category, @Area)", sqlConnection);

            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            return CommandHandler.HandleDMLCommand(command);
        }

        //Method that returns appropriate enums depending on success or failure
        //of update statement done with the use of Animal and ID of this Animal specified as parameters
        public EnumToReturn UpdateAnimal(AnimalDTO animal, int idAnimal)
        {
            using SqlConnection sqlConnection = new SqlConnection(connection);
            var enumToReturn = ConnectionHandler.HandleConnection(sqlConnection);
            if (enumToReturn != EnumToReturn.SQL_CONNECTED)
            {
                return enumToReturn;
            }
            using SqlCommand command = new SqlCommand($"UPDATE Animal SET" +
                                                      $" Name = @Name," +
                                                      $" Description = @Description," +
                                                      $" Category = @Category," +
                                                      $" Area = @Area WHERE IdAnimal = @IdAnimal", sqlConnection);

            command.Parameters.AddWithValue("@IdAnimal", idAnimal);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            return CommandHandler.HandleDMLCommand(command);
        }

        //Method that returns appropriate enums depending on success or failure
        //of delete statement done on Animal (deletes animal with specified ID as parameter)
        public EnumToReturn DeleteAnimal(int idAnimal)
        {
            using SqlConnection sqlConnection = new SqlConnection(connection);
            var enumToReturn = ConnectionHandler.HandleConnection(sqlConnection);
            if (enumToReturn != EnumToReturn.SQL_CONNECTED)
            {
                return enumToReturn;
            }
            using SqlCommand command = new SqlCommand($"DELETE FROM Animal WHERE IdAnimal = @IdAnimal", sqlConnection);

            command.Parameters.AddWithValue("@IdAnimal", idAnimal);

            return CommandHandler.HandleDMLCommand(command);
        }
    }
}

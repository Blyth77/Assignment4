using System;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Assignment4.Entities;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=Futurama;User Id=sa;Password=d3683282-6245-4dee-b994-a8493e31ea46";

            var configuration = LoadConfiguration();
            using var connection = new SqlConnection(connectionString);
        
            var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>().UseSqlServer(connectionString);
            using var context = new KanbanContext(optionsBuilder.Options);

            /* var cmdText = "SELECT * FROM Characters";
            using var command = new SqlCommand(cmdText, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var character = new
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Species = reader.GetString("Species"),
                    Planet = reader.GetString("Planet"),
                };
                Console.WriteLine(character); */
            }

            static IConfiguration LoadConfiguration()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<Program>();

                return builder.Build();
            }
        }
    }
    }

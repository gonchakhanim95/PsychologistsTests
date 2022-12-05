using Dapper;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests
{
    public class DeleteAkkauntAsClient
    {
        private const string EMAIL = "guseyn123qwer23@gmail.com";
        private const string PASSWORD = "Gus1Client";

        [SetUp]
        public void su()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query("delete from Comment");
            dbConnection.Query("delete from [Order]");
            dbConnection.Query("delete from dbo.ApplicationForPsychologistSearch");
            dbConnection.Query($"delete from dbo.Сlient ");
            dbConnection.Close();
        }
        [Test]
        public void DeleteAkkauntAsClientTest()
        {
            ClientClient client = new ClientClient();
            ClientModelForCreateClient clientCreateModel = new ClientModelForCreateClient()
            {
                Name = "guseyn",
                LastName = "gusikov",
                Password = PASSWORD,
                Email = EMAIL,
                PhoneNumber = "+71111111111",
                BirthDate = new DateTime(2002, 11, 11)
            };

            int id = client.CreateClient(clientCreateModel);

            ClientModelForAuthClient clientAuthModel = new ClientModelForAuthClient()
            {
                Email = EMAIL,
                Password = PASSWORD
            };

            string token = client.AuthClient(clientAuthModel);

            client.DeleteClient(id,token); 

            client.CheckClientByIdAfterDelete(id,token);
        }

        [TearDown]
        public void TD()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query("delete from Comment");
            dbConnection.Query("delete from [Order]");
            dbConnection.Query("delete from dbo.ApplicationForPsychologistSearch");
            dbConnection.Query($"delete from dbo.Сlient ");
            dbConnection.Close();
        }
    }
}

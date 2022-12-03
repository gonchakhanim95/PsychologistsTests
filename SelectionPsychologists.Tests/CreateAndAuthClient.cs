global using NUnit.Framework;
using Dapper;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Models;
using System.Data;
using System.Data.SqlClient;

namespace SelectionPsychologists.Tests
{
    public class CreateAndAuthClient
    {
        private const string EMAIL = "guseyn123qwer23@gmail.com";
        private const string PASSWORD = "Gus1Client";

        [Test]
        public void CreateAndAuthClientTest()
        {
            ClientClient client = new ClientClient();
            ClientRequestModel clientRegistrationModel = new ClientRequestModel()
            {
                Name = "guseyn",
                LastName = "gusikov",
                Password = PASSWORD,
                Email = EMAIL,
                PhoneNumber = "+71111111111",
                BirthDate = new DateTime(2002,11,11)
            };

            int id = client.RegistrationClient(clientRegistrationModel);

            AuthClientRequestModel clientAuthModel = new AuthClientRequestModel()
            {
                Email = EMAIL,
                Password = PASSWORD
            };

            string token = client.AuthClient(clientAuthModel);

            CheckClientModel expextedClient = new CheckClientModel()
            {
                Id =id,
                Name = clientRegistrationModel.Name,
                LastName = clientRegistrationModel.LastName,
                Password = clientRegistrationModel.Password,
                Email = clientRegistrationModel.Email,
                PhoneNumber = clientRegistrationModel.PhoneNumber,
                BirthDate = clientRegistrationModel.BirthDate
            };
            CheckClientModel actualClient = client.CheckClientById(id, token);

            Assert.AreEqual(expextedClient, actualClient);

        }
        [TearDown]
        public void TD()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query($"delete from Ñlient where Email = '{EMAIL}'");
            dbConnection.Close();
        }
        [OneTimeTearDown]
        public void OTTD()
        {

         }
    }
}
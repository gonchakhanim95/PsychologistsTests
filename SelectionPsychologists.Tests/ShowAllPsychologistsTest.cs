 global using NUnit.Framework;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SelectionPsychologists.Tests
{
    public class ShowAllPsychologistsTest
    {
        private const string PASSWORD = "Client1Client";
        private const string EMAIL = "client@gmail.com";



        [OneTimeSetUp]
        public void otsu()
        {

        }
        [SetUp]
        public void su()
        {

        }

        [Test]
        public void Test1()
        {
            ClientClient client = new ClientClient();

            ClientModelForCreateClient createModel = new ClientModelForCreateClient()
            {
                Name = "client",
                LastName = "clientov",
                Password = PASSWORD,
                Email = EMAIL,
                PhoneNumber = "+72222222222",
                BirthDate = new DateTime(1990,02,02)
            };

            int id = client.CreateClient(createModel);

            ClientModelForAuthClient AuthModel = new ClientModelForAuthClient()
            {
                Password = PASSWORD,
                Email = EMAIL
            };

            string token = client.AuthClient(AuthModel);

            List<PsychologistModel> psychologists = client.ShowAllPsychologistsAsClient(token);
            //CollectionAssert.Contains(psychologists, new PsychologistModel());

        }

        [TearDown]
        public void td()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query($"delete from BBSK_PsychoDb4.dbo.Client where Email = '{EMAIL}'");
            dbConnection.Close();
        }
        [OneTimeTearDown]
        public void ottd()
        {
           
        }
    }
}
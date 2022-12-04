 global using NUnit.Framework;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SelectionPsychologists.Tests.Model;

namespace SelectionPsychologists.Tests
{
    public class ShowAllPsychologists
    {
        private const string PASSWORD = "Client1Client";
        private const string clientEMAIL = "client@gmail.com";
        private const string psychoEmail1 = "Zakir@gmail.com";
        private const string psychoEmail2 = "Orxan@gmail.com";

        [SetUp]
        public void su()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query($"delete from PsychologistTherapyMethod");
            dbConnection.Query($"delete from Education");
            dbConnection.Query($"delete from ProblemPsychologist");
            dbConnection.Query($"delete from [Order]");
            dbConnection.Query($"delete from Schedule");
            dbConnection.Query($"delete from Comment");
            dbConnection.Query($"delete from Psychologist");
            dbConnection.Close();
        }

        [Test]
        public void ShowAllPsychologistsTest()
        {
            ClientClient client = new ClientClient();

            ClientModelForCreateClient createModel = new ClientModelForCreateClient()
            {
                Name = "client",
                LastName = "clientov",
                Password = PASSWORD,
                Email = clientEMAIL,
                PhoneNumber = "+72222222222",
                BirthDate = new DateTime(1990,02,02)
            };

            int id = client.CreateClient(createModel);

            ClientModelForAuthClient AuthModel = new ClientModelForAuthClient()
            {
                Password = PASSWORD,
                Email = clientEMAIL
            };

            string token = client.AuthClient(AuthModel);

            PsychologistRequestModel psychologistsRequestModel1 = new PsychologistRequestModel() //rabotaet
            {
                Name = "Zakir",
                LastName = "Hajiev",
                Patronymic = "Seymur",
                Gender = 1,
                BirthDate = DateTime.Parse("2002-07-24"),
                Phone = "589875641",
                Password = "Zakir1Psycho",
                Email = psychoEmail1,
                WorkExperience = 8,
                PasportData = "87444445",
                Educations = new List<string>() { "BDU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Behaviorall" },
                Problems = new List<string>() { "Family" },
                Price = 50
            };
            PsychologistRequestModel psychologistsRequestModel2 = new PsychologistRequestModel() //rabotaet
            {
                Name = "Orxan",
                LastName = "Recebov",
                Patronymic = "Bilmirem",
                Gender = 1,
                BirthDate = DateTime.Parse("2004-07-24"),
                Phone = "+71233211122",
                Password = "Orxan1Psycho",
                Email = psychoEmail2,
                WorkExperience = 8,
                PasportData = "87444445",
                Educations = new List<string>() { "BDU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Behavioral" },
                Problems = new List<string>() { "Family" },
                Price = 50
            };
            PsychologistClient psychologistClient = new PsychologistClient();

            psychologistClient.CreatePsy(psychologistsRequestModel1);
            psychologistClient.CreatePsy(psychologistsRequestModel2);

            List<PsychologistRequestModel> myPsycho = new List<PsychologistRequestModel>();
            myPsycho.Add(psychologistsRequestModel1);
            myPsycho.Add(psychologistsRequestModel2);


            List<PsychologistModel> psychologists = client.ShowAllPsychologistsAsClient(token);
            CollectionAssert.AreEqual(psychologists, myPsycho);

        }

        [TearDown]
        public void td()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query($"delete from BBSK_PsychoDb4.dbo.Client where Email = '{clientEMAIL}'");

            dbConnection.Query($"delete from PsychologistTherapyMethod");
            dbConnection.Query($"delete from Education");
            dbConnection.Query($"delete from ProblemPsychologist");
            dbConnection.Query($"delete from [Order]");
            dbConnection.Query($"delete from Schedule");
            dbConnection.Query($"delete from Comment");
            dbConnection.Query($"delete from Psychologist");
            dbConnection.Close();
        }
        [OneTimeTearDown]
        public void ottd()
        {
           
        }
    }
}

using Dapper;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Model;
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
    public class FilterListPsychologistAsClient
    {
        private const string PASSWORD = "Client1Client";
        private const string clientEMAIL = "client@gmail.com";
        private const string psychoEmail1 = "Zakir@gmail.com";
        private const string psychoEmail2 = "Orxan@gmail.com";
        private const string psychoEmail3 = "Aisha@gmail.com";
        private const string psychoEmail4 = "Lamia@gmail.com";


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
        public void FilterListPsychologistAsClientTest()
        {
            ClientClient client = new ClientClient();

            ClientModelForCreateClient createModel = new ClientModelForCreateClient()
            {
                Name = "client",
                LastName = "clientov",
                Password = PASSWORD,
                Email = clientEMAIL,
                PhoneNumber = "+72222222222",
                BirthDate = new DateTime(1990, 02, 02)
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
                PasportData = "+71111111111",
                Educations = new List<string>() { "BDU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Behaviorall" },
                Problems = new List<string>() { "Family" },
                Price = 210
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
            PsychologistRequestModel psychologistsRequestModel3 = new PsychologistRequestModel() //rabotaet
            {
                Name = "Aisha",
                LastName = "Hajieva",
                Patronymic = "Sakal",
                Gender = 0,
                BirthDate = DateTime.Parse("1998-07-24"),
                Phone = "+73333333333",
                Password = "Aisha1Psycho",
                Email = psychoEmail3,
                WorkExperience = 5,
                PasportData = "33333333",
                Educations = new List<string>() { "ADNSU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Leblegusa" },
                Problems = new List<string>() { "Kayfariki" },
                Price = 120
            };
            PsychologistRequestModel psychologistsRequestModel4 = new PsychologistRequestModel() //rabotaet
            {
                Name = "Lamia",
                LastName = "Valieva",
                Patronymic = "Bilmirem",
                Gender = 0,
                BirthDate = DateTime.Parse("2000-07-25"),
                Phone = "+74444444444",
                Password = "Lamia1Psycho",
                Email = psychoEmail4,
                WorkExperience = 4,
                PasportData = "33333333",
                Educations = new List<string>() { "ATU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Psixopat" },
                Problems = new List<string>() { "Criminal" },
                Price = 69
            };

            PsychologistClient psychologistClient = new PsychologistClient();

            psychologistClient.CreatePsy(psychologistsRequestModel1);
            psychologistClient.CreatePsy(psychologistsRequestModel2);
            psychologistClient.CreatePsy(psychologistsRequestModel3);
            psychologistClient.CreatePsy(psychologistsRequestModel4);

            SearchRequastModel searchRequastModel = new SearchRequastModel()
            {
                Name = psychologistsRequestModel1.Name,
                PhoneNumber = psychologistsRequestModel1.Phone,
                Description = "vse norm slava bogu",
                PsychologistGender = psychologistsRequestModel1.Gender,
                CostMin = 100,
                CostMax = 300,
                Date = psychologistsRequestModel1.BirthDate,
                Time = 2
            };
            int idFromSearch = client.FilterListPsycholoogist(searchRequastModel, token);

            /*CheckClientModel checkClientModel = client.CheckClientById(idFromSearch, token);*/

           /* CheckClientModel checkClient = new CheckClientModel()
            {
                Name = searchRequastModel.Name,
                PhoneNumber = searchRequastModel.PhoneNumber,
                BirthDate = searchRequastModel.Date
            };
            CollectionAssert.AreEqual(checkClient, checkClientModel);*/

        }
    }
}

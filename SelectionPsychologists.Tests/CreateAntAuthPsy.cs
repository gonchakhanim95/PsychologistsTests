global using NUnit.Framework;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Model;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace SelectionPsychologists.Tests
{
    public class CreateAntAuthPsy
    {
        
        private const string EMAIL = "zakirella@gmail.ru";

        [Test]
        public void CreateAntAuthPsyTest()
        {
            PsychologistRequestModel psychologistsRequestModel = new PsychologistRequestModel() //rabotaet
            {
                Name = "Zakir",
                LastName = "Hajiev",
                Patronymic = "Seymur",
                Gender = 1,
                BirthDate = DateTime.Parse("2002-07-24"),
                Phone = "589875641",
                Password = "asdfghjkl",
                Email = EMAIL,
                WorkExperience = 8,
                PasportData = "87444445",
                Educations = new List<string>() { "BDU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Behavioral" },
                Problems = new List<string>() { "Family" },
                Price = 50
            };
            PsychologistClient client = new PsychologistClient();
            client.CreatePsy(psychologistsRequestModel);


            AuthRequestModel authRequestModel = new AuthRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            SuperClient superClient= new SuperClient();
            string token = superClient.Auth(authRequestModel);

            List<PsychologistResponseModel> psychologists = superClient.GetPsy(token);

            /*CollectionAssert.Contains(psychologists, new PsychologistResponseModel());*/
        }


        [TearDown]
        public void TD()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = BBSK_PsychoDb4; Persist Security Info = True; User ID = student; Password = qwe!23";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query($"delete from Education where PsychologistId = (select Id from Psychologist where Email = '{EMAIL}')");
            dbConnection.Query($"delete from ProblemPsychologist");
            dbConnection.Query($"delete from Problem");
            dbConnection.Query($"delete from PsychologistTherapyMethod");
            dbConnection.Query($"delete from Psychologist where Email = '{EMAIL}'");
            dbConnection.Close();
        }
    } 
}
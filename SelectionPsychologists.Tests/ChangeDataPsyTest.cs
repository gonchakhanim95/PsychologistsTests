global using NUnit.Framework;
using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Model;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace SelectionPsychologists.Tests
{
    public class ChangeDataPsyTest
    {
        private const string EMAIL = "zakiriella@gmail.ru";

        [SetUp]
        public void SU()
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
        public void ChangeDataPsyTests()
        {
            PsychologistRequestModel psychologistRequestModel = new PsychologistRequestModel() //rabotaet
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
            var id = client.CreatePsy(psychologistRequestModel);

            AuthRequestModel psyAuth = new AuthRequestModel()
            {
                Email = psychologistRequestModel.Email,
                Password = psychologistRequestModel.Password
            };
            var token = client.AuthPsy(psyAuth);

            psychologistRequestModel.Educations.Add("ATU"); // konkretno menyaem edu

            PsychologistRequestModelWithId psychologistRequestModelWithId = new PsychologistRequestModelWithId()
            {
                Name = psychologistRequestModel.Name,
                LastName = psychologistRequestModel.LastName,
                Patronymic = psychologistRequestModel.Patronymic,
                Gender = psychologistRequestModel.Gender,
                BirthDate = psychologistRequestModel.BirthDate,
                Phone = psychologistRequestModel.Phone,
                Password = psychologistRequestModel.Password,
                Email = psychologistRequestModel.Email,
                WorkExperience = psychologistRequestModel.WorkExperience,
                PasportData = psychologistRequestModel.PasportData,
                Educations = psychologistRequestModel.Educations,
                CheckStatus = psychologistRequestModel.CheckStatus,
                TherapyMethods = psychologistRequestModel.TherapyMethods,
                Problems = psychologistRequestModel.Problems,
                Price = psychologistRequestModel.Price,
                Id = id,
                Schedule = new Schedule
                {
                    AdditionalProp1 = new List<string>() { "asdad" }
                }
            };

            client.ChangePersonalData(psychologistRequestModelWithId, token);

            AuthRequestModel auth = new AuthRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            SuperClient superClient = new SuperClient();
            token = superClient.Auth(auth);
            PsychologistResponseModel responseModel = new PsychologistResponseModel()
            {
                Name=psychologistRequestModel.Name,
                LastName=psychologistRequestModel.LastName,
                Gender=psychologistRequestModel.Gender,
                WorkExperience=psychologistRequestModel.WorkExperience,
                Price=psychologistRequestModel.Price
            };
            
            List<PsychologistResponseModel> list = new List<PsychologistResponseModel>();
            list.Add(responseModel);

            List<PsychologistResponseModel> psychologists = superClient.GetPsy(token);
            CollectionAssert.AreEqual(psychologists, list);

        }

        [TearDown]
        public void TD()
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

    }
}
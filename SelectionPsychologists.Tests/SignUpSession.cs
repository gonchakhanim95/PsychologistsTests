using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionPsychologists.Tests.ClientL;
using SelectionPsychologists.Tests.ModelL;

namespace SelectionPsychologists.Tests
{
    public class SignUpSession
    {
        [Test]
        public void CreateAPsycologicTest()
        {
            PsycologistRequestModel psycologistRequestModel = new PsycologistRequestModel()
            {
                Name = "Goncha",
                LastName = "Gadjiyeva",
                Patronymic = "Agababa",
                Gender = 1,
                BirthDate = DateTime.Parse("1995-07-23T16:08:53.277Z"),
                Phone = "7631097936",
                Password = "davud_davud",
                Email = "gnch_g@mail.ru",
                WorkExperience = 5,
                PasportData = "1234ghj1234",
                Educations = new List<string>() { "BSU" },
                CheckStatus = 1,
                TherapyMethods = new List<string>() { "Psychodynamic" },
                Problems = new List<string>() { "Home" },
                Price = 80
            };
            PsycologistClient PsycologistClient = new PsycologistClient();
            int psycologistId = PsycologistClient.CreateAPsycologist(psycologistRequestModel);

            AuthRequestModel authRequestModel = new AuthRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            SuperClient superClient = new SuperClient();
            string token = superClient.Auth(authRequestModel);

            PsycologistRequestModel psychologistResponseModel = new PsycologistRequestModel()
            {
                Name = psycologistRequestModel.Name,
                LastName = psycologistRequestModel.LastName,
                Gender = psycologistRequestModel.Gender,
                WorkExperience = psycologistRequestModel.WorkExperience,
                Educations = psycologistRequestModel.Educations,
                TherapyMethods = psycologistRequestModel.TherapyMethods,
                Problems = psycologistRequestModel.Problems,
                Price = psycologistRequestModel.Price,
            };
            List<PsycologistRequestModel> psychologists = superClient.GetPsycologist(token);


            ClientRequestModel clientResquestModel = new ClientRequestModel()
            {
                Name = "Leman",
                LastName = "Kerimova",
                Password = "leman_02",
                Email = "lmnkrmv_@mail.ru",
                PhoneNumber = "+74957556983",
                BirthDate = DateTime.Parse("2002-10-03T19:42:09.638Z")
            };
            ClientClient Client = new ClientClient();
            int id = Client.CreateAClient(clientResquestModel);

            AuthRequestModel authAsClient = new AuthRequestModel()
            {
                Email = clientResquestModel.Email,
                Password = clientResquestModel.Password
            };
            Client.AuthAsClient(authAsClient);

            OrderRequestModel orderClientRequestModel = new OrderRequestModel()
            {
                PsychologistId = psycologistId,
                Duration = 1,
                Message = "string",
                SessionDate = DateTime.Parse("2022-11-24T21:20:25.632Z"),
                OrderDate = DateTime.Parse("2022-11-24T21:20:25.632Z"),
                PayDate = DateTime.Parse("2022-11-24T21:20:25.632Z"),
                OrderStatus = 1,
                OrderPaymentStatus = 1
            };
            int orderId = Client.SignUpForASession(token, orderClientRequestModel);

            OrderResponseModel orderResponseModel = new OrderResponseModel()
            {
                Id = orderId,
                PsychologistResponsee = new OrderResponseModel.PsychologistResponse()
                {
                    Id = orderClientRequestModel.PsychologistId,
                    Name = psychologistResponseModel.Name,
                    LastName = psychologistResponseModel.LastName,
                    Patronymic = psycologistRequestModel.Patronymic,
                    Gender = psychologistResponseModel.Gender,
                    BirthDate = psycologistRequestModel.BirthDate,
                    Phone = psycologistRequestModel.Phone,
                    Email = psycologistRequestModel.Email,
                    WorkExperience = psychologistResponseModel.WorkExperience,
                    PasportData = psycologistRequestModel.PasportData,
                    Education = psychologistResponseModel.Educations,
                    CheckStatus = psycologistRequestModel.CheckStatus,
                    /*TherapyMethods =psychologistResponseModel.TherapyMethods,
                    Problems = psychologistResponseModel.Problems,*/
                    Price = psychologistResponseModel.Price,
                    Schedule = "null",
                    DenyMessage = "null"
                },
                Cost = 100,
                Duration = 1,
                Message = "string",
                SessionDate = DateTime.Parse("2022 - 11 - 24T00: 00:00"),
                OrderDate = DateTime.Parse("2022 - 11 - 24T00: 00:00"),
                PayDate = DateTime.Parse("2022 - 11 - 24T00: 00:00"),
                OrderStatus = 1,
                OrderPaymentStatus = 1
            };
        }

        /*[TearDown]
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
        }*/

    }
}

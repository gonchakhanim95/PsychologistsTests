using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectionPsychologists.Tests.ModelL;
using SelectionPsychologists.Tests.ClientL;

namespace SelectionPsychologists.Tests
{
    public class EditProfileClient
    {
        [Test]
        public void EditProfileAsClientTest()
        {
            ClientRequestModel clientRequestModel = new ClientRequestModel()
            {
                Name = "Leman",
                LastName = "Kerimova",
                Password = "leman02",
                Email = "lemankerimovaaa@mail.ru",
                PhoneNumber = "+74957556983",
                BirthDate = DateTime.Parse("2002-10-03T19:42:09.638Z")
            };
            ClientClient Client = new ClientClient(); 
            int id = Client.CreateAClient(clientRequestModel);

            AuthRequestModel authAsClient = new AuthRequestModel()
            {
                Email = clientRequestModel.Email,
                Password = clientRequestModel.Password,
            };
            string token = Client.AuthAsClient(authAsClient);

            ClientRequestModel clientRequestModell = new ClientRequestModel()
            {
                Name = clientRequestModel.Name,
                LastName = clientRequestModel.LastName,
                BirthDate = DateTime.Parse("2002-10-04T19:42:09.638Z")
            };
            Client.EditProfileAsClient(id, clientRequestModell, token);

            ClientResponseModel clientResponseModel = new ClientResponseModel()
            {
                Id = id,
                Name = clientRequestModel.Name, 
                LastName = clientRequestModel.LastName, 
                Email = clientRequestModel.Email,
                PhoneNumber = clientRequestModel.PhoneNumber,
                BirthDate = clientRequestModel.BirthDate
            };
            ClientRequestModel responseClient = Client.GetChangedClientProfile(id);
        }

        /*[TearDown]
        public void td()
        {
            string connectionString = @"Data Source = 86.78.240.16; Initial Catalog = DevEdu.Test; Persist Security Info = True; User ID = student; Password = qwe!123";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query("");
            dbConnection.Close();
        }*/
    }
}

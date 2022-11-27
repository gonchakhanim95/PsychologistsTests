using SelectionPsychologists.Tests.Client;
using SelectionPsychologists.Tests.Model;

namespace SelectionPsychologists.Tests
{
    public class Tests
    {
        [Test]
        public void CreatePsyTest()
        {
            PsychologistRequestModel psychologistsRequestModel = new PsychologistRequestModel() 
            {
                Name = "Zakir",
                LastName = "Hajiev",
                Patronymic = "Seymur",
                Gender = 1,
                BirthDate = DateTime.Parse("2002-07-24"),
                Phone = "589875641",
                Password = "asdfghjkl",
                Email = "asdfg@mail.ru",
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
        }
        [Test]
        public void AuthPsy()
        {
            AuthRequestModel authRequestModel = new AuthRequestModel() 
            {
                Email = "haciyevzakir@mail.ru",
                Password = "asdfghjkl"
            };
            PsychologistClient client = new PsychologistClient();

            string token = client.Auth(authRequestModel);

            List<PsychologistResponseModel> psychologists = client.GetPsy(token);

            CollectionAssert.Contains(psychologists, new PsychologistResponseModel());
        }
    } 
}
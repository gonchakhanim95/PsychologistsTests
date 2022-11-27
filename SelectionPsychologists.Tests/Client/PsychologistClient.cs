using SelectionPsychologists.Tests.Model;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SelectionPsychologists.Tests.Client
{
    public class PsychologistClient
    {
        public string AuthPsy(AuthRequestModel model) // reqistr kak psixolog
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<AuthRequestModel>(model); // body

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Auth"),
                Content = new StringContent(json, Encoding.UTF8, "application/json") // esli est body
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode; // sverit code
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }

        public int CreatePsy(PsychologistRequestModel model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<PsychologistRequestModel>(model);
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Psychologists"),
                Content = new StringContent(json, Encoding.UTF8, "application/json") // esli est body
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
            int Id = Int32.Parse(responseMessage.Content.ReadAsStringAsync().Result);
            return Id;
        }

        public void ChangePersonalData(PsychologistRequestModelWithId model, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            string json = JsonSerializer.Serialize<PsychologistRequestModelWithId>(model);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Psychologists/{model.Id}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json") // esli est body
            };

            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            List<PsychologistResponseModel> psychologists = JsonSerializer.Deserialize<List<PsychologistResponseModel>>(responseJson)!;

            return psychologists;
        }
    }
}

using SelectionPsychologists.Tests.Model;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SelectionPsychologists.Tests.Client
{
    public class SuperClient
    {
        public string Auth(AuthRequestModel model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<AuthRequestModel>(model);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Auth"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }


    }
}

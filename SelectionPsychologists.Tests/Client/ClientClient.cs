using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SelectionPsychologists.Tests.Models;

namespace SelectionPsychologists.Tests.Client
{
    public class ClientClient
    {
        public int CreateClient(ClientModelForCreateClient model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<ClientModelForCreateClient>(model);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Clients"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int Id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);
            return Id;

        }

        public string AuthClient(ClientModelForAuthClient model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<ClientModelForAuthClient>(model);

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

        public List<PsychologistModel> ShowAllPsychologistsAsClient(string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Psychologists"),
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            List<PsychologistModel> psychologistsModels = new List<PsychologistModel>();
            psychologistsModels = JsonSerializer.Deserialize<List<PsychologistModel>>(responseMessage.Content.ReadAsStringAsync().Result);

            return psychologistsModels;
        }
       
        public CheckClientModel CheckClientByIdAfterDelete(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Clients/{id}")
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actuaLCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actuaLCode);

            CheckClientModel clientModel = JsonSerializer.Deserialize<CheckClientModel>(responseMessage.Content.ReadAsStringAsync().Result);
            return clientModel;
        }
        public CheckClientModel CheckClientById(int id, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Clients/{id}")
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actuaLCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actuaLCode);

            CheckClientModel clientModel = JsonSerializer.Deserialize<CheckClientModel>(responseMessage.Content.ReadAsStringAsync().Result);
            return clientModel;
        }

        public int FilterListPsycholoogist(SearchRequastModel model,string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<SearchRequastModel>(model);


            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/search-requests"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actuaLCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actuaLCode);

            int idFromSearch = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return idFromSearch;
        }

        public PsychologistModel FilterListPsycholoogistGetId(int problem)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Psychologists/search-by-parametrs?Price=1&Problems={problem}"),
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actuaLCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actuaLCode);

            PsychologistModel psychoModel = JsonSerializer.Deserialize<PsychologistModel>(responseMessage.Content.ReadAsStringAsync().Result);
            return psychoModel;
        }

        public void DeleteClient(int id,string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Clients/{id}"),
            };

            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
        }
    }
}

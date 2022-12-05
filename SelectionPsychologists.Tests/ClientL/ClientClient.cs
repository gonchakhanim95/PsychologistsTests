using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using SelectionPsychologists.Tests.ModelL;

namespace SelectionPsychologists.Tests.ClientL
{
    public class ClientClient
    {
        public int CreateAClient(ClientRequestModel clientResquestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;  //201

            string json = JsonSerializer.Serialize<ClientRequestModel>(clientResquestModel);

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, ssPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(handler);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Clients"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage responsemessage = client.Send(message);

            HttpStatusCode actualCode = responsemessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responsemessage.Content.ReadAsStringAsync().Result);
            return id;
        }
        public string AuthAsClient(AuthRequestModel model)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK; //200
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
        public int SignUpForASession(string token, OrderRequestModel orderClientRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created; //201
            string json = JsonSerializer.Serialize<OrderRequestModel>(orderClientRequestModel);

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, ssPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Orders"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            int orderId = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);
            return orderId;
        }

        public OrderResponseModel GetOrderWithId(int orderid)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;  //200

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, ssPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(handler);

            //client.DefaultRequestHeaders.Authorization = new AuthorizationHeaderValue("Bearer", token)

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Orders/{orderid}")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            //string responseJson = responseMessage.Content.ReadAsStringAsync().Result;

            OrderResponseModel Order = JsonSerializer.Deserialize<OrderResponseModel>(responseMessage.Content.ReadAsStringAsync().Result);
            return Order;
        }
    }
}

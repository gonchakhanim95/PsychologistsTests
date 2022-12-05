using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SelectionPsychologists.Tests.ModelL;

namespace SelectionPsychologists.Tests.ClientL
{
    public class PsycologistClient
    {
        public int CreateAPsycologist(PsycologistRequestModel psycologistRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;  //201

            string json = JsonSerializer.Serialize<PsycologistRequestModel>(psycologistRequestModel);

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, ssPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(handler);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10040/Psychologists"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage responsemessage = client.Send(message);

            HttpStatusCode actualCode = responsemessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int psycologistId = Convert.ToInt32(responsemessage.Content.ReadAsStringAsync().Result);
            return psycologistId;
        }
    }
}

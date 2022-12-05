using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests.ModelL
{
    public class OrderResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("psychologistResponse")]
        public PsychologistResponse PsychologistResponsee { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("sessionDate")]
        public DateTime SessionDate { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("payDate")]
        public DateTime PayDate { get; set; }

        [JsonPropertyName("orderStatus")]
        public int OrderStatus { get; set; }

        [JsonPropertyName("orderPaymentStatus")]
        public int OrderPaymentStatus { get; set; }

        public class PsychologistResponse
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("lastName")]
            public string LastName { get; set; }

            [JsonPropertyName("patronymic")]
            public string Patronymic { get; set; }

            [JsonPropertyName("gender")]
            public int Gender { get; set; }

            [JsonPropertyName("birthDate")]
            public DateTime BirthDate { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("workExperience")]
            public int WorkExperience { get; set; }

            [JsonPropertyName("pasportData")]
            public string PasportData { get; set; }

            [JsonPropertyName("education")]
            public object Education { get; set; }

            [JsonPropertyName("checkStatus")]
            public int CheckStatus { get; set; }

            [JsonPropertyName("therapyMethods")]
            public List<object> TherapyMethods { get; set; }

            [JsonPropertyName("problems")]
            public List<object> Problems { get; set; }

            [JsonPropertyName("price")]
            public int Price { get; set; }

            [JsonPropertyName("schedule")]
            public object Schedule { get; set; }

            [JsonPropertyName("denyMessage")]
            public object DenyMessage { get; set; }
        }
    }
}

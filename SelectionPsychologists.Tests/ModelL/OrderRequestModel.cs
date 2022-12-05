using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests.ModelL
{
    public class OrderRequestModel
    {
        [JsonPropertyName("psychologistId")]
        public int PsychologistId { get; set; }

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
    }
}

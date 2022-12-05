using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests.Models
{
    public class CheckClientModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CheckClientModel model &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Email == model.Email &&
                   PhoneNumber == model.PhoneNumber &&
                   BirthDate == model.BirthDate;
        }
        
    }
}

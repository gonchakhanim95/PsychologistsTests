using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests.Model
{
    public class PsychologistResponseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("workExperience")]
        public int WorkExperience { get; set; }

        [JsonPropertyName("education")]
        public object Education { get; set; }

        [JsonPropertyName("therapyMethods")]
        public List<object> TherapyMethods { get; set; }

        [JsonPropertyName("problems")]
        public List<object> Problems { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PsychologistResponseModel model &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Gender == model.Gender &&
                   WorkExperience == model.WorkExperience &&
                   Price == model.Price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

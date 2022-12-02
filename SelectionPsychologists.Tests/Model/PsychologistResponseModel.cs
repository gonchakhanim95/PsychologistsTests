using System.Text.Json.Serialization;

namespace DeletePsy.Model
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
    }
}

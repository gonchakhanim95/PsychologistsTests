using System.Text.Json.Serialization;

namespace SelectionPsychologists.Tests.Model
{
    public class PsychologistRequestModelWithId : PsychologistRequestModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }
    }

    public class Schedule
    {
        [JsonPropertyName("additionalProp1")]
        public List<string> AdditionalProp1 { get; set; }

        [JsonPropertyName("additionalProp2")]
        public List<string> AdditionalProp2 { get; set; }

        [JsonPropertyName("additionalProp3")]
        public List<string> AdditionalProp3 { get; set; }
    }
}

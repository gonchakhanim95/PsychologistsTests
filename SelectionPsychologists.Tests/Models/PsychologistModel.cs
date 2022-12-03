using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelectionPsychologists.Tests.Models
{

    public class Problem
    {
        [JsonPropertyName("problemName")]
        public string problemName { get; set; }
    }

    public class TherapyMethod
    {
        [JsonPropertyName("method")]
        public string method { get; set; }
    }

    public class PsychologistModel
    {

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("gender")]
        public int gender { get; set; }

        [JsonPropertyName("workExperience")]
        public int workExperience { get; set; }

        [JsonPropertyName("education")]
        public List<string> education { get; set; }

        [JsonPropertyName("therapyMethods")]
        public List<TherapyMethod> therapyMethods { get; set; }

        [JsonPropertyName("problems")]
        public List<Problem> problems { get; set; }

        [JsonPropertyName("price")]
        public double price { get; set; }

    }
}

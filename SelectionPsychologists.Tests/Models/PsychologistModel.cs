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

        public override bool Equals(object? obj)
        {
            return obj is Problem problem &&
                   problemName == problem.problemName;
        }
    }

    public class TherapyMethod
    {
        [JsonPropertyName("method")]
        public string method { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TherapyMethod method &&
                   this.method == method.method;
        }
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

        public override bool Equals(object? obj)
        {
            return obj is PsychologistModel model &&
                   name == model.name &&
                   lastName == model.lastName &&
                   gender == model.gender &&
                   workExperience == model.workExperience &&
                   price == model.price;
        }

       /* public override string ToString()
        {
            return name;
        }*/
    }
}

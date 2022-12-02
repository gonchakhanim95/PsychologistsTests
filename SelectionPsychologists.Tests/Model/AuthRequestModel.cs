using System.Text.Json.Serialization;

namespace DeletePsy.Model
{
    public class AuthRequestModel
    {

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
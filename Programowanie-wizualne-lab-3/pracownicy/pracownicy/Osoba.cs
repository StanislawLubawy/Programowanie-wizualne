using System.Text.Json.Serialization;

namespace pracownicy
{
    public class Osoba
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("LastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        [JsonPropertyName("Position")]
        public string Position { get; set; } = string.Empty;
    }
}

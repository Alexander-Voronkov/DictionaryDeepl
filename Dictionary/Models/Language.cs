using System;
using System.Text.Json.Serialization;

namespace Dictionary.Models
{
    [Serializable]
    public class Language
    {
        [JsonPropertyName("language")]
        public string ShortForm { get; set; }

        [JsonPropertyName("name")]
        public string LongForm { get; set; }

        public override string ToString()
        {
            return LongForm;
        }
    }
}

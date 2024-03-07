using System;
using System.Text.Json.Serialization;

namespace Dictionary.Models
{
    [Serializable]
    public class Word
    {
        [JsonPropertyName("detected_source_language")]
        public string Language { get; set; }

        [JsonPropertyName("text")]
        public string WordText { get; set; }

        public override bool Equals(object other)
        {
            if (other is Word w)
            {
                return WordText.Equals(w.WordText, StringComparison.InvariantCultureIgnoreCase)
                    && Language.Equals(w.Language, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"{Language}{WordText}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{WordText} - {Language}";
        }
    }
}
using Dictionary.Configurations;
using Dictionary.Exceptions;
using Dictionary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Dictionary.Extensions
{
    public static partial class Extensions
    {
        public static List<Language> GetLanguageList(this HttpClient client)
        {
            var response = client
                .GetAsync($"https://api-free.deepl.com/v2/languages?" +
                $"auth_key={DictionaryConfiguration.DeeplApiKey}")
                .Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new LanguageLoadError("Error while getting the list of languages");
            }

            var stream = response.Content.ReadAsStreamAsync().Result;

            var languages = JsonSerializer.DeserializeAsync<List<Language>>(stream, JsonSerializerOptions.Default).Result;

            return languages;
        }

        public static Word GetWordTranslation(
            this HttpClient client,
            string word,
            string targetLanguage)
        {
            var response = client
                .GetAsync($"https://api-free.deepl.com/v2/translate?" +
                $"auth_key={DictionaryConfiguration.DeeplApiKey}" +
                $"&text={word}" +
                $"&target_lang={targetLanguage}")
                .Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new TranslationLoadError("Error while getting the translation of the word");
            }

            var content = response.Content.ReadAsStringAsync().Result;

            var stream = response.Content.ReadAsStreamAsync().Result;

            var words = JsonSerializer.DeserializeAsync<IDictionary<string, Word[]>>(stream, JsonSerializerOptions.Default).Result;

            return words["translations"].FirstOrDefault();
        }
    }
}
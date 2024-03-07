using System.Configuration;

namespace Dictionary.Configurations
{
    public static class DictionaryConfiguration
    {
        public static readonly string DeeplApiKey;

        static DictionaryConfiguration()
        {
            DeeplApiKey = ConfigurationManager.AppSettings.Get("deeplApiKey");
        }
    }
}

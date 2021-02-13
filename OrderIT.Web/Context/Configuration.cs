using System.Collections.Specialized;
using System.Configuration;

namespace OrderIT.Web
{
    public static class Configuration
    {
        private static readonly ConnectionStringSettingsCollection _connectionStrings = ConfigurationManager.ConnectionStrings;
        private static readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        internal static ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return _connectionStrings; }
        }

        internal static NameValueCollection AppSettings
        {
            get { return _appSettings; }
        }

        internal static object UnitySection
        {
            get { return ConfigurationManager.GetSection(ConfigurationKeys.Unity); }
        }

        public static string ConnectionString
        {
            get { return Configuration.ConnectionStrings[ConfigurationKeys.ConnectionString].ConnectionString; }
        }

    }
}

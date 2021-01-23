using Microsoft.Extensions.Configuration;

namespace ADONET_WPF.Infrastructure.Services
{
    static class ConfigurationService
    {
        public static IConfigurationRoot Config { get; private set; }
        static ConfigurationService()
        {
            ConfigurationBuilder builder = new();
            builder.AddJsonFile("appsettings.json");
            Config = builder.Build();
        }

        public static string GetSectionValue(params string[] sections)
        {
            IConfigurationSection s = Config.GetSection(sections[0]);
            for (int i = 1; i < sections.Length; i++)
            {
                s = s.GetSection(sections[i]);
                if (i == sections.Length - 1) return s.Value;
            }

            return string.Empty;
        }
    }
}

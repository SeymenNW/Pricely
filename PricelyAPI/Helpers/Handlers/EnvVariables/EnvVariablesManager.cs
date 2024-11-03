using System.Security.Cryptography.X509Certificates;

namespace PricelyAPI.Helpers.Handlers.EnvVariables
{
    public static class EnvVariablesManager
    {
        static EnvVariablesManager()
        {
            DotNetEnv.Env.Load();
        }

        public static string ProxyUrl => Environment.GetEnvironmentVariable("PROXY__URL");
        public static string ProxyUsername => Environment.GetEnvironmentVariable("PROXY__USERNAME");
        public static string ProxyPassword => Environment.GetEnvironmentVariable("PROXY__PASSWORD");
    }
}

using System.Security.Cryptography.X509Certificates;

namespace PricelyAPI.Helpers.Handlers.EnvVariables
{
    public static class EnvVariablesManager
    {
        //Det er her Env Variables bliver loaded ind.
        
        public static string ProxyUrl { get { DotNetEnv.Env.Load(); return Environment.GetEnvironmentVariable("PROXY__URL"); } }
        public static string ProxyUsername { get { DotNetEnv.Env.Load(); return Environment.GetEnvironmentVariable("PROXY__USERNAME"); } }
        public static string ProxyPassword { get { DotNetEnv.Env.Load(); return Environment.GetEnvironmentVariable("PROXY__PASSWORD"); } }




    }
}

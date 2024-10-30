using System.Net;
using DotNetEnv;
using PricelyAPI.Helpers.Handlers.EnvVariables;

namespace PricelyAPI.Helpers.Handlers
{
    public static class ProxyManager
    {

        public static HttpClientHandler AddRotatingProxy()
        {
            //På Pricely.dk bliver en rotating proxy brugt. 
            //Men af gode grunde kan jeg ikke bare tilføje link til den her..
            Env.Load();
            string proxyUrl = EnvVariablesManager.ProxyUrl;
            string proxyUsername = EnvVariablesManager.ProxyUsername;
            string proxyPassword = EnvVariablesManager.ProxyPassword;

            if (string.IsNullOrEmpty(proxyUrl) || string.IsNullOrEmpty(proxyUsername) || string.IsNullOrEmpty(proxyPassword))
            {
               //Dette sørger for at appen ikke crasher hvis du ikke bruger en proxy.
                return new HttpClientHandler();
            }

            WebProxy proxy = new WebProxy
            {
                Address = new Uri(proxyUrl),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(proxyUsername, proxyPassword)
            };

            return new HttpClientHandler
            {
                Proxy = proxy,
                PreAuthenticate = true,
                UseDefaultCredentials = false,
            };


        }
    }
}

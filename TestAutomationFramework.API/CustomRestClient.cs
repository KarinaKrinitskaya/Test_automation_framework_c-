using System;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace TestAutomationFramework.API
{
	public class CustomRestClient
	{
		public readonly ApiConfiguration appConfig = new ();
		public CustomRestClient()
		{
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			config.Bind(appConfig); //связка с конфигом
		}

        public RestClient CreateRestClient(Service service)
		{
			Uri baseUrl;
			switch (service)
			{
				case Service.Biblees:
					baseUrl = appConfig.BiblesBaseUrl;
					break;
				case Service.Phones:
					baseUrl = appConfig.PhonesBaseUrl;
					break;
				default:
					throw new ArgumentException("Invalid service option provided!");
			}

			var options = new RestClientOptions() { BaseUrl = baseUrl };
			var restClient = new RestClient(options);
			return restClient;
		}
    }
}


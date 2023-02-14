using System;
using RestSharp;
namespace TestAutomationFramework.API.Controllers
{
	public class BiblesController : BaseController
	{
		public BiblesController(CustomRestClient client, string apiKey = "") : base (client, Service.Biblees, apiKey)
		{
		}

        public BiblesController(CustomRestClient client) : base(client, Service.Biblees, client.appConfig.ApiKey)
        {
        }

		private const string AllAudioBibles = "/v1/audio-bibles";
        private const string SingleAudioBiblesID = "/v1/audio-bibles/{0}/books";

        public (RestResponse Responce, T Bibles) GetBibles<T>()
		{
			return Get<T>(AllAudioBibles);
		}

        public (RestResponse Responce, T Bibles) GetBible<T>(string id)
        {
            return Get<T>(string.Format(SingleAudioBiblesID, id));
        }
    }
}


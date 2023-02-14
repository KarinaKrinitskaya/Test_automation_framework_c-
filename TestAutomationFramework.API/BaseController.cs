using System;
using Newtonsoft.Json;
using RestSharp;

namespace TestAutomationFramework.API
{
	public class BaseController
	{
		private readonly RestClient restClient;

		protected BaseController(CustomRestClient client , Service service, string apiKey = "")// добавили apiKey для сервисов без авторизации
		{
			restClient = client.CreateRestClient(service);
			if (service == Service.Biblees)
			{
				restClient.AddDefaultHeader("api-key", apiKey);
			}
		}

		protected (RestResponse, T) Get <T>(string resourse)
		{
			var request = new RestRequest(resourse, Method.Get);
			var response = restClient.ExecuteGet(request);
			return typeof(T) == typeof(RestResponse) ? (response, default) : (response, GetDeserializedView<T>(response));

        }

        protected (RestResponse Response, T ResponseModel) Post<T, TPayload>(string resource, TPayload? payload = null) where TPayload : class
        {
            var request = new RestRequest(resource, Method.Post);
            if (payload != null)
                request.AddJsonBody(payload);

            var response = restClient.ExecutePost(request);
            return (typeof(T) == typeof(RestResponse))
                ? (response, default)
                : (response, GetDeserializedView<T>(response));
        }

        protected (RestResponse Response, T? ResponseModel) Delete<T>(string resource)
        {
            var request = new RestRequest(resource, Method.Delete);
            var response = restClient.Delete(request);

            return typeof(T) == typeof(RestResponse)
                ? (response, default)
                : (response, GetDeserializedView<T>(response));
        }

        protected (RestResponse Response, T? ResponseModel) Update<T, TPayload>(string resource, TPayload? payload = null)
        where TPayload : class
        {
            var request = new RestRequest(resource, Method.Put);
            if (payload != null)
                request.AddJsonBody(payload);

            var response = restClient.ExecutePost(request);
            return (typeof(T) == typeof(RestResponse))
                ? (response, default)
                : (response, GetDeserializedView<T>(response));
        }

        private T GetDeserializedView<T>(RestResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.Content);
		}

	}
}


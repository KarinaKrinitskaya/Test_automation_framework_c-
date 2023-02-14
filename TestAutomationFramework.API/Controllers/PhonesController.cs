using System;
using RestSharp;
using TestAutomationFramework.API.Models.RequestModels.Phone;

namespace TestAutomationFramework.API.Controllers
{
	public class PhonesController : BaseController
	{
		public PhonesController(CustomRestClient client) : base(client, Service.Phones)
        {
		}

        private const string AllObjects = "/objects";
        private const string SinglePhoneID = "/objects?id={0}";
        private const string SinglePhone = "/objects/{0}";


        public (RestResponse Responce, T Phones) GetPhones<T>()
        {
            return Get<T>(AllObjects);
        }

        public (RestResponse Response, T Phone) GetPhonesID<T>(string id)
        {
            return Get<T>(string.Format(SinglePhoneID, id));
        }

        public (RestResponse Response, T Phone) GetPhones<T>(string id)
        {
            return Get<T>(string.Format(SinglePhone, id));
        }

        public (RestResponse Response, T Phone) AddPhone<T>(PhoneModel model)
        {
            return Post<T, PhoneModel>(AllObjects, model);
        }

        public (RestResponse Response, T Phone) DeletePhone<T>(string id)
        {
            return Delete<T>(string.Format(SinglePhone, id));
        }
    }
}


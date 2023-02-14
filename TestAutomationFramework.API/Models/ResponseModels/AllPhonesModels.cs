using System;
using Newtonsoft.Json;
using TestAutomationFramework.API.Models.SharedModelsPhone;

namespace TestAutomationFramework.API.Models.ResponseModels
{
    public class AllPhonesModels
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public PhonesData data { get; set; }

        public DateTime createdAt { get; set; }
    }
}


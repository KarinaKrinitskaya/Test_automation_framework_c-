using System;
using Newtonsoft.Json;

namespace TestAutomationFramework.API.Models.SharedModelsPhone
{
	public class PhonesData
	{
        public string color { get; set; }
        public string capacity { get; set; }

        [JsonProperty("capacity GB")]
        public int? capacityGB { get; set; }
        public double? price { get; set; }
        public string generation { get; set; }
        public int? year { get; set; }

        [JsonProperty("CPU model")]
        public string CPUmodel { get; set; }

        [JsonProperty("Hard disk size")]
        public string Harddisksize { get; set; }

        [JsonProperty("Strap Colour")]
        public string StrapColour { get; set; }

        [JsonProperty("Case Size")]
        public string CaseSize { get; set; }

        [JsonProperty("Screen size")]
        public double? Screensize { get; set; }
    }
}


using System;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace TestAutomationFramework.Utilities.Parser
{
	public class JSONparser
	{
        public static T DeserializeJsonToObject<T>(string json) where T : class => JsonConvert.DeserializeObject<T>(File.ReadAllText(json));

        public static string SerializeJson(object content) => JsonConvert.SerializeObject(content);

        public static List<T> DeserializeJsonToObjects<T>(string json) where T : class => JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(json));
    }
}


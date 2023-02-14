using System;
using TestAutomationFramework.API.Models.ResponseModels;
using TestAutomationFramework.API.Models.SharedModelsPhone;

namespace TestAutomationFramework.API.Models.RequestModels.Phone
{

        public class PhoneModel
        {
            public string name { get; set; }
            public PhonesData data { get; set; }
        }
}


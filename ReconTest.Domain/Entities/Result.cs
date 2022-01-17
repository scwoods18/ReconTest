using Newtonsoft.Json;
using ReconTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReconTest.Domain.Entities
{
    public class Result : EntityBase
    {
        string subtext { get; set; }

        string result { get; set; }

        [JsonProperty("subtext")]
        public string SubText { get => subtext; set => subtext = value; }

        [JsonProperty("result")]
        public string ResultValue { get => result; set => result = value; }
      
        public Result(string subText, string resultValue)
        {
            this.SubText = subText;
            this.ResultValue = resultValue;
        }
    }
}

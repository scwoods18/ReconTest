using Newtonsoft.Json;
using ReconTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReconTest.Domain.Entities
{
    public class SubText : EntityBase
    {
        string[] subTexts { get; set; }


        [JsonProperty("subTexts")]
        public string[] SubTexts { get => subTexts  ; set => subTexts = value; }

        public SubText(string[] subTexts)
        {
            this.SubTexts = subTexts;
        }
    }
}

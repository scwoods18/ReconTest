using Newtonsoft.Json;
using ReconTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReconTest.Domain.Entities
{
    public class Text : EntityBase
    {
        string text { get; set; }
        Guid id { set; get; }

        [JsonProperty("text")]
        public string Value { get => text; set => text = value; }

        public Text(string text) 
        {
            this.Value = text;
        }
    }
}

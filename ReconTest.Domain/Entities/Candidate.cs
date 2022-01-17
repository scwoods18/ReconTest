using Newtonsoft.Json;
using ReconTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReconTest.Domain.Entities
{
    public class Candidate : EntityBase
    {
        string candidate { get; set; }
        string text { get; set; }
        List<Result> results { get; set; }

        [JsonProperty("candidate")]
        public string Name { get => candidate; set => candidate = value; }

        [JsonProperty("text")]
        public string Text { get => text; set=> text= value; }

        [JsonProperty("results")]
        public List<Result> Results { get=> results; set=> results= value; }
        public Candidate(string name, string text) 
        {
            this.Name = name;
            this.Text = text;
            this.results = new List<Result>();
        
        }
    }
}

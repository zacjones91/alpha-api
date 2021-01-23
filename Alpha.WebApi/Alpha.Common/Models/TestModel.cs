using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Alpha.Common.Models
{
    public class TestModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

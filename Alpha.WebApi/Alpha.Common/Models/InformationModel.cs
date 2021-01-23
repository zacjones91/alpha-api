using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Alpha.Common.Models
{
    public class InformationModel
    {
        [JsonPropertyName("informationId")]
        public Guid InformationId { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("informationMessage")]
        public string InformationMessage { get; set; }

        [JsonPropertyName("informationTime")]
        public DateTime InformationTime { get; set; }
    }
}

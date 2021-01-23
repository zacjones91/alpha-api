using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Alpha.Common.Enums;

namespace Alpha.Common.Models
{
    public class ErrorModel
    {
        [JsonPropertyName("errorId")]
        public Guid ErrorId { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("errorCode")]
        public ErrorCodeEnum ErrorCode { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("errorTime")]
        public DateTime ErrorTime { get; set; }
    }
}

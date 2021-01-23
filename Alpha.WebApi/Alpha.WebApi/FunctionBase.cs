using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alpha.Common.Enums;
using Alpha.Common.Models;
using Microsoft.Extensions.Logging;

namespace Alpha.WebApi
{
    public abstract class FunctionBase
    {
        protected virtual ErrorModel CreateLogError(string methodName, ErrorCodeEnum errorCodeEnum, string errorMessage,
            ILogger log)
        {
            var error = new ErrorModel()
            {
                ErrorId = Guid.NewGuid(),
                Method = methodName,
                ErrorCode = errorCodeEnum,
                ErrorMessage = errorMessage,
                ErrorTime = DateTime.UtcNow
            };

            log.LogError(JsonSerializer.Serialize(error));

            return error;
        }

        protected virtual void CreateLogInfo(string methodName, string infoMessage, ILogger log)
        {
            var infoModel = new InformationModel()
            {
                InformationId = Guid.NewGuid(),
                InformationMessage = infoMessage,
                InformationTime = DateTime.UtcNow,
                Method = methodName
            };

            log.LogInformation(JsonSerializer.Serialize(infoModel));
        }
    }
}

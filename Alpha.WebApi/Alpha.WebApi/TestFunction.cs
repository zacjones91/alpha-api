using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using Alpha.Common.Enums;
using Alpha.Common.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Alpha.WebApi
{
    public class TestFunction : FunctionBase
    {
        [FunctionName(nameof(RunTest))]
        public static async Task<IActionResult> RunTest(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName(nameof(PostTest))]
        public async Task<IActionResult> PostTest([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            try
            {
                var requestBody = new StreamReader(req.Body).ReadToEnd();

                var data = JsonSerializer.Deserialize<TestModel>(requestBody);

                log.LogInformation($"Data received, {data.Name}");

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                var errorModel = CreateLogError(ex.TargetSite.Name, ErrorCodeEnum.InternalServerError, ex.Message, log);
                return new BadRequestObjectResult(errorModel);
            }
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Alpha.Common.Enums;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Alpha.WebApi
{
    public class PortfolioFunction : FunctionBase
    {
        private readonly ITransactionService transactionService;

        public PortfolioFunction(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [FunctionName(nameof(AddTransaction))]
        public async Task<IActionResult> AddTransaction(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var data = JsonSerializer.Deserialize<Transaction>(requestBody);

                await transactionService.AddTransactionAsync(data);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                var errorModel = CreateLogError(ex.TargetSite?.Name, ErrorCodeEnum.InternalServerError, ex.Message, log);
                return new BadRequestObjectResult(errorModel);
            }
        }
    }
}

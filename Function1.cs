using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;

public static class GreetingFunction
{
	[FunctionName("GreetingFunction")]
	public static async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
		ILogger log)
	{
		log.LogInformation("Greeting function processed a request.");

		string name = req.Query["name"];

		if (string.IsNullOrEmpty(name))
		{
			return new BadRequestObjectResult("Please pass a name on the query string or in the request body.");
		}

		return new OkObjectResult($"Hello, {name}! This is your Azure Function microservice.");
	}
}

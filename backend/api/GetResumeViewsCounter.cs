
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeViewsCounter
    {
        [FunctionName("GetResumeViewsCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "MyAzureResume",
                containerName: "Counter",
                Connection = "AzureCosmosDBConnectionString",
                Id = "1",
                PartitionKey = "1"
            )] Counter counter,
            [CosmosDB(
                databaseName: "MyAzureResume",
                containerName: "Counter",
                Connection = "AzureCosmosDBConnectionString",
                Id = "1",
                PartitionKey = "1"
            )] out Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (counter == null){
                log.LogInformation("counter is null");
            }
            updatedCounter = counter;
            updatedCounter.Count++;

            var json = JsonConvert.SerializeObject(counter);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

        }
    }
}

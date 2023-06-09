using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using static System.Net.WebRequestMethods;

namespace SmartDigitalPsicoFunctions
{
    public static class SDPReceiveMessagePatient
    {
        [FunctionName("SDPReceiveMessagePatient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string patientIdentity = req.Query["patientIdentity"];

            string message = req.Query["message"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            patientIdentity = patientIdentity ?? data?.patientIdentity;
            message = message ?? data?.message;

            var objMsg = new
            {
                patientIdentity = patientIdentity,
                name = name,
                message = message,
            }; 

            var objMsgJson = JsonConvert.SerializeObject(objMsg);

            string responseMessage = string.IsNullOrEmpty(name)
                   ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                   : $"Hello, {patientIdentity} -   {message}-   {name} - . This HTTP triggered function executed successfully.";

            //https://az204funcao1.azurewebsites.net/api/SDPReceiveMessagePatient?code=ycJEVCE-uFINrDErc-ZdRj1AfWrEf6cA9mAM4Onvl6K1AzFu4V1hJg==&name=leone

            // Recuperar a string de conexão do Azure Storage Queue
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=myresourcegroup8855;AccountKey=ftn/G1c+qDdSvOvGqXQfxRgoErCHsjpHDgb7JblWLTshNBqBapIi4MxoR003+Dhn+dagKqJM4HUA+AStRoY+ug==;EndpointSuffix=core.windows.net";

            // Nome da fila
            string queueName = "outqueue";

            // Criar a referência para a fila
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Criar uma mensagem e adicionar na fila
            CloudQueueMessage messageQuee = new CloudQueueMessage(objMsgJson);
            await queue.AddMessageAsync(messageQuee);

            return new OkObjectResult(responseMessage);
        }
    }
}

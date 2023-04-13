using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MoveOrders.Models.BaseLinkerModels;
using MoveOrders.Models.FaireModels;
using Newtonsoft.Json;
using RestSharp;

namespace MoveOrders
{
    public class MoveOrders
    {
        [FunctionName("MoveOrders")]
        public void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var faireAccessToken = Environment.GetEnvironmentVariable("X-FAIRE-ACCESS-TOKEN");
            var baseLinkerToken = Environment.GetEnvironmentVariable("X-BLToken");

            var faireOrders = GetOrdersFromFaire(faireAccessToken).Where(order=> order.CreatedAt == myTimer.ScheduleStatus.Last || order.UpdatedAt == myTimer.ScheduleStatus.Last).DistinctBy(order => order.Id).ToList();
            var baseLinkerOrders = ConvertFaireToBaseLinkerOrder(faireOrders);

            AddBaseLinkerOrders(baseLinkerOrders, baseLinkerToken);
        }

        private static List<FaireOrder> GetOrdersFromFaire(string accessToken)
        {
            var client = new RestClient("https://www.faire.com/external-api/v2/orders");
            var request = new RestRequest();
            request.AddHeader("X-FAIRE-ACCESS-TOKEN", accessToken);

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<FaireOrder>>(response.Content);
        }

       private static void AddBaseLinkerOrders(List<BaseLinkerOrder> orders, string baselinkerToken)
        {
            var client = new RestClient("https://api.baselinker.com/connector.php");

            foreach (var baseLinkerOrder in orders) // W dokumentacji BaseLinkera nie ma metody, ktora pozwolilaby na jednorazowe dodanie wszystkich zamowien, wiec dodaje po jednym.
            {

                var request = new RestRequest("https://api.baselinker.com/connector.php", Method.Post);

                request.AddParameter("token", baselinkerToken);
                request.AddParameter("method", "addOrder");
                request.AddParameter("parameters", JsonConvert.SerializeObject(baseLinkerOrder));

                client.Execute(request);
            }
        }

       private static List<BaseLinkerOrder> ConvertFaireToBaseLinkerOrder(List<FaireOrder> faireOrders)
        {
            var baseLinkerOrders = new List<BaseLinkerOrder>();

            foreach (var faireOrder in faireOrders)
            {
                var convertedBaseLinkerOrder = new BaseLinkerOrder()
                {
                    OrderStatusId = 8069,
                    CustomSourceId = 1024,
                    Phone = faireOrder.Address.PhoneNumber,
                    ExtraField1 = faireOrder.Id,
                };
                baseLinkerOrders.Add(convertedBaseLinkerOrder);
            }

            return baseLinkerOrders;
        }
    }
}


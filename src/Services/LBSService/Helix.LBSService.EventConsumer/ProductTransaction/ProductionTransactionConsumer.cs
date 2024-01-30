using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;


namespace Helix.LBSService.EventConsumer.ProductTransaction
{
	public class ProductionTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<ProductionTransactionDto> _messageConsumer;

		public ProductionTransactionConsumer(IService<ProductionTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<ProductionTransactionDto>(
				service: service,
				queueName: "SalesService.RetailSalesDispatchTransactionIns",
				exchange: "HelixTopicName",
				httpClient: httpClient
			);
		}

		public async Task ProcessMessagesAsync()
		{
			await _messageConsumer.ProcessMessagesAsync();
		}

		public void Dispose()
		{
			_messageConsumer.Dispose();
		}
	}
}

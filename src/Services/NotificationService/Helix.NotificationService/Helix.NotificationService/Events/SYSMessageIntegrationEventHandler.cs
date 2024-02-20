using Helix.EventBus.Base.Abstractions;
using Helix.NotificationService.Helper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using Helix.NotificationService.Dto;

namespace Helix.NotificationService.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		private readonly ILogger<SYSMessageIntegrationEventHandler> _logger;
		public SYSMessageIntegrationEventHandler(ILogger<SYSMessageIntegrationEventHandler> logger)
		{
			_logger = logger;
		}
		public async Task Handle(SYSMessageIntegrationEvent @event)
		{
			try
			{
				var httpclient = new HttpClientService().GetOrCreateHttpClient();
				if (@event.IsSucces)
				{
					var dto = new TransactionOwnerDto()
					{
						Employee = @event.ApplicationOwner,
						FicheReferenceId = @event.FicheId
					};
					HttpResponseMessage response = await httpclient.PostAsync("gateway/identity/odata/TransactionOwner", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));


					if (response.IsSuccessStatusCode)
					{
						_logger.LogInformation("SYSMessageIntegrationEvent Handled");
					}
					else
					{
 						throw new Exception($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
					}
				}
				else
				{
					var dto = new FailureTransactionOwnerDto()
					{
						Employee = @event.ApplicationOwner,
						Data = JsonConvert.SerializeObject(@event),
						Message = @event.Message
					};
					HttpResponseMessage response = await httpclient.PostAsync("gateway/identity/odata/FailureTransactionOwner", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));


					if (response.IsSuccessStatusCode)
					{
						_logger.LogInformation("SYSMessageIntegrationEvent Handled");
					}
					else
					{
 						throw new Exception($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
					}
				}
			}
			catch (Exception)
			{

				throw;
			}

 		}
	}
}

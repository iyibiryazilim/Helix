using Helix.EventBus.Base.Abstractions;
using Helix.NotificationService.Dto;
using Helix.NotificationService.Helper;
using Newtonsoft.Json;
using System.Text;

namespace Helix.NotificationService.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		private readonly ILogger<SYSMessageIntegrationEventHandler> _logger;
		private readonly IHttpClientService _httpClientService;
		private readonly IAuthenticationService _authenticationService;
		public SYSMessageIntegrationEventHandler(ILogger<SYSMessageIntegrationEventHandler> logger, IHttpClientService httpClientService, IAuthenticationService authenticationService)
		{
			_logger = logger;
			_httpClientService = httpClientService;
			_authenticationService = authenticationService;
		}
		public async Task Handle(SYSMessageIntegrationEvent @event)
		{
			try
			{
				var httpclient = _httpClientService.GetOrCreateHttpClient();
				 await _authenticationService.Authenticate(httpclient);
				if (@event.IsSucces)
				{
					var dto = new TransactionOwnerDto()
					{
						Employee = new Guid("C05E3FA6-95C7-4571-BFFC-1D80B320B763"),
						FicheReferenceId = @event.FicheId
					};
					HttpResponseMessage response = await httpclient.PostAsync("gateway/identity/odata/TransactionOwner", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));


					if (response.IsSuccessStatusCode)
					{
						_logger.LogInformation("SYSMessageIntegrationEvent Handled");
					}
					else
					{
						var test = await response.RequestMessage.Content.ReadAsStringAsync();
 						throw new Exception($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
					}
				}
				else
				{
					var dto = new FailureTransactionOwnerDto()
					{
						Employee = new Guid("C05E3FA6-95C7-4571-BFFC-1D80B320B763"),
						Data = JsonConvert.SerializeObject(@event),
						Message = @event.Message
					};

					var test = JsonConvert.SerializeObject(dto);
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

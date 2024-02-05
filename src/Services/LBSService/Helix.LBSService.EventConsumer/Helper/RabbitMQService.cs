using Helix.LBSService.EventConsumer.Models;
using RabbitMQ.Client;

namespace Helix.LBSService.EventConsumer.Helper
{
	public class RabbitMQService
	{
		// localhost üzerinde kurulu olduğu için host adresi olarak bunu kullanıyorum.
 
		public static IConnection GetRabbitMQConnection()
		{
			ConnectionFactory connectionFactory = new ConnectionFactory()
			{
				Uri = new Uri(ApplicationParameter.RabbitMQAdress)
			};

			return connectionFactory.CreateConnection();
		}
	}
}

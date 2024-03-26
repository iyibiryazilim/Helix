using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Net.Sockets;

namespace Helix.EventBus.RabbitMQ
{
	public class RabbitMQPersistentConnection : IDisposable
	{
		private readonly IConnectionFactory _connectionFactory;
		private IConnection connection;
		private int _retyCount;
		private object lock_object = new object();
		private bool _disposed;

		public RabbitMQPersistentConnection(IConnectionFactory connectionFactory, int retyCount = 30)
		{
			_connectionFactory = connectionFactory;
			_retyCount = retyCount;
		}

		public bool IsConnection => connection != null && connection.IsOpen;

		public IModel CreateModel()
		{
			return connection.CreateModel();
		}

		public bool TryConnect()
		{
			lock (lock_object)
			{
				var policy = Policy.Handle<SocketException>()
					.Or<BrokerUnreachableException>()
					.WaitAndRetry(_retyCount, retyAttemp => TimeSpan.FromSeconds(Math.Pow(2, retyAttemp)), (ex, time) =>
					{
					}
				 );

				policy.Execute(() =>
				{
					connection = _connectionFactory.CreateConnection();
				});

				if (IsConnection)
				{
					connection.ConnectionShutdown += Connection_ConnectionShutdown;
					connection.CallbackException += Connection_CallbackException;
					connection.ConnectionBlocked += Connection_ConnectionBlocked;
					return true;
				}

				return false;
			}
		}

		private void Connection_ConnectionBlocked(object? sender, global::RabbitMQ.Client.Events.ConnectionBlockedEventArgs e)
		{
			//create log
			if (_disposed)
				return;
			TryConnect();
		}

		private void Connection_CallbackException(object? sender, global::RabbitMQ.Client.Events.CallbackExceptionEventArgs e)
		{
			//create log
			if (_disposed)
				return;
			TryConnect();
		}

		private void Connection_ConnectionShutdown(object? sender, ShutdownEventArgs e)
		{
			//create log
			if (_disposed)
				return;
			TryConnect();
		}

		public void Dispose()
		{
			_disposed = true;
			connection?.Dispose();
		}
	}
}
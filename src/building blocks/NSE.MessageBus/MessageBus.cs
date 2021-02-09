using EasyNetQ;
using NSE.Core.Messages.Integration;
using System;
using System.Threading.Tasks;

namespace NSE.MessageBus
{
	public class MessageBus: IMessageBus
	{
		private IBus _bus;

		public bool IsConnected => throw new NotImplementedException();


		public void Publish<T>(T message) where T : IntegrationEvent
		{
			throw new NotImplementedException();
		}

		public Task PublishAsync<T>(T message) where T : IntegrationEvent
		{
			throw new NotImplementedException();
		}

		public TResponse Request<TRequest, TResponse>(TRequest request)
			where TRequest : IntegrationEvent
			where TResponse : ResponseMessage
		{
			throw new NotImplementedException();
		}

		public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
			where TRequest : IntegrationEvent
			where TResponse : ResponseMessage
		{
			throw new NotImplementedException();
		}

		public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
			where TRequest : IntegrationEvent
			where TResponse : ResponseMessage
		{
			throw new NotImplementedException();
		}

		public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
			where TRequest : IntegrationEvent
			where TResponse : ResponseMessage
		{
			throw new NotImplementedException();
		}

		public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
		{
			throw new NotImplementedException();
		}

		public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
		{
			throw new NotImplementedException();
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}

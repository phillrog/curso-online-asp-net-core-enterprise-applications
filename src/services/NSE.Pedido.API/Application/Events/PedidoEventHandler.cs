using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NSE.Pedidos.API.Application.Events
{
	public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
	{
		public Task Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
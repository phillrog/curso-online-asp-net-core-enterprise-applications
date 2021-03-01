using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Pedidos.API.Application.DTO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Commands
{
	public class PedidoCommandHandler : CommandHandler,
		IRequestHandler<AdicionarPedidoCommand, ValidationResult>
	{
		public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
		{
			if (!message.EhValido()) return message.ValidationResult;

            return null;
		}

        private NSE.Pedidos.Domain.Pedidos.Pedido MapearPedido(AdicionarPedidoCommand message)
        {
            var endereco = new NSE.Pedidos.Domain.Pedidos.Endereco
            {
                Logradouro = message.Endereco.Logradouro,
                Numero = message.Endereco.Numero,
                Complemento = message.Endereco.Complemento,
                Bairro = message.Endereco.Bairro,
                Cep = message.Endereco.Cep,
                Cidade = message.Endereco.Cidade,
                Estado = message.Endereco.Estado
            };

            var pedido = new NSE.Pedidos.Domain.Pedidos.Pedido(message.ClienteId, message.ValorTotal, message.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
                message.VoucherUtilizado, message.Desconto);

            pedido.AtribuirEndereco(endereco);
            return pedido;
        }
    }
}
using NSE.Core.Data;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace NSE.Pedidos.Domain.Pedidos
{
	public class Pedido: Entity, IAggregateRoot
	{
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public Endereco Endereco { get; private set; }
        // EF Rel.
        public Voucher Voucher { get; private set; }
    }
}

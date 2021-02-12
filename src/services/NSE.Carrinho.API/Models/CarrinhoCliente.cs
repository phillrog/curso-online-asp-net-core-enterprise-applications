using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Carrinho.API.Models
{
	public class CarrinhoCliente
	{
		internal const int MAX_QUANTIDADE_ITEM = 5;
		public Guid Id { get; set; }
		public Guid ClienteId { get; set; }
		public decimal ValorTotal { get; set; }
		public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
		public CarrinhoCliente(Guid clienteId)
		{
			Id = Guid.NewGuid();
			ClienteId = clienteId;
		}

		public CarrinhoCliente(){}

		internal void CalcularValorTotalCarrinho()
		{
			ValorTotal = Itens.Sum(p => p.CalcularValor());
		}

		internal bool CarrinhoItemExistente(CarrinhoItem item)
		{
			return Itens.Any(p => p.ProdutoId == item.ProdutoId);
		}

		internal CarrinhoItem ObterPorProdutoId(Guid produtoId)
		{
			return Itens.FirstOrDefault(p => p.ProdutoId == produtoId);
		}

		internal void AdicionarItem(CarrinhoItem item)
		{
			if (!item.EhValido()) return;

			item.AssociarCarrinho(Id);

			if (CarrinhoItemExistente(item))
			{
				var itemExistente = ObterPorProdutoId(item.ProdutoId);
				itemExistente.AdicionarUnidades(item.Quantidade);

				item = itemExistente;
				Itens.Remove(itemExistente);
			}

			Itens.Add(item);
			CalcularValorTotalCarrinho();
		}
	}
}

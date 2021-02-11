using System;

namespace NSE.Carrinho.API.Models
{
	public class CarrinhoItem
	{
		public CarrinhoItem()
		{
			Id = Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public Guid ProdutoId { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public decimal Valor { get; set; }
		public string Imagem { get; set; }
		public Guid CarrinhoId { get; set; }
		public CarrinhoCliente CarrinhoCliente { get; set; }
	}
}

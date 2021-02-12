using FluentValidation;
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

		internal void AssociarCarrinho(Guid carrinhoId)
		{
			CarrinhoId = carrinhoId;
		}

		internal decimal CalcularValor()
		{
			return Quantidade * Valor;
		}

		internal void AdicionarUnidades(int unidades)
		{
			Quantidade += unidades;
		}

		internal bool EhValido()
		{
			return new ItemCarrinhoValidation().Validate(this).IsValid;
		}

		internal void AtualizarUnidades(int unidades)
		{
			Quantidade = unidades;
		}


		public class ItemCarrinhoValidation : AbstractValidator<CarrinhoItem>
		{
			public ItemCarrinhoValidation()
			{
				RuleFor(c => c.ProdutoId)
					.NotEqual(Guid.Empty)
					.WithMessage("Id do produto inválido");
				
				RuleFor(c => c.Nome)
					.NotEmpty()
					.WithMessage("O nome do produto não foi informado");

				RuleFor(c => c.Quantidade)
					.GreaterThan(0)
					.WithMessage("A quantidade miníma de um item é 1");

				RuleFor(c => c.Quantidade)
					.LessThan(CarrinhoCliente.MAX_QUANTIDADE_ITEM)
					.WithMessage($"A quantidade máxima de um item é {CarrinhoCliente.MAX_QUANTIDADE_ITEM}");

				RuleFor(c => c.Valor)
					.GreaterThan(0)
					.WithMessage("O valor do item precisa ser maior que 0"); 

			}
		}
	}
}

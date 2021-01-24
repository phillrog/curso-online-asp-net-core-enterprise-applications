using NSE.Catalogo.API.Models;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Models
{
	public interface IProdutoRepository : IRepository<Produto>
	{
		Task<IEnumerable<Produto>> ObterTodos();
		Task<Produto> ObterPorId(Guid id);

		void Adicionar(Produto produto);
		void Atualizar(Produto produto);
	}
}

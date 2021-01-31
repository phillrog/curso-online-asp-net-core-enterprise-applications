using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Application.Events
{
	public class ClienteRegistradoEvent : Event
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Cpf { get; set; }
		public ClienteRegistradoEvent(Guid id, string nome, string email, string cpf)
		{
			AggregateId = id;
			Id = id;
			Nome = nome;
			Email = email;
			Cpf = cpf;			
		}
	}
}

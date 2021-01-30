using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
	public class RegistrarClienteCommand : Command
	{
		public Guid Id { get; private set; }
		public string Nome { get; private set; }
		public string Email { get; private set; }
		public string Cpf { get; private set; }

		public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
		{
			AggregateId = id;
			Id = id;
			Nome = nome;
			Email = email;
			Cpf = cpf;
		}
	}
}

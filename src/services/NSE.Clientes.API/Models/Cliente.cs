using NSE.Core.Data;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relation
        protected Cliente() { }

        public Cliente(string nome, string email, Cpf cpf)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Excluido = false;
        }
    }
}

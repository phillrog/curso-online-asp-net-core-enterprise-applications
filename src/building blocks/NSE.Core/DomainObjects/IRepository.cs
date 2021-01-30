using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.DomainObjects
{
	public interface IRepository <T> : IDisposable where T : IAggregateRoot
	{
		public IUnitOfWork UnitOfWork { get; }
	}
}

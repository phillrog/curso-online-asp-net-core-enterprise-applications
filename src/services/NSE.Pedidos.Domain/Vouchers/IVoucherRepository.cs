using System.Threading.Tasks;

namespace NSE.Pedidos.Domain
{
	public interface IVoucherRepository 
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);
    }
}
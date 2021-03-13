using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using NSE.Core.DomainObjects;
using NSE.Core.Messages.Integration;
using NSE.Pagamentos.API.Models;
using NSE.Pagamentos.Facade;

namespace NSE.Pagamentos.API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoFacade _pagamentoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoFacade pagamentoFacade, 
                                IPagamentoRepository pagamentoRepository)
        {
            _pagamentoFacade = pagamentoFacade;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<ResponseMessage> AutorizarPagamento(Pagamento pagamento)
        {
            var transacao = await _pagamentoFacade.AutorizarPagamento(pagamento);
            var validationResult = new ValidationResult();

            if (transacao.Status != StatusTransacao.Autorizado)
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento",
                        "Pagamento recusado, entre em contato com a sua operadora de cartão"));

                return new ResponseMessage(validationResult);
            }

            pagamento.AdicionarTransacao(transacao);
            _pagamentoRepository.AdicionarPagamento(pagamento);

            if (!await _pagamentoRepository.UnitOfWork.Commit())
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento",
                    "Houve um erro ao realizar o pagamento."));

                return new ResponseMessage(validationResult);
            }

            return new ResponseMessage(validationResult);
        }

    }
}
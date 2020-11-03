using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class PesquisaDebitoService : BaseService, IPesquisaDebitoService
    {
        private readonly IPesquisaDebitoRepository _pesquisaDebitoRepository;
        private readonly IUser _user;

        public PesquisaDebitoService(IPesquisaDebitoRepository pesquisaDebitoRepository, 
                                 INotificador notificador,
                                 IUser user) : base(notificador)
        {
            _pesquisaDebitoRepository = pesquisaDebitoRepository;
            _user = user;
        }

        public async Task<PesquisaDebito> CalcularDebito(PesquisaDebito pesquisaDebito)
        {
            var calculo = CalculoDebito(pesquisaDebito);

            var result = new PesquisaDebito
            {
                DataVencimento = pesquisaDebito.DataVencimento,
                QuantidadeParcela = pesquisaDebito.QuantidadeParcela,
                UserId = pesquisaDebito.UserId,
                ValorOriginal = pesquisaDebito.ValorOriginal,
                Comissao = calculo.Comissao,
                DiasAtraso = calculo.DiasAtraso,
                ValorJuros = calculo.ValorJuros,
                ValorFinal = calculo.ValorFinal
            };
            return result;
        }

        public PesquisaDebito CalculoDebito(PesquisaDebito pesquisaDebito)
        {
            var diasAtraso = 0;
            if (DateTime.Now.Subtract(pesquisaDebito.DataVencimento).Days > 0)
            {
                diasAtraso = DateTime.Now.Subtract(pesquisaDebito.DataVencimento).Days;
            }
            var valorJuros = pesquisaDebito.ValorOriginal * (0.002 * diasAtraso);
            var valorTotal = pesquisaDebito.ValorOriginal + valorJuros;
            var valorComissao = (valorTotal * 10) / 100;

            return new PesquisaDebito
            {
                DiasAtraso = diasAtraso,
                ValorJuros = valorJuros,
                Comissao = valorComissao,
                ValorFinal = valorTotal
            };
        }

        public void Dispose()
        {
            _pesquisaDebitoRepository?.Dispose();
        }
    }

}
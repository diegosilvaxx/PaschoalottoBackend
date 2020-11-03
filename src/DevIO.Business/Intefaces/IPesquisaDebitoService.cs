using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IPesquisaDebitoService : IDisposable
    {
        Task<PesquisaDebito> CalcularDebito(PesquisaDebito pesquisaDebito);
    }
}
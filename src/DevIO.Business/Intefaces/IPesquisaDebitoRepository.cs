using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IPesquisaDebitoRepository : IRepository<PesquisaDebito>
    {
        Task<PesquisaDebito> ObterDebito(Guid id);
    }
}
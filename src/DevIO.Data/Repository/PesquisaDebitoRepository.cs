using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class PesquisaDebitoRepository : Repository<PesquisaDebito>, IPesquisaDebitoRepository
    {
        public PesquisaDebitoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<PesquisaDebito> ObterDebito(Guid id)
        {
            return await Db.PesquisaDebitos.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == id);
        }

    }
}
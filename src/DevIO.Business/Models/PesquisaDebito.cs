using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DevIO.Business.Models
{
    public class PesquisaDebito : Entity
    {
        public Guid UserId { get; set; }
        public DateTime DataVencimento { get; set; }
        public int QuantidadeParcela { get; set; }
        public double ValorOriginal { get; set; }
        public double ValorJuros { get; set; }
        public double ValorFinal { get; set; }
        public int DiasAtraso { get; set; }
        public double Comissao { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class PesquisaDebitoDto
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeParcela{ get; set; }

        public double ValorOriginal { get; set; }
        public double ValorJuros { get; set; }
        public double ValorFinal { get; set; }
        public int DiasAtraso { get; set; }
        public double Comissao { get; set; }

    }
}

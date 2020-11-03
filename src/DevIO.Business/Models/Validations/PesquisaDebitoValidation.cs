using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class PesquisaDebitoValidation : AbstractValidator<PesquisaDebito>
    {
        public PesquisaDebitoValidation()
        {
            RuleFor(f => f.QuantidadeParcela).InclusiveBetween(1, 3).WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
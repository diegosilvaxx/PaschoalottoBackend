using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class PesquisaDebitoMapping : IEntityTypeConfiguration<PesquisaDebito>
    {
        public void Configure(EntityTypeBuilder<PesquisaDebito> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.QuantidadeParcela)
                .IsRequired();

            builder.ToTable("PesquisaDebito");
        }
    }
}
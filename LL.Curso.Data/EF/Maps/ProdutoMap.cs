using LL.Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LL.Curso.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();

            builder.Property(p => p.Preco).HasColumnType("money").IsRequired();

            builder.Property(p => p.DataCriacao);
            builder.Property(p => p.DataAlteracao);
        }
    }
}

using CS.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS.Data.Mappings
{
    public class TreinoMapping : IEntityTypeConfiguration<Treino>
    {
        public TreinoMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Exercicios)
                .WithMany(x => x.Treinos)
                .UsingEntity(x => x.ToTable("TreinosExercicios", "Sistema"));
        }
    }
}

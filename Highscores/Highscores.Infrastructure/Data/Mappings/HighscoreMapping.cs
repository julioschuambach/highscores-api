using Highscores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Highscores.Infrastructure.Data.Mappings;

public class HighscoreMapping : IEntityTypeConfiguration<Highscore>
{
    public void Configure(EntityTypeBuilder<Highscore> builder)
    {
        builder.ToTable("Highscores");

        builder.HasKey(x => x.Id)
               .HasName("PK_Highscores_Id");

        builder.Property(x => x.Id)
               .HasColumnName("Id")
               .HasColumnType("UNIQUEIDENTIFIER")
               .IsRequired();

        builder.Property(x => x.Player)
               .HasColumnName("Player")
               .HasColumnType("VARCHAR")
               .HasMaxLength(15)
               .IsRequired();

        builder.Property(x => x.Score)
               .HasColumnName("Score")
               .HasColumnType("INT")
               .IsRequired();

        builder.HasIndex(x => x.Id, "IX_Highscores_Id")
               .IsUnique();
    }
}


using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.Property(x => x.Author_ID).HasColumnType("int");
            builder.Property(x => x.FirstName).HasColumnType("varchar(20)");
            builder.Property(x => x.LastName).HasColumnType("varchar(20)");
            builder.Property(x => x.DateOfBirth).HasColumnType("datetime");
            builder.HasKey(x => x.Author_ID);


        }
    }
}

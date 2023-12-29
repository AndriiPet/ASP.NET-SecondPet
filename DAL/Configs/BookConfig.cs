using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            
            builder.ToTable("Books");
            builder.Property(x => x.Book_ID).HasColumnType("int");
            builder.Property(x => x.Book_Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Number_pages).HasColumnType("int");
            builder.Property(x => x.Author_ID).HasColumnType("int");
            builder.Property(x => x.Cost).HasColumnType("money");
            builder.HasKey(x => x.Book_ID);


        }
    }
}

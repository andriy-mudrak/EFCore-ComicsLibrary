using task1_3.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task1_3.Configurations
{   //implement database
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(t => t.Id)
                    .HasColumnName("AuthorId");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            
        }
    }
}
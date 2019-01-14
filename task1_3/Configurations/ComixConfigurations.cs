using task1_3.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task1_3.Configurations
{
    class ComixConfigurations: IEntityTypeConfiguration<Comix>
    {
        public void Configure(EntityTypeBuilder<Comix> builder)
        {
            builder.HasOne(p => p.Author)
                .WithMany(t => t.Comics)
                .HasForeignKey(p => p.AuthorId)
                .HasConstraintName("FK_AuthorId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Id)
                .HasColumnName("ComixId");

            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(45);
                       
            builder.Property(p => p.Price)
                .IsRequired();
        }
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .HasColumnName("id");

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Email)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Password)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar(100)");
        }
    }
}

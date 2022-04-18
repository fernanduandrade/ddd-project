using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");

            builder.Property(prop => prop.Id)
                .HasColumnName("id");

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Email)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Password)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("varchar(100)");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TodoList.Data.Entities;

namespace TodoList.Data.Configurations
{
    class AffairsConfiguration : IEntityTypeConfiguration<Affair>
    {
        public void Configure(EntityTypeBuilder<Affair> builder)
        {
            builder.HasKey(a => a.Id)
                .HasName("PrimaryKey_AffairId");
            builder.HasIndex(a => a.Title)
                .IsUnique();
            builder.Property(a => a.Annotation)
                .HasMaxLength(512)
                .IsUnicode(false);
            builder.Property(a => a.StartDate)
                .HasColumnType("Date")
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.EndDate)
                .HasColumnType("Date");

            /*builder.HasData(new Affair() { Id = 1, Title = "job", Annotation = "i have to go to job", StartDate = DateTime.Now, EndDate = DateTime.Parse("25.08.2022") });
            builder.HasData(new Affair() { Id = 2, Title = "hobby", Annotation = "i have to do a hobby", StartDate = DateTime.Now, EndDate = DateTime.Parse("30.09.2022") });*/
        }
    }
}
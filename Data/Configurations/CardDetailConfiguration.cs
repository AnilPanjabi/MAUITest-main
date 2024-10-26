using System;
using MAUITest.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAUITest.Data.Configurations
{
	public class CardDetailConfiguration : IEntityTypeConfiguration<CardDetailsDataModel>
    {
        public void Configure(EntityTypeBuilder<CardDetailsDataModel> builder)
        {
            builder.ToTable("CardDetail")
                .HasKey(_ => _.CardDetailId);

            builder.Property(_ => _.CardDetailId)
                .ValueGeneratedNever()
                .IsRequired(true);
        }
    }
}


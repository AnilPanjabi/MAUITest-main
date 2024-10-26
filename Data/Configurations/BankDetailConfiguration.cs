using System;
using MAUITest.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAUITest.Data.Configurations
{
	public class BankDetailConfiguration : IEntityTypeConfiguration<BankDetailsDataModel>
    {
        public void Configure(EntityTypeBuilder<BankDetailsDataModel> builder)
        {
            builder.ToTable("BankDetail")
                .HasKey(_=>_.BankDetailId);

            builder.Property(_ => _.BankDetailId)
                .ValueGeneratedNever()
                .IsRequired(true);
        }
    }
}


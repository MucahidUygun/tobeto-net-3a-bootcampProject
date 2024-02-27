using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
    {
        public void Configure(EntityTypeBuilder<Blacklist> builder)
        {
            builder.ToTable("Blacklists").HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
            builder.Property(x => x.Reason).HasColumnName("Reason").IsRequired();
            builder.Property(x => x.Date).HasColumnName("Date").IsRequired();
            builder.Ignore(x => x.CreatedDate);
            builder.Ignore(x => x.DeletedDate);
            builder.Ignore(x => x.UpdatedDate);

            builder.HasOne(x => x.Applicant);
        }
    }
}

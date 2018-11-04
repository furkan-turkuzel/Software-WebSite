using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class CommonMapping : EntityTypeConfiguration<Common>
    {
        public CommonMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Logo)
                .IsRequired();

            Property(x => x.CompanyName)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.URL)
                .IsOptional();

            Property(x => x.CreatedBy)
                .IsOptional();

            Property(x => x.CreatedDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsOptional();

            Property(x => x.ModifiedBy)
                .IsOptional();

            Property(x => x.ModifiedDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsOptional();

            Property(x => x.IsActive)
                .IsOptional();
        }
    }
}

using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class ServicesDetailMapping : EntityTypeConfiguration<ServicesDetail>
    {
        public ServicesDetailMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Service)
                .WithMany(x => x.ServicesDetails)
                .HasForeignKey(x => x.ServiceID)
                .WillCascadeOnDelete();

            Property(x => x.ServiceDetailTitle)
                .IsOptional();

            Property(x => x.ServiceDetailWriting)
                .IsOptional();

            Property(x => x.ServiceDetailImage)
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

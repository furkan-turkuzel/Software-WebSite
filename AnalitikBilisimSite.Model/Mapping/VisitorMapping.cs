using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class VisitorMapping : EntityTypeConfiguration<Visitor>
    {
        public VisitorMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                  (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.FullName)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Email)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Subject)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Message)
                .IsOptional();

            Property(x => x.SendTime)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();

            Property(x => x.Readed)
                .IsRequired();

        }
    }
}

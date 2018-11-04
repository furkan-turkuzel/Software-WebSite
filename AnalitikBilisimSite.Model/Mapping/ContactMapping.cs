using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Phone)
                .HasMaxLength(11)
                .IsRequired();

            Property(x => x.Fax)
                .HasMaxLength(40)
                .IsRequired();

            Property(x => x.Address)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.GoogleMap)
                .IsOptional();

            Property(x => x.Facebook)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Twitter)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Youtube)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Linkedin)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Google)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Linkedin)
                .HasMaxLength(100)
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

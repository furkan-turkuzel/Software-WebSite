using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class SolutionMapping : EntityTypeConfiguration<Solution>
    {
        public SolutionMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Category)
                .WithMany(x => x.Solutions)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(true);

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.SmallWriting)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.BigWriting)
                .IsRequired();

            Property(x => x.Image)
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

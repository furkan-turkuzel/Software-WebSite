using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class AboutMapping : EntityTypeConfiguration<About>
    {
        public AboutMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.SmallWriting)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.BigWriting)
                .IsOptional();

            Property(x => x.Image)
                .IsOptional();

            Property(x => x.MissionTitle)
                .IsOptional();

            Property(x => x.MissionWriting)
                .IsOptional();

            Property(x => x.MissionImage)
                .IsOptional();

            Property(x => x.PlanTitle)
                .IsOptional();

            Property(x => x.PlanWriting)
                .IsOptional();

            Property(x => x.PlanImage)
                .IsOptional();

            Property(x => x.VisionTitle)
                .IsOptional();

            Property(x => x.VisionWriting)
                .IsOptional();

            Property(x => x.VisionImage)
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

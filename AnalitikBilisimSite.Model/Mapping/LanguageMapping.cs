using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class LanguageMapping : EntityTypeConfiguration<Language>
    {
        public LanguageMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Code)
                .HasColumnType("nvarchar")
                .HasMaxLength(10)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("Code_Unique")
                   { IsUnique = true })).IsRequired();

            Property(x => x.LanguageName)
                .IsRequired();

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

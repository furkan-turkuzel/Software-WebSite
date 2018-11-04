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
    public class UsersMapping : EntityTypeConfiguration<Users>
    {
        public UsersMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.UserName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("UserName_Unique")
                   { IsUnique = true })).IsRequired();

            Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(40)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.UserRole)
                .IsRequired();

            Property(x => x.UserImage)
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

            Property(x => x.Instagram)
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

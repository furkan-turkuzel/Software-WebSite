﻿using AnalitikBilisimSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.Model.Mapping
{
    public class ReferanceMapping : EntityTypeConfiguration<Referance>
    {
        public ReferanceMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption
                   (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            Property(x => x.ReferanceLogo)
                .IsRequired();

            Property(x => x.ReferanceName)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.ReferancePhone)
                .HasMaxLength(11)
                .IsRequired();

            Property(x => x.ReferanceType)
                .IsOptional();

            Property(x => x.ReferanceAddress)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Description)
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

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuracion
{
    public class AntecedentesConfiguracion : IEntityTypeConfiguration<Antecedentes>
    {
        public void Configure(EntityTypeBuilder<Antecedentes> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HistoriaClinicaId).IsRequired();

            /*  Relaciones */
            builder.HasOne(x => x.HistoriaClinica).WithMany()
                   .HasForeignKey(x => x.HistoriaClinicaId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

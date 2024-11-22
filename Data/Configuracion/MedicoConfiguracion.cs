using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuracion
{
    public class MedicoConfiguracion: IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Apellidos).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Nombres).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.Genero).IsRequired().HasColumnType("char").HasMaxLength(1);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.EspecialidaId).IsRequired();

            /*  Relaciones */
            builder.HasOne(x => x.Especialidad).WithMany()
                   .HasForeignKey(x => x.EspecialidaId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

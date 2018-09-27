using CleanArchitectureLab.Core.Domain.Tarefas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Persistance.Mapping
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
            //builder.HasMany<Tarefa>().WithOne(x => x.Responsavel).HasForeignKey(x => x.ResponsavelId);
            //builder.ToTable("Usuarios");
        }
    }
}

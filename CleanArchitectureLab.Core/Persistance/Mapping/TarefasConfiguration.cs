using CleanArchitectureLab.Core.Domain.Tarefas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Persistance.Mapping
{
    public class TarefasConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Criacao).IsRequired();
            builder.Property(x => x.Lembrate).IsRequired(false);
            builder.HasMany(x => x.Compartilhamentos).WithOne("TarefaUsuarios").HasForeignKey(x => x.Id);
            builder.HasOne(x => x.Responsavel).WithOne();
            //builder.OwnsOne(x=>x.Responsavel).HasOne(x.)
            //builder.HasOne(x => x.Responsavel).WithOne(x => x.Id);
        }
    }
}

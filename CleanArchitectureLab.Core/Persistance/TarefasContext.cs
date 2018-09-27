using CleanArchitectureLab.Core.Domain.Tarefas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace CleanArchitectureLab.Core.Persistance
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        private Action<Type, ModelBuilder> _register = (type, builder) => builder.ApplyConfiguration(Activator.CreateInstance(type) as dynamic);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Registro dinamico de novas configurações
            var typesToRegister = Assembly.GetAssembly(typeof(TarefasContext)).GetTypes()
              .Where(type => type.Namespace != null
                && type.Namespace.Equals(typeof(TarefasContext).Namespace))
              .Where(type => type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            typesToRegister.ToList().ForEach(x => _register(x, builder));
        }
    }
}

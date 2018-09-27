using AutoMapper;
using CleanArchitectureLab.Core.Domain.Tarefas;
using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Usuarios.Criar
{
    public class CriarUsuarioCommand : ICriarUsuarioCommand
    {
        private readonly TarefasContext _context;

        public CriarUsuarioCommand(TarefasContext context)
        {
            _context = context;
        }

        public void Execute(UsuarioDto usuarioDto)
        {
            var usuario = Mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}

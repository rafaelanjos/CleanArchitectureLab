using CleanArchitectureLab.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitectureLab.Core.Application.Usuarios.Listar
{
    public class ListarUsuariosQuery : IListarUsuariosQuery
    {
        private readonly TarefasContext _context;

        public ListarUsuariosQuery(TarefasContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioListaDto> Execute()
        {
            //Alterar para o Dapper + proc + performance

            return _context.Usuarios
                                .Select(u => new UsuarioListaDto(u))
                                .ToList();
        }
    }
}

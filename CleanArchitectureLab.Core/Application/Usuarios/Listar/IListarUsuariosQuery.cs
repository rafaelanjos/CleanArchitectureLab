using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Usuarios.Listar
{
    public interface IListarUsuariosQuery
    {
        IEnumerable<UsuarioListaDto> Execute();
    }
}

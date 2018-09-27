using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureLab.Core.Application.Usuarios.Criar
{
    public interface ICriarUsuarioCommand
    {
        void Execute(UsuarioDto usuarioDto);
    }
}

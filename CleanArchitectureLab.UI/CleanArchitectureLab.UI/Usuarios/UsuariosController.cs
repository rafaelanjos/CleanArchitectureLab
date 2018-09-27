using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureLab.Core.Application.Usuarios;
using CleanArchitectureLab.Core.Application.Usuarios.Criar;
using CleanArchitectureLab.Core.Application.Usuarios.Listar;
using CleanArchitectureLab.UI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLab.UI.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICriarUsuarioCommand _criarUsuarioCommand;
        private readonly IListarUsuariosQuery _listarUsuariosQuery;

        public UsuariosController(IListarUsuariosQuery listarUsuariosQuery, ICriarUsuarioCommand criarUsuarioCommand)
        {
            _listarUsuariosQuery = listarUsuariosQuery;
            _criarUsuarioCommand = criarUsuarioCommand;
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                var result = _listarUsuariosQuery.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // logar
                return StatusCode(500, Mensagens.ErroGeral);
            }
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioDto usuario)
        {
            try
            {
                // Validar
                _criarUsuarioCommand.Execute(usuario);

                return StatusCode(201, Mensagens.CadastroSucesso);
            }
            catch (Exception ex)
            {
                //logar
                return StatusCode(500, Mensagens.ErroGeral);
            }
        }
    }
}
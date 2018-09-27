using CleanArchitectureLab.Core.Domain.Tarefas;
using System.Text.RegularExpressions;

namespace CleanArchitectureLab.Core.Application.Usuarios.Listar
{
    public class UsuarioListaDto
    {
        public UsuarioListaDto(Usuario u)
        {
            Id = u.Id;
            Nome = u.Nome;
            Email = EsconderEmail(u.Email);
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private string EsconderEmail(string email)
        {
            string pattern = @"(?<=[\w]{2})[\w-\._\+%]*(?=[\w]{2}@)";
            return Regex.Replace(email, pattern, m => new string('*', m.Length));
        }
    }
}
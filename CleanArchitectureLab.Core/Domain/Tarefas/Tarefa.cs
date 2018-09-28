using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitectureLab.Core.Domain.Tarefas
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        public Usuario Responsavel { get; set; }
        public int ResponsavelId { get; set; }
        public IEnumerable<Usuario> Compartilhamentos { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? Lembrete { get; set; }

        public Tarefa()
        {
            Criacao = DateTime.Now;
            Lembrete = null;
            Concluida = false;
        }

        public void AlterarEstadoConclusao()
        {
            Concluida = !Concluida;
        }

        public void AdicionarLembrete(DateTime lembrete)
        {
            //TODO erro de negocio no else
            if (lembrete >= DateTime.Now)
                Lembrete = lembrete;
        }

        public void  Compartilhar(List<Usuario> usuarios)
        {
            if (!usuarios.Any())
                return; //TODO erro de negocio

            var _compartilhamentos = Compartilhamentos.ToList();
            _compartilhamentos.AddRange(usuarios);
            Compartilhamentos = _compartilhamentos;
        }
    }
}
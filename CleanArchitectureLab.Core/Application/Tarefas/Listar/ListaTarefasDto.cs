using System;

namespace CleanArchitectureLab.Core.Application.Tarefas.Listar
{
    public class ListaTarefasDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? Lembrete { get; set; }
    }
}
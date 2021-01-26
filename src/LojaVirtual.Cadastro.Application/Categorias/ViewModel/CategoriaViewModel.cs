using System;

namespace LojaVirtual.Cadastro.Application.Categorias.ViewModel
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public bool Ativo { get; set; }
    }
}
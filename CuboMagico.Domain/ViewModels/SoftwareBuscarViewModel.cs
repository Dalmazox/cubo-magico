using System;

namespace CuboMagico.Domain.ViewModels
{
    public class SoftwareBuscarViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public bool Vigente { get; set; } = true;
        public DateTime DataCadastro { get; set; }
        public string UsuarioNome { get; set; }
    }
}

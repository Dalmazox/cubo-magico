using System;
using System.Collections.Generic;

namespace CuboMagico.Domain.ViewModels
{
    public class UsuarioBuscarViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<SoftwareBuscarViewModel> Softwares { get; set; }
    }
}

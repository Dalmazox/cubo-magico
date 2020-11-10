using System;
using System.Collections.Generic;

namespace CuboMagico.Domain.Entities
{
    public class Usuario
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now.ToUniversalTime();

        public virtual IEnumerable<Software> Softwares { get; set; }
    }
}

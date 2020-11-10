using System;

namespace CuboMagico.Domain.Entities
{
    public class Software
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public bool Vigente { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now.ToUniversalTime();

        public virtual Usuario Usuario { get; set; }
        public Guid UsuarioID { get; set; }
    }
}

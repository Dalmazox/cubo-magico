using System;

namespace CuboMagico.Infra.Data.Repositories.Config
{
    public class RepositoryBinding
    {
        public RepositoryBinding(Type tipoInterface, Type tipoImplementacao)
        {
            TipoInterface = tipoInterface;
            TipoImplementacao = tipoImplementacao;
        }

        public Type TipoInterface { get; private set; }
        public Type TipoImplementacao { get; private set; }
    }
}

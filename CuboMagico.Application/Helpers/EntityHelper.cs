namespace CuboMagico.Application.Helpers
{
    public static class EntityHelper
    {
        public static void TransferirPropriedades<T>(T origem, T destino)
        {
            var typeT = typeof(T);

            foreach (var propriedade in typeT.GetProperties())
            {
                if (propriedade.Name == "ID" || propriedade.Name == "id")
                    continue;

                propriedade.SetValue(destino, propriedade.GetValue(origem));
            }
        }
    }
}

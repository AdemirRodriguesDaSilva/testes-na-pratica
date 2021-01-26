namespace LojaVirtual.Core.DomainObject
{
    public class Validacoes
    {  
        public static void ValidarSeIgual(object objeto1, object objeto2, string mensagem)
        {
            if (objeto1.Equals(objeto2))
                throw new ExcecaoDoDominio(mensagem);
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ExcecaoDoDominio(mensagem);
        }

        public static void ValidarSeEhTrueOuFalse(bool valor, string mensagem)
        {
            if (valor != true && valor != false)
                throw new ExcecaoDoDominio(mensagem);
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new ExcecaoDoDominio(mensagem);
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new ExcecaoDoDominio(mensagem);
        }
    }
}
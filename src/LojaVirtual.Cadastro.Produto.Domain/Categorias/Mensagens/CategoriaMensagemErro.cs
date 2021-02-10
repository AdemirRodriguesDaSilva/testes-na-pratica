namespace LojaVirtual.Cadastro.Domain.Categorias.Mensagens
{
    public class CategoriaMensagemErro
    {
        public static string NOME_INVALIDO => "Por favor, certifique-se de ter informado o Nome da categoria";
        public static string NOME_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO = "Nome com caracteres acima do permitido";
        public static string CODIGO_INVALIDO => "Por favor, certifique-se de ter informado o Codigo da categoria";
        public static string CODIGO_COM_QTD_CARACTERRES_ACIMA_DO_PERMITIDO = "Codigo com caracteres acima do permitido";
        public static string ATIVO => $"Por favor, certifique-se de ter informado o campo Ativo da categoria";
    }
}
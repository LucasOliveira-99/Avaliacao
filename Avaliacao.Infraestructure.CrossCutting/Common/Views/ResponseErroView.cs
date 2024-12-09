namespace Avaliacao.Infraestructure.CrossCutting.Common.Views
{
    public class ResponseErroView : View
    {
        public ResponseErroView(string codigo, string grupo, string mensagem)
        {
            Codigo = codigo;
            Grupo = grupo;
            Mensagem = mensagem;
        }

        protected ResponseErroView()
        {
        }

        public string Codigo { get; private set; }
        public string Grupo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
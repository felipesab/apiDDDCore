using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Notifiers
    {
        public Notifiers() 
        {
            Notificacoes = new List<Notifiers>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifiers> Notificacoes { get; set; }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifiers
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifiers
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}

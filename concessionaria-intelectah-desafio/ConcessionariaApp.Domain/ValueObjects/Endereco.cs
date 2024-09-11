using ConcessionariaApp.Domain.Exceptions;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class Endereco
    {
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        public string EnderecoCompleto { get; private set; }

        public Endereco() { }
        private Endereco(string enderecoCompleto, string cidade, string estado, string cep)
        {
            EnderecoCompleto = enderecoCompleto;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public static Endereco Criar(string enderecoCompleto, string cidade, string estado, string cep)
        {
            if (string.IsNullOrEmpty(enderecoCompleto) &&
                   string.IsNullOrEmpty(cidade) ||
                   string.IsNullOrEmpty(estado) ||
                   string.IsNullOrEmpty(cep))
                throw new EnderecoInvalidoException();

            return new Endereco(enderecoCompleto, cidade, estado, cep);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Endereco endereco)
                return false;
            
            return EnderecoCompleto == endereco.EnderecoCompleto &&
                   Cidade == endereco.Cidade &&
                   Estado == endereco.Estado &&
                   Cep == endereco.Cep;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EnderecoCompleto, Cidade, Estado, Cep);
        }
    }
}

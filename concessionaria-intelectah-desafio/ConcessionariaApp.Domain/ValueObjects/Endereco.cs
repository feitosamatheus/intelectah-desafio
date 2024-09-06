using ConcessionariaApp.Domain.Exceptions;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class Endereco
    {
        public string Rua { get; }
        public string Numero { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Cep { get; }
        public string EnderecoFormatado { get; private set; }

        public Endereco() { }
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            if (ValidarEndereco())
                throw new EnderecoInvalidoException();

            FormatarEndereco();

            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Endereco endereco)
                return false;
            
            return Rua == endereco.Rua &&
                   Numero == endereco.Numero &&
                   Bairro == endereco.Bairro &&
                   Cidade == endereco.Cidade &&
                   Estado == endereco.Estado &&
                   Cep == endereco.Cep;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rua, Numero, Bairro, Cidade, Estado, Cep);
        }

        public bool ValidarEndereco()
        {
             return string.IsNullOrEmpty(Rua) &&
                   string.IsNullOrEmpty(Numero) ||
                   string.IsNullOrEmpty(Bairro) ||
                   string.IsNullOrEmpty(Cidade) ||
                   string.IsNullOrEmpty(Estado) ||
                   string.IsNullOrEmpty(Cep);
        }

        public void FormatarEndereco()
        {
            EnderecoFormatado = string.Format("{0}, {1}, {2}", Rua, Numero, Bairro);
        }
    }
}

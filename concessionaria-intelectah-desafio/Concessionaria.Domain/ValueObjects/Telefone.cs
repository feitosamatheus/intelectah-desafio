using ConcessionariaApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class Telefone
    {
        public string Numero { get; private set; }

        public Telefone(string numero)
        {
            if (ValidarTelefone(numero))
                throw new TelefoneInvalidoException("Número não informado.");
            Numero = numero;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Telefone tel)
                return false;

            return Numero == tel.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numero);
        }

        private bool ValidarTelefone(string tel)
        {
            if (string.IsNullOrEmpty(tel))
                return false;

            tel = Regex.Replace(tel, @"\D", "");

            return tel.Length == 10 || tel.Length == 11;
        }
    }
}

using ConcessionariaApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class Telefone
    {
        public string Numero { get; private set; }

        private Telefone(string numero)
        {
            if (!ValidarTelefone(numero))
                throw new TelefoneInvalidoException("Número telefone inválido.");
            Numero = numero;
        }

        public static Telefone Criar(string telefone)
        {
            return new Telefone(telefone);
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

            if(tel.Length == 10 || tel.Length == 11)
                return true;
            return false;
        }
    }
}

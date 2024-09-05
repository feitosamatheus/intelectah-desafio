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

        public string Mascara()
        {
            if (Numero.Length == 10)
            {
                return string.Format("({0}) {1}-{2}",
                    Numero.Substring(0, 2), 
                    Numero.Substring(2, 4), 
                    Numero.Substring(6, 4));
            }
            else if (Numero.Length == 11)
            {
                return string.Format("({0}) {1}-{2}",
                    Numero.Substring(0, 2),
                    Numero.Substring(2, 5),
                    Numero.Substring(7, 4));
            }

            return Numero;
        }
    }
}

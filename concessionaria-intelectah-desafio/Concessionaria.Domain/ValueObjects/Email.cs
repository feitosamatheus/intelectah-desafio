using ConcessionariaApp.Domain.Exceptions;
using System.Net.Mail;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class Email
    {
        public string EnderecoEmail { get; private set; }

        public Email(string enderecoEmail)
        {
            if (ValidarEmail(enderecoEmail))
                throw new EmailInvalidoException();

            EnderecoEmail = enderecoEmail;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Email email)
                return false;

            return EnderecoEmail == email.EnderecoEmail;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EnderecoEmail);
        }

        private bool ValidarEmail(string endereco)
        {
            if(string.IsNullOrEmpty(endereco))
                return false;

            try
            {
                var addr = new MailAddress(endereco);
                return addr.Address == endereco;
            }
            catch
            {
                return false;
            }
        }
    }
}

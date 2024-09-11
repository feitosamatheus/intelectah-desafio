using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string NomeUsuario { get;  private set; }
        public string Senha { get;  private set; }
        public Email Email { get;  private set; }
        public ENivelAcesso NivelAcesso { get; private set; }

        public Usuario() { }
        private Usuario(string nomeUsuario, string senha, Email email, ENivelAcesso nivelAcesso)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Email = email;
            NivelAcesso = nivelAcesso;
        }

        public static Usuario Criar(string nomeUsuario,string sobrenome, string senha, string emailEndereco, ENivelAcesso nivelAcesso)
        {
            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new ArgumentException("Nome de usuário não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazia.");
            if (string.IsNullOrWhiteSpace(emailEndereco))
                throw new ArgumentException("O endereço de email não pode ser vazio.");

            var email = Email.Criar(emailEndereco); 

            return new Usuario(nomeUsuario, senha, email,nivelAcesso);
        }

        public void AtualizarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazio.");

            Senha = senha;
        }

        public void AtualizarNomeUsuario(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do usuário não pode ser vazio.");

            NomeUsuario = nome;
        }

        public void AtualizarEmail(string enderecoEmail)
        {
            var email = Email.Criar(enderecoEmail);
            Email = email;
        }
    }
}

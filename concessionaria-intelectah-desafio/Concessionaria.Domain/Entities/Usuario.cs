using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string NomeUsuario { get; private set; }
        public string Senha { get; private set; }
        public Email Email { get; private set; }
        public ENivelAcesso NivelAcesso { get; private set; }
        
        public Usuario(string nomeUsuario, string senha, Email email, ENivelAcesso nivelAcesso)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Email = email;
            NivelAcesso = nivelAcesso;
        }
    }
}

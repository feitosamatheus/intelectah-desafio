using Concessionaria.Domain.Enums;
using Concessionaria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; private set; }
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

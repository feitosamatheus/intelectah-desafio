using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Login
{
    public class AutenticacaoUsuarioResultadoDTO
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public ENivelAcesso NivelAcesso { get; set; }
    }
}

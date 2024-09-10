using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Domain.Common
{
    public sealed class ResultadoOperacao
    {      
        public bool Sucesso { get; }
        public string Menssagem { get; }
        public object Objeto { get; }

        public ResultadoOperacao(bool sucesso, string menssagem = "", object objeto = null)
        {
            Sucesso = sucesso;
            Menssagem = menssagem;
            Objeto = objeto;
        }

        public static ResultadoOperacao OK(string menssagem = "Operação realizada com sucesso.") 
                                                => new ResultadoOperacao(true, menssagem);
        public static ResultadoOperacao OK(object obj) 
                                                => new ResultadoOperacao(true, "Operação realizada com sucesso.", obj);
        public static ResultadoOperacao Falha(string menssagem = "")
                                                => new ResultadoOperacao(false, menssagem);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Domain.Common
{
    public class ResultadoOperacao
    {      
        public bool Sucesso { get; }
        public string Menssagem { get; }

        public ResultadoOperacao(bool sucesso, string menssagem = "Operação realizada com sucesso.")
        {
            Sucesso = sucesso;
            Menssagem = menssagem;
        }

        public static ResultadoOperacao OK(string menssagem = "") 
                                                => new ResultadoOperacao(true, menssagem);
        public static ResultadoOperacao Falha(string menssagem = "")
                                                => new ResultadoOperacao(false, menssagem);
    }
}

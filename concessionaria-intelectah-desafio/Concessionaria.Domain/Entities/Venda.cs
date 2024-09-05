﻿using ConcessionariaApp.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConcessionariaApp.Domain.Entities
{
    public class Venda : BaseEntity
    {    
        public int VeiculoId { get; private set; }
        public int ConcessionariaId { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public string ProtocoloVenda { get; private set; }

        public Veiculo Veiculo { get; private set; }
        public Concessionaria Concessionaria { get; private set; }
        public Cliente Cliente { get; private set; }

        public Venda(int veiculoId, int concessionariaId, int clienteId, DateTime dataVenda, decimal precoVenda, string protocoloVenda)
        {
            if(dataVenda > DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(DataVenda), "A data da venda não pode ser no futuro.");
            if(PrecoVenda < 0 )
                throw new ArgumentOutOfRangeException(nameof(PrecoVenda), "O preço não pode ser negativo.");

            VeiculoId = veiculoId;
            ConcessionariaId = concessionariaId;
            ClienteId = clienteId;
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            ProtocoloVenda = protocoloVenda;
        }
    }
}

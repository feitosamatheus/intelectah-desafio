using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Vendas
{
    public class RegistrarVendaDTO
    {
        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public int VeiculoId { get; set; }

        [Display(Name = "Concessionária")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public int ConcessionariaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string NomeCliente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string CPF { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string TelefoneCliente { get; set; }

        [Display(Name = "Data da compra")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string DataVenda { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string ValorVenda { get; set; }

        
    }
}

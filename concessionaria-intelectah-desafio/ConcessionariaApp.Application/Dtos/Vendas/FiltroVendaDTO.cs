using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Vendas
{
    public class FiltroVendaDTO
    {
        #region Filtro web
        [Display(Name = "Modelo")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Modelo { get; set; }

        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string NomeConcessionaria { get; set; }

        [Display(Name = "Localização")]
        public string LocalizacaoConcessionaria { get; set; }
#endregion

        #region Formulário web 
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
        
        [Display(Name = "Data da venda")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        public string ValorVenda { get; set; }
        #endregion
    }
}

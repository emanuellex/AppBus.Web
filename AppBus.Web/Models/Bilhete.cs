using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppBus.Web.Models
{
    public class Bilhete
    {
        [HiddenInput, Column("Id")]
        public string? BilheteId { get; set; }


        [Required, MaxLength(9), Column("NR_BILHETE"), Display(Name = "Número do Bilhete")]
        public string? NumeroBilhete { get; set; }

        [Required, Column("NM_TITULAR"), Display(Name = "Nome do Titular")]
        public string? NomeTitular { get; set; }

        [Column("VL_VALOR")]
        public decimal Valor { get; set; }

        [Column("DS_TIPO_BILHETE"), Display(Name = "Tipo")]
        public TipoBilhete TipoBilhete { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
    public enum TipoBilhete
    {
        Comum, Estudante, Semanal, Mensal, Diario, Tranporte
    }
}

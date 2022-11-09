using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBus.Web.Models
{
    [Table("Tbl_ONIBUS")]
    public class Onibus
    {
        [HiddenInput, Column("Id")]
        public int OnibusId { get; set; }

        [Column("NR_NUMERO"),Required, Display(Name = "Número")]
        public String? OnibusNumero { get; set; }

        [MaxLength(4), Required, Column("NR_LINHA")]
        public string? Linha { get; set; }

        [Required, Column("NM_REGIAO"),Display(Name = "Região")]
        public string? Regiao { get; set; }

        [Column("VL_Valor")]
        public decimal Tarifa { get; set; }

        [Column("DC_STATUS")]
        public Status Status { get; set; }

        [Column("FL_ACESSIVEL")]
        public bool Acessivel  { get; set; }

        //1:1
        public TipoOnibus TipoOnibus { get; set; }

        public int TipoOnibusId  { get; set; }    //FK

        //N:M
        public IList<Avaliacao> Avaliacao { get; set; }

    }

    public enum Status
    {
        Ativo, Desligado, [Display(Name = "Manutenção")] Manutencao
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBus.Web.Models
{
    [Table("Tbl_TIPO_ONIBUS")]
    public class TipoOnibus
    {
        [HiddenInput, Column("Id")]
        public int TipoOnibusId { get; set; }

        [Required, Column("DS_TIPO")]
        public Tipo Tipo { get; set; }
    }
    public enum Tipo
    {
        [Display(Name = "Midiônibus")] midi, [Display(Name = "Miniônibus")] mini, Padron, [Display(Name = "Básico")] basico, Articulado, [Display(Name = "Super Articulado")] super
    }
}

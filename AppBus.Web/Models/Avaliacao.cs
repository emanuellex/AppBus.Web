using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AppBus.Web.Models
{
    [Table("Tbl_AVALIACAO")]
    public class Avaliacao {

        [Column("DS_NOTA")]
        public Nota Nota  { get; set; }

       [Required, MaxLength(500), Column("DC_COMENTARIO")]
        public string? Comentario { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Onibus Onibus { get; set; }  
        
        public int OnibusId { get; set; }


    }
    public enum Nota
    {
       [Display(Name ="1")] um, [Display(Name = "2")] dois, [Display(Name = "3")] tres, [Display(Name = "4")] quarto, [Display(Name = "5")] cinco
    }
}

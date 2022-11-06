using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppBus.Web.Models
{
    public class Avaliacao { 


    [Required, MaxLength(500), Column("NR_AVALIACAO")]
    public string? Numero { get; set; }


    [Required, MaxLength(500), Column("DC_COMENTARIO")]
        public string? Comentario { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBus.Web.Models
{
    [Table("Tbl_TIPO_ONIBUS")]
    public class TipoOnibus
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}

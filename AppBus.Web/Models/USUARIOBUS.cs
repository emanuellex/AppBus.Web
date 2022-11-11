using System.ComponentModel.DataAnnotations.Schema;

namespace AppBus.Web.Models
{
    [Table("Tbl_USUARIO_BUS")]
    public class USUARIOBUS
    {
        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Onibus Onibus { get; set; }

        public int OnibusId { get; set; }


    }
}

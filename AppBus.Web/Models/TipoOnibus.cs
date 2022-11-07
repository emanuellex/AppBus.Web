using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Models
{
    public class TipoOnibus
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}

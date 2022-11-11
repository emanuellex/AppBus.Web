using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AppBus.Web.Models
{
    public class UsuBus {

      
        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Onibus Onibus { get; set; }  
        
        public int OnibusId { get; set; }


    }
   
}

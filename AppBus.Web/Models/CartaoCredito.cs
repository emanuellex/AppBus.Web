using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Models
{
    [Table("Tbl_CARTAO_CREDITO")]
    public class CartaoCredito
    {
        [HiddenInput, Column("Id")]
        public string? CartaoCreditoId { get; set; }


        [Required, MaxLength(16), Column("NR_Cartao")]
        public string? NumeroCartao { get; set; }

        [Required,Column("NM_TITULAR")]
        public string? NomeTitular { get; set; }


        [MaxLength(11), Display(Name = "CPF"), Required, Column("NR_CPF")]
        public string? Documento { get; set; }

        [MaxLength(3), Display(Name = "CVV"), Required, Column("NR_CVV")]
        public string? CVV { get; set; }

        [MaxLength(3), Display(Name = "Validade"), Required, Column("DT_VALIDADE")]
        public DateOnly Validade { get; set; }

        [Required, Column("DS_Bandeira")]
        public Bandeira Bandeira { get; set; }

        
        //N:1
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }


    }

    public enum Bandeira
    {
        Elo, Visa, Mastercard, Hipercard,[Display(Name = "America Express")] AmericaExpress
    }
}

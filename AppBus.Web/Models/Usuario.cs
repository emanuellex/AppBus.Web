using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppBus.Web.Models
{
    [Table("Tbl_USUARIO")]
    public class Usuario
    {
        [HiddenInput, Column("Id")]
        public int UsuarioId { get; set; }

        [Column("NM_NOME"), Required]
        public string? Nome { get; set; }

        [Column("DS_EMAIL"), Required]
        public string? Email { get; set; }

        [Column("DS_SENHA"), Required]
        public string? Senha { get; set; }

        [Column("DS_TELEFONE"), Required, MaxLength(13)]
        public string? Telefone { get; set; }

        [Column("NR_CPF"), Required, MaxLength(12)]
        public string? Cpf { get; set; }

        [Column("DT_DATA_NASCIMENTO"), Required, Display(Name = "Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }


        //1:N
        public List<CartaoCredito>? Cartoes { get; set; }

        public List<Bilhete>? Bilhetes { get; set; }

        //N:M
        public IList<Avaliacao> Avaliacao { get; set; }
    }
}

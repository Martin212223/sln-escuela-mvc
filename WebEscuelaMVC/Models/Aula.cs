using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebEscuelaMVC.Validations;

namespace WebEscuelaMVC.Models
{
    [Table("Aula")]
    public class Aula
    {

        public int Id { get; set; }

        [Required]
        [LargerThan100]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }

    }
}

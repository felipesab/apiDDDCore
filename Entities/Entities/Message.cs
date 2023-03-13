using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_MESSAGES")]
    public class Message : Notifiers
    {
        [Column("MSG_IDD")]
        public int Id { get; set; }

        [Column("MSG_TITULO")]
        public string Titulo { get; set; }

        [Column("MSG_ATIVO")]
        [MaxLength(255)]
        public bool Ativo { get; set; }

        [Column("MSG_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("MSG_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set;}

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

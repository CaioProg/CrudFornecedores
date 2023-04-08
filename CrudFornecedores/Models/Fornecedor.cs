using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudFornecedores.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [StringLength(100, ErrorMessage = "limite de 100 caracteres")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Cnpj' é obrigatório!")]
        [Column("Cnpj")]
        [Display(Name = "Cnpj")]
        public long Cnpj { get; set; }

        [Required(ErrorMessage = "O campo 'Especialidade' é obrigatório!")]
        [Column("Especialidade")]
        [Display(Name = "Especialidade")]
        public string Especialidade { get; set; }
        public int IdPloomes { get; set; }
    }
}

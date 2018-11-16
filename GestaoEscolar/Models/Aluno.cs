using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    #region Definições Academicas

    public partial class Anos
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Ano")]
        public int ano { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }

        [Display(Name = "Estado")]
        [StringLength(20)]
        public string estado { get; set; }

        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }

        public IList<AnoLectivo> AnoLectivo { get; set; }

    }

    public partial class AnoLectivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Codigo")]
        [StringLength(20)]
        public string codigo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }

        [Display(Name = "Ano")]
        public int anoId { get; set; }

        [Display(Name = "Data de Inicio")]
        public DateTime dataInicio { get; set; }

        [Display(Name = "Data de Fim")]
        public DateTime dataFim { get; set; }
        
        [ForeignKey("anoId")]
        [Display(Name = "Ano")]
        public virtual Anos Ano { get; set; }
        
        //public virtual Classe Classe { get; set; }
        //public virtual ICollection<Turmas> Turmas { get; set; }
        //public virtual ICollection<AlunoAnoLectivo> AlunoAnoLectivo { get; set; }

    }

    public partial class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }

        [Display(Name = "Nivel")]
        [StringLength(20)]
        public string nivelCode { get; set; }

        [ForeignKey("nivelCode")]
        [Display(Name = "Nivel")]
        public virtual Nivel Nivel { get; set; }

        public virtual List<AnoLectivo> AnoLectivo { get; set; }

        public virtual List<Disciplina> Disciplinas { get; set; }
    }

    public partial class Nivel
    {
        [Key]
        [Display(Name = "Código")]
        [StringLength(20)]
        public string codigo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }
    }

    public partial class Disciplina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }

        [Display(Name = "Classe")]
        public int classe_id { get; set; }

        [ForeignKey("classe_id")]
        [Display(Name = "Classe")]
        public virtual Classe classe { get; set; }
    }

    public partial class Turmas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(20)]
        public string desc { get; set; }

        [Display(Name = "Classe")]
        public int classeId { get; set; }

        [ForeignKey("classeId")]
        [Display(Name = "Classe")]
        public virtual Classe Classe { get; set; }
    }
    #endregion
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Código")]
        [StringLength(50)]
        [Required]
        public string codigo { get; set; }

        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        [Required]
        public string nome { get; set; }

        [Display(Name = "Apelido")]
        [StringLength(100)]
        [Required]
        public string apelido { get; set; }

        [Display(Name="Morada")]
        [StringLength(100)]
        [Required]
        public string morada { get; set; }

        [Display(Name = "Localidade")]
        [StringLength(50)]
        public string localidade { get; set; }

        [Display(Name = "NIB")]
        [StringLength(20)]
        public string nib { get; set; }

        [Display(Name = "Documento Identificação")]
        [StringLength(50)]
        public string documentoIdentificacao { get; set; }

        [Display(Name = "Número Documento")]
        [StringLength(50)]
        public string numeroDocumento { get; set; }

        [Display(Name = "Validade Documento")]
        [DataType(DataType.Date)]
        public DateTime validadeDocumento { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(50)]
        public string telefone { get; set; }

        [Display(Name = "Celular")]
        [StringLength(50)]
        public string celular { get; set; }

        [Display(Name = "Nacionalidade")]
        [Required]
        public string nacionalidade { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Local de Nascimento")]
        [Required]
        public string localNascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public bool sexo { get; set; }

        [Display(Name = "Nome Pai")]
        [StringLength(100)]
        public string nomePai { get; set; }

        [Display(Name = "Tel. Pai")]
        [StringLength(50)]
        public string telefonePai { get; set; }

        [Display(Name = "Email Pai")]
        [StringLength(50)]
        public string emailPai { get; set; }

        [Display(Name = "Nome Mãe")]
        [StringLength(100)]
        public string nomeMae { get; set; }

        [Display(Name = "Tel. Mãe")]
        [StringLength(50)]
        public string telefoneMãe { get; set; }

        [Display(Name = "Email Mãe")]
        [StringLength(50)]
        public string emailMae { get; set; }

        [Display(Name = "Nome Enc.")]
        [StringLength(100)]
        public string nomeEncarregado { get; set; }

        [Display(Name = "Tel. Enc.")]
        [StringLength(50)]
        public string telefoneEncarregado { get; set; }

        [Display(Name = "Email Enc.")]
        [StringLength(50)]
        public string emailEncarregado { get; set; }

        
    }

    //public partial class AlunoAnoLectivo
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int id { get; set; }
    //    public decimal Id_Aluno { get; set; }
    //    public decimal Id_AnoLectivo { get; set; }
    //    public Nullable<decimal> Id_Turma { get; set; }

    //    public virtual AnoLectivo AnoLectivo { get; set; }
    //    public virtual Aluno Aluno { get; set; }
    //    public virtual Turmas Turmas { get; set; }
    //}

    public partial class TabelaHorarios
    {
        public TabelaHorarios()
        {
            this.Turmas = new HashSet<Turmas>();
        }

        public decimal ID { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }

        public virtual ICollection<Turmas> Turmas { get; set; }
    }

    public partial class Aluno_Efectividade
    {
        public decimal Id { get; set; }
        public Nullable<int> Mes { get; set; }
        public Nullable<decimal> Dia { get; set; }
        public Nullable<int> Presenca { get; set; }
        public string Objservacao { get; set; }
        public Nullable<decimal> Aluno_Id { get; set; }
        public Nullable<decimal> Classe_Id { get; set; }
        public Nullable<decimal> Ano_Id { get; set; }

        public virtual Anos Ano { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    #region Definições Academicas
    public partial class Classe
    {
        public Classe()
        {

        }

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
    #endregion
    public class Aluno
    {
        public decimal id { get; set; }

        public string codigo { get; set; }

        public string nome { get; set; }

        public string morada { get; set; }

        public string telefone { get; set; }

        public string celular { get; set; }

        public DateTime dataAniversario { get; set; }

        public string localNascimento { get; set; }

        public bool sexo { get; set; }

        public virtual ICollection<AlunoAnoLectivo> AlunoAnoLectivo { get; set; }

    }

    public partial class AlunoAnoLectivo
    {
        public int id { get; set; }
        public decimal Id_Aluno { get; set; }
        public decimal Id_AnoLectivo { get; set; }
        public Nullable<decimal> Id_Turma { get; set; }

        public virtual AnoLectivo AnoLectivo { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turmas Turmas { get; set; }
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

        public Nullable<int> AnoLectivoId { get; set; }
        public Nullable<int> HorarioId { get; set; }

        //public virtual IList<AlunoAnoLectivo> AlunoAnoLectivo { get; set; }
        //public virtual AnoLectivo AnoLectivo { get; set; }
        //public virtual TabelaHorarios TabelaHorarios { get; set; }

        [ForeignKey ("classeId")]
        [Display(Name = "Classe")]
        public virtual Classe Classe { get; set; }
    }

    public partial class AnoLectivo
    {
        public AnoLectivo()
        {
            this.AlunoAnoLectivo = new HashSet<AlunoAnoLectivo>();
            this.Turmas = new HashSet<Turmas>();
        }

        public decimal ID { get; set; }
        public Nullable<decimal> Ano_Id { get; set; }
        public Nullable<decimal> Classe_Id { get; set; }

        public virtual ICollection<AlunoAnoLectivo> AlunoAnoLectivo { get; set; }
        public virtual Anos Anos { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual ICollection<Turmas> Turmas { get; set; }
    }

    public partial class Anos
    {
        public Anos()
        {
            this.Aluno_Efectividade = new HashSet<Aluno_Efectividade>();
            this.AnoLectivo = new HashSet<AnoLectivo>();
        }

        public int id { get; set; }
        public Nullable<decimal> ano { get; set; }
        public Nullable<int> ESTADO { get; set; }
        public Nullable<System.DateTime> INICIO { get; set; }
        public Nullable<System.DateTime> FIM { get; set; }

        public virtual ICollection<Aluno_Efectividade> Aluno_Efectividade { get; set; }
        public virtual ICollection<AnoLectivo> AnoLectivo { get; set; }
    }

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

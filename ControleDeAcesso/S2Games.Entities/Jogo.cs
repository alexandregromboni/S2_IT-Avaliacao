namespace S2Games.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Jogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogo()
        {
            this.Emprestimoes = new HashSet<Emprestimo>();
        }

        [Key]
        public int Id_Jogo { get; set; }

        public string Descricao { get; set; }

        public int? Plataforma { get; set; }
        
        public DateTime Data_Criacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprestimo> Emprestimoes { get; set; }
    }
}

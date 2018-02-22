namespace S2Games.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Emprestimoes = new HashSet<Emprestimo>();
        }

        [Key]
        public int Id_Usuario { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public DateTime Data_Criacao { get; set; }

        public int Perfil { get; set; }

        public bool Is_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprestimo> Emprestimoes { get; set; }
    }
}

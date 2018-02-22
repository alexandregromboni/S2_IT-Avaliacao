namespace S2Games.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Emprestimo
    {
        [Key]
        public int Id_Emprestimo { get; set; }
        
        public int Id_Jogo { get; set; }
        
        public int Id_Usuario { get; set; }
        
        public DateTime Data_Emprestimo { get; set; }
        
        public DateTime? Data_Devolucao { get; set; }
        
        public int Status_Emprestimo { get; set; }

    
        public virtual Jogo Jogo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2Games.Web.Models
{
    public class EmprestimoViewModel
    {
        public int Id_Emprestimo { get; set; }

        public int Id_Jogo { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime Data_Emprestimo { get; set; }

        public DateTime? Data_Devolucao { get; set; }

        public int Status_Emprestimo { get; set; }


        public UsuarioViewModel Usuario { get; set; }
        public JogoViewModel Jogo { get; set; }
    }
}
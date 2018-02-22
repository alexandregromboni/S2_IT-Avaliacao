using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2Games.Web.Models
{
    public class JogoViewModel
    {
        public int Id_Jogo { get; set; }

        public string Descricao { get; set; }

        public int? Plataforma { get; set; }

        public DateTime Data_Criacao { get; set; }
    }
}
using S2Games.Entities;
using System.Collections.Generic;

namespace S2Games.Business.Interface
{
    public interface IJogoBusiness
    {
        List<Jogo> GetJogosPorDescricao(string descricao);

        List<Jogo> GetJogo(int? idJogo = null);

        void AdicionarJogo(Jogo objJogo);

        Jogo Recuperar(int id);

        void ExcluirJogo(Jogo objJogo);

        void AlterarJogo(Jogo objJogo);
    }
}

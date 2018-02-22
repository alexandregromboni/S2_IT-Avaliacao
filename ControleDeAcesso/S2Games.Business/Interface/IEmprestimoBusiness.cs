using S2Games.Entities;
using System.Collections.Generic;

namespace S2Games.Business.Interface
{
    public interface IEmprestimoBusiness
    {
        List<Emprestimo> GetEmprestimosPorJogo(int idJogo);

        List<Emprestimo> GetEmprestimosPorUsuario(int idUsuario);

        List<Emprestimo> GetEmprestimo(int? idEmprestimo = null);

        void AdicionarEmprestimo(Emprestimo objEmprestimo);

        Emprestimo Recuperar(int id);

        void ExcluirEmprestimo(Emprestimo objEmprestimo);

        void AlterarEmprestimo(Emprestimo objEmprestimo);
    }
}

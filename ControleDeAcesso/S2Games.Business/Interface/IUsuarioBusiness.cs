using S2Games.Entities;
using System.Collections.Generic;

namespace S2Games.Business.Interface
{
    public interface IUsuarioBusiness
    {
        List<Usuario> GetUsuariosPorNome(string nome);

        List<Usuario> GetUsuariosPorEmail(string email);

        List<Usuario> GetUsuario(int? idUsuario = null);

        void AdicionarUsuario(Usuario objUsuario);

        Usuario Recuperar(int id);

        void ExcluirUsuario(Usuario objUsuario);

        void AlterarUsuario(Usuario objUsuario);
    }
}

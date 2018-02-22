using S2Games.Business.Interface;
using S2Games.DAL;
using S2Games.DAL.Interfaces;
using S2Games.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S2Games.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {

        IUsuarioDAL _usuarioDAL;
        public UsuarioBusiness()
        {
            try
            {
                _usuarioDAL = new UsuarioDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> GetUsuariosPorNome(string nome)
        {
            try
            {
                return _usuarioDAL.Get(e => e.Nome.Equals(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> GetUsuariosPorEmail(string email)
        {
            try
            {
                return _usuarioDAL.Get(e => e.Email.Equals(email)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> GetUsuario(int? idUsuario = null)
        {
            try
            {
                if (idUsuario == null)
                {
                    return _usuarioDAL.GetTodos().ToList();
                }
                else
                {
                    return _usuarioDAL.Get(p => p.Id_Usuario == idUsuario).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarUsuario(Usuario objUsuario)
        {
            try
            {
                _usuarioDAL.Adicionar(objUsuario);
                _usuarioDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Recuperar(int id)
        {
            try
            {
                return _usuarioDAL.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirUsuario(Usuario objUsuario)
        {
            try
            {
                _usuarioDAL.Deletar(c => c == objUsuario);
                _usuarioDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarUsuario(Usuario objUsuario)
        {
            try
            {
                _usuarioDAL.Atualizar(objUsuario);
                _usuarioDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

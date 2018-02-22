using S2Games.Business.Interface;
using S2Games.DAL;
using S2Games.DAL.Interfaces;
using S2Games.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S2Games.Business
{
    public class EmprestimoBusiness : IEmprestimoBusiness
    {
        IEmprestimoDAL _emprestimoDAL;
        public EmprestimoBusiness()
        {
            try
            {
                _emprestimoDAL = new EmprestimoDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarEmprestimo(Emprestimo objEmprestimo)
        {
            try
            {
                objEmprestimo.Data_Emprestimo = DateTime.Now;
                _emprestimoDAL.Adicionar(objEmprestimo);
                _emprestimoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarEmprestimo(Emprestimo objEmprestimo)
        {
            try
            {
                _emprestimoDAL.Atualizar(objEmprestimo);
                _emprestimoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEmprestimo(Emprestimo objEmprestimo)
        {
            try
            {
                _emprestimoDAL.Deletar(c => c == objEmprestimo);
                _emprestimoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> GetEmprestimo(int? idEmprestimo = null)
        {
            try
            {
                if (idEmprestimo == null)
                {
                    return _emprestimoDAL.GetTodos().ToList();
                }
                else
                {
                    return _emprestimoDAL.Get(p => p.Id_Emprestimo == idEmprestimo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> GetEmprestimosPorJogo(int idJogo)
        {
            try
            {
                return _emprestimoDAL.Get(e => e.Id_Jogo == idJogo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> GetEmprestimosPorUsuario(int idUsuario)
        {
            try
            {
                return _emprestimoDAL.Get(e => e.Id_Usuario == idUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Emprestimo Recuperar(int id)
        {
            try
            {
                return _emprestimoDAL.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

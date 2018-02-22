using S2Games.Business.Interface;
using S2Games.DAL;
using S2Games.DAL.Interfaces;
using S2Games.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S2Games.Business
{
    public class JogoBusiness : IJogoBusiness
    {
        IJogoDAL _jogoDAL;
        public JogoBusiness()
        {
            try
            {
                _jogoDAL = new JogoDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarJogo(Jogo objJogo)
        {
            try
            {
                _jogoDAL.Adicionar(objJogo);
                _jogoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarJogo(Jogo objJogo)
        {
            try
            {
                _jogoDAL.Atualizar(objJogo);
                _jogoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirJogo(Jogo objJogo)
        {
            try
            {
                _jogoDAL.Deletar(c => c == objJogo);
                _jogoDAL.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jogo> GetJogo(int? idJogo = null)
        {
            try
            {
                if (idJogo == null)
                {
                    return _jogoDAL.GetTodos().ToList();
                }
                else
                {
                    return _jogoDAL.Get(p => p.Id_Jogo == idJogo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jogo> GetJogosPorDescricao(string descricao)
        {
            try
            {
                return _jogoDAL.Get(e => e.Descricao.Equals(descricao)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Jogo Recuperar(int id)
        {
            try
            {
                return _jogoDAL.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

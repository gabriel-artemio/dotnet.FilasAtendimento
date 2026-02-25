using fila_atendimento_api.DAL;
using fila_atendimento_api.Models;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace fila_atendimento_api.BLL
{
    public class UnidadeServicoBLL
    {
        private DbConnection cn;
        private readonly UnidadeServicoDAL unidadeServicoDAL;

        public UnidadeServicoBLL(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            cn = new SqliteConnection(connectionString);
            unidadeServicoDAL = new UnidadeServicoDAL();
        }

        public List<UnidadeServico> GetAll()
        {
            List<UnidadeServico> list = new();

            try
            {
                cn.Open();
                list = unidadeServicoDAL.GetAll(cn);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return list;
        }
        public UnidadeServico GetById(int id)
        {
            UnidadeServico? retorno;

            try
            {
                cn.Open();
                retorno = unidadeServicoDAL.GetById(cn, id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public void Insert(UnidadeServico unidadeServico)
        {
            try
            {
                cn.Open();
                unidadeServicoDAL.Insert(cn, unidadeServico);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public void Update(UnidadeServico unidadeServico)
        {
            try
            {
                cn.Open();
                unidadeServicoDAL.Update(cn, unidadeServico);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

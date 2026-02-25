using fila_atendimento_api.DAL;
using fila_atendimento_api.Models;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace fila_atendimento_api.BLL
{
    public class UnidadeBLL
    {
        private DbConnection cn;
        private readonly UnidadeDAL unidadeDAL;

        public UnidadeBLL(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            cn = new SqliteConnection(connectionString);
            unidadeDAL = new UnidadeDAL();
        }

        public List<Unidade> GetAll()
        {
            List<Unidade> list = new();

            try
            {
                cn.Open();
                list = unidadeDAL.GetAll(cn);
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
        public Unidade GetById(int id)
        {
            Unidade? retorno;

            try
            {
                cn.Open();
                retorno = unidadeDAL.GetById(cn, id);
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

        public void Insert(Unidade unidade)
        {
            try
            {
                cn.Open();
                unidadeDAL.Insert(cn, unidade);
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
        public void Update(Unidade unidade)
        {
            try
            {
                cn.Open();
                unidadeDAL.Update(cn, unidade);
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

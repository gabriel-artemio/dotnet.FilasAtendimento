using fila_atendimento_api.DAL;
using fila_atendimento_api.Models;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace fila_atendimento_api.BLL
{
    public class PrioridadeBLL
    {
        private DbConnection cn;
        private readonly PrioridadeDAL prioridadeDAL;

        public PrioridadeBLL(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            cn = new SqliteConnection(connectionString);
            prioridadeDAL = new PrioridadeDAL();
        }

        public List<Prioridade> GetAll()
        {
            List<Prioridade> list = new();

            try
            {
                cn.Open();
                list = prioridadeDAL.GetAll(cn);
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
        public Prioridade GetById(int id)
        {
            Prioridade? retorno;

            try
            {
                cn.Open();
                retorno = prioridadeDAL.GetById(cn, id);
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

        public void Insert(Prioridade prioridade)
        {
            try
            {
                cn.Open();
                prioridadeDAL.Insert(cn, prioridade);
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
        public void Update(Prioridade prioridade)
        {
            try
            {
                cn.Open();
                prioridadeDAL.Update(cn, prioridade);
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

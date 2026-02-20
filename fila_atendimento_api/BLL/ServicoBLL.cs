using fila_atendimento_api.DAL;
using fila_atendimento_api.Models;
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace fila_atendimento_api.BLL
{
    public class ServicoBLL
    {
        private DbConnection cn;
        private readonly ServicoDAL servicoDAL;

        public ServicoBLL(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            cn = new SqliteConnection(connectionString);
            servicoDAL = new ServicoDAL();
        }

        public List<Servico> GetAll()
        {
            List<Servico> list = new();

            try
            {
                cn.Open();
                list = servicoDAL.GetAll(cn);
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
        public Servico GetById(int id)
        {
            Servico? retorno;

            try
            {
                cn.Open();
                retorno = servicoDAL.GetById(cn, id);
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
        
        public void Insert(Servico servico)
        {
            try
            {
                cn.Open();
                servicoDAL.Insert(cn, servico);
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
        public void Update(Servico servico)
        {
            try
            {
                cn.Open();
                servicoDAL.Update(cn, servico);
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

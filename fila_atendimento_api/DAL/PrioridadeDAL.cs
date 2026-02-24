using fila_atendimento_api.Models;
using System.Data.Common;
using System.Text;

namespace fila_atendimento_api.DAL
{
    public class PrioridadeDAL
    {
        public Prioridade? GetById(DbConnection cn, int cd_prioridade)
        {
            return GetAll(cn, cd_prioridade).FirstOrDefault();
        }
        public List<Prioridade> GetAll(DbConnection cn)
        {
            return GetAll(cn, 0);
        }
        private List<Prioridade> GetAll(DbConnection cn, int cd_prioridade)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("cd_prioridade, nm_prioridade, sigla ");
            sb.Append("FROM prioridade p ");
            sb.Append("WHERE 1 = 1 ");

            List<DbParameter> p = new List<DbParameter>();
            if (cd_prioridade > 0)
            {
                sb.Append(" AND p.cd_prioridade = " + cd_prioridade);
            }

            List<Prioridade> list = new List<Prioridade>();
            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddRange(p.ToArray());
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Prioridade
                        {
                            cd_prioridade = dr.GetInt32(0),
                            nm_prioridade = dr.GetString(1),
                            sigla = dr.GetString(2)
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(DbConnection cn, Prioridade prioridade)
        {
            var sql = @"INSERT INTO prioridade(nm_prioridade, sigla) VALUES (@nm_prioridade, @sigla)";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_prioridade";
                pNmServico.Value = prioridade.nm_prioridade;
                cmd.Parameters.Add(pNmServico);

                var pSigla = cmd.CreateParameter();
                pSigla.ParameterName = "@sigla";
                pSigla.Value = prioridade.sigla;
                cmd.Parameters.Add(pSigla);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(DbConnection cn, Prioridade prioridade)
        {
            var sql = @"UPDATE prioridade SET nm_prioridade = @nm_prioridade, sigla = @sigla WHERE cd_prioridade = @id";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pId = cmd.CreateParameter();
                pId.ParameterName = "@id";
                pId.Value = prioridade.cd_prioridade;
                cmd.Parameters.Add(pId);

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_prioridade";
                pNmServico.Value = prioridade.nm_prioridade;
                cmd.Parameters.Add(pNmServico);

                var pSigla = cmd.CreateParameter();
                pSigla.ParameterName = "@sigla";
                pSigla.Value = prioridade.sigla;
                cmd.Parameters.Add(pSigla);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

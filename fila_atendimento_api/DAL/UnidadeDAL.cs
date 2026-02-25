using fila_atendimento_api.Models;
using System.Data.Common;
using System.Text;

namespace fila_atendimento_api.DAL
{
    public class UnidadeDAL
    {
        public Unidade? GetById(DbConnection cn, int cd_unidade)
        {
            return GetAll(cn, cd_unidade).FirstOrDefault();
        }
        public List<Unidade> GetAll(DbConnection cn)
        {
            return GetAll(cn, 0);
        }
        private List<Unidade> GetAll(DbConnection cn, int cd_unidade)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("cd_unidade, nm_unidade, ativo ");
            sb.Append("FROM unidade u ");
            sb.Append("WHERE 1 = 1 ");

            List<DbParameter> p = new List<DbParameter>();
            if (cd_unidade > 0)
            {
                sb.Append(" AND u.cd_unidade = " + cd_unidade);
            }

            List<Unidade> list = new List<Unidade>();
            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddRange(p.ToArray());
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Unidade
                        {
                            cd_unidade = dr.GetInt32(0),
                            nm_unidade = dr.GetString(1),
                            ativo = dr.GetBoolean(2)
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(DbConnection cn, Unidade unidade)
        {
            var sql = @"INSERT INTO unidade(nm_unidade ativo) VALUES (@nm_unidade @ativo)";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_unidade";
                pNmServico.Value = unidade.nm_unidade;
                cmd.Parameters.Add(pNmServico);

                var pAtivo = cmd.CreateParameter();
                pAtivo.ParameterName = "@ativo";
                pAtivo.Value = unidade.ativo;
                cmd.Parameters.Add(pAtivo);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(DbConnection cn, Unidade unidade)
        {
            var sql = @"UPDATE unidade SET nm_unidade = @nm_unidade, ativo = @ativo WHERE cd_unidade = @id";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pId = cmd.CreateParameter();
                pId.ParameterName = "@id";
                pId.Value = unidade.cd_unidade;
                cmd.Parameters.Add(pId);

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_unidade";
                pNmServico.Value = unidade.nm_unidade;
                cmd.Parameters.Add(pNmServico);

                var pAtivo = cmd.CreateParameter();
                pAtivo.ParameterName = "@ativo";
                pAtivo.Value = unidade.ativo;
                cmd.Parameters.Add(pAtivo);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

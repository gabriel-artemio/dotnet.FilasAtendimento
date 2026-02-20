using fila_atendimento_api.Models;
using System.Data.Common;
using System.Text;

namespace fila_atendimento_api.DAL
{
    public class ServicoDAL
    {
        public Servico? GetById(DbConnection cn, int cd_servico)
        {
            return GetAll(cn, cd_servico).FirstOrDefault();
        }
        public List<Servico> GetAll(DbConnection cn)
        {
            return GetAll(cn, 0);
        }
        private List<Servico> GetAll(DbConnection cn, int cd_servico)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("cd_servico, nm_servico, sigla, ativo ");
            sb.Append("FROM servico s ");
            sb.Append("WHERE 1 = 1 ");

            List<DbParameter> p = new List<DbParameter>();
            if (cd_servico > 0)
            {
                sb.Append(" AND s.cd_servico = " + cd_servico);
            }

            List<Servico> list = new List<Servico>();
            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddRange(p.ToArray());
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Servico
                        {
                            cd_servico = dr.GetInt32(0),
                            nm_servico = dr.GetString(1),
                            sigla = dr.GetString(2),
                            ativo = dr.GetBoolean(3)
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(DbConnection cn, Servico servico)
        {
            var sql = @"INSERT INTO servico(nm_servico, sigla, ativo) VALUES (@nm_servico, @sigla, @ativo)";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_servico";
                pNmServico.Value = servico.nm_servico;
                cmd.Parameters.Add(pNmServico);

                var pSigla = cmd.CreateParameter();
                pSigla.ParameterName = "@sigla";
                pSigla.Value = servico.sigla;
                cmd.Parameters.Add(pSigla);

                var pAtivo = cmd.CreateParameter();
                pAtivo.ParameterName = "@ativo";
                pAtivo.Value = servico.ativo;
                cmd.Parameters.Add(pAtivo);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(DbConnection cn, Servico servico)
        {
            var sql = @"UPDATE servico SET nm_servico = @nm_servico, sigla = @sigla, ativo = @ativo WHERE cd_servico = @id";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pId = cmd.CreateParameter();
                pId.ParameterName = "@id";
                pId.Value = servico.cd_servico;
                cmd.Parameters.Add(pId);

                var pNmServico = cmd.CreateParameter();
                pNmServico.ParameterName = "@nm_servico";
                pNmServico.Value = servico.nm_servico;
                cmd.Parameters.Add(pNmServico);

                var pSigla = cmd.CreateParameter();
                pSigla.ParameterName = "@sigla";
                pSigla.Value = servico.sigla;
                cmd.Parameters.Add(pSigla);

                var pAtivo = cmd.CreateParameter();
                pAtivo.ParameterName = "@ativo";
                pAtivo.Value = servico.ativo;
                cmd.Parameters.Add(pAtivo);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

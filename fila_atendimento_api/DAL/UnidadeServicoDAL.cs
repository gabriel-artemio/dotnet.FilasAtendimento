using fila_atendimento_api.Models;
using System.Data.Common;
using System.Text;

namespace fila_atendimento_api.DAL
{
    public class UnidadeServicoDAL
    {
        public UnidadeServico? GetById(DbConnection cn, int cd_unidade_servico)
        {
            return GetAll(cn, cd_unidade_servico).FirstOrDefault();
        }
        public List<UnidadeServico> GetAll(DbConnection cn)
        {
            return GetAll(cn, 0);
        }
        private List<UnidadeServico> GetAll(DbConnection cn, int cd_unidade_servico)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("cd_unidade_servico, cd_unidade, cd_servico ");
            sb.Append("FROM unidade_servico us ");
            sb.Append("WHERE 1 = 1 ");

            List<DbParameter> p = new List<DbParameter>();
            if (cd_unidade_servico > 0)
            {
                sb.Append(" AND us.cd_unidade_servico = " + cd_unidade_servico);
            }

            List<UnidadeServico> list = new List<UnidadeServico>();
            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddRange(p.ToArray());
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new UnidadeServico
                        {
                            cd_unidade_servico = dr.GetInt32(0),
                            cd_unidade = dr.GetInt32(1),
                            cd_servico = dr.GetInt32(2)
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(DbConnection cn, UnidadeServico unidadeServico)
        {
            var sql = @"INSERT INTO unidade_servico(cd_unidade, cd_servico) VALUES (@cd_unidade, @cd_servico)";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pCdUnidade = cmd.CreateParameter();
                pCdUnidade.ParameterName = "@cd_unidade";
                pCdUnidade.Value = unidadeServico.cd_unidade;
                cmd.Parameters.Add(pCdUnidade);

                var pCdServico = cmd.CreateParameter();
                pCdServico.ParameterName = "@cd_servico";
                pCdServico.Value = unidadeServico.cd_servico;
                cmd.Parameters.Add(pCdServico);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(DbConnection cn, UnidadeServico unidadeServico)
        {
            var sql = @"UPDATE unidade_servico SET cd_unidade = @cd_unidade, cd_servico = @cd_servico WHERE cd_unidade_servico = @id";

            using (DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;

                var pId = cmd.CreateParameter();
                pId.ParameterName = "@id";
                pId.Value = unidadeServico.cd_unidade_servico;
                cmd.Parameters.Add(pId);

                var pCdUnidade = cmd.CreateParameter();
                pCdUnidade.ParameterName = "@cd_unidade";
                pCdUnidade.Value = unidadeServico.cd_unidade;
                cmd.Parameters.Add(pCdUnidade);

                var pCdServico = cmd.CreateParameter();
                pCdServico.ParameterName = "@cd_servico";
                pCdServico.Value = unidadeServico.cd_servico;
                cmd.Parameters.Add(pCdServico);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

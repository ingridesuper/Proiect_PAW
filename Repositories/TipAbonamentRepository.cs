using System;
using System.Collections.Generic;
using System.Linq;
using _2_1058_PISLARU_INGRID.Entities;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace _2_1058_PISLARU_INGRID.Repositories
{
    public class TipAbonamentRepository
    {
        public int GetTotalCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(*) FROM tipabonament";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }


        public List<TipAbonament> FetchAllTipAbonament(int currentPage, int pageSize)
        {
            var data = new List<TipAbonament>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT * FROM tipabonament ORDER BY ID OFFSET :skip ROWS " +
                    $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TipAbonament tip = new TipAbonament();
                        tip.Id = int.Parse(dataReader["ID"].ToString());
                        tip.Nume = dataReader["NUME"].ToString();
                        tip.Pret = double.Parse(dataReader["Pret"].ToString());

                        data.Add(tip);

                    }
                    
                }

                conn.Close();
            }

            return data;
        }

        public void AddTipAbonament(TipAbonament tipAbonament)
        {
            string sql = $"INSERT INTO tipabonament(id, nume, pret) VALUES ({tipAbonament.Id}, '{tipAbonament.Nume}', {tipAbonament.Pret})";

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    }
}

using _2_1058_PISLARU_INGRID.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1058_PISLARU_INGRID.Repositories
{
    public class ClientAbonamentRepository
    {
        public int GetTotalCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(*) FROM clientabonament";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }


        public List<ClientAbonament> FetchAllClientAbonament(int currentPage, int pageSize)
        {
            var data = new List<ClientAbonament>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT * FROM clientabonament ORDER BY clientid, tipabonamentid OFFSET :skip ROWS " +
                    $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ClientAbonament clientAbonament = new ClientAbonament();
                        clientAbonament.ClientId = int.Parse(dataReader["ClientId"].ToString());
                        clientAbonament.TipAbonamentId = int.Parse(dataReader["TipAbonamentId"].ToString());

                        var discount = dataReader["Discount"];
                        if (discount != DBNull.Value)
                        {
                            clientAbonament.Discount = double.Parse(discount.ToString());
                        }

                        clientAbonament.DataStart = dataReader.GetDateTime(dataReader.GetOrdinal("DataStart"));

                        var dataEnd = dataReader["DataEnd"];
                        if (dataEnd != DBNull.Value)
                        {
                            clientAbonament.DataEnd = dataReader.GetDateTime(dataReader.GetOrdinal("DataEnd"));
                        }

                        data.Add(clientAbonament);
                    }

                }

                conn.Close();
            }

            return data;
        }
    }
}

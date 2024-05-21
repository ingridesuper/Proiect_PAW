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
                        clientAbonament.DataEnd = dataReader.GetDateTime(dataReader.GetOrdinal("DataEnd"));
                        

                        data.Add(clientAbonament);
                    }

                }

                conn.Close();
            }

            return data;
        }

        public bool ClientExists(int clientId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM client WHERE id = :clientId";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        //nu au neaparat ce cauta aici, pot fi intr-un script general ie n au treaba cu acest repo in sine
        public bool TipAbonamentExists(int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM tipabonament WHERE id = :abonamentId";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("abonamentId", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool ClientTipAbonamentExists(int clientId, int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM clientabonament WHERE clientid = :clientId AND tipabonamentid = :abonamentId";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    cmd.Parameters.Add("abonamentId", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void AddClientTipAbonament(ClientAbonament clientabonament) //de adaugat eroare in caz ca end data e mai mica decat start data
        {
            string sql = "INSERT INTO clientabonament (clientid, tipabonamentid, datastart, dataend, discount) VALUES (:clientid, :tipabonamentid, :datastart, :dataend, :discount)";

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("clientid", clientabonament.ClientId));
                    cmd.Parameters.Add(new OracleParameter("tipabonamentid", clientabonament.TipAbonamentId));

                    // Asigură-te că formatul datei este corect
                    cmd.Parameters.Add(new OracleParameter("datastart", OracleDbType.Date)).Value = clientabonament.DataStart;
                    cmd.Parameters.Add(new OracleParameter("dataend", OracleDbType.Date)).Value = clientabonament.DataEnd;

                    // Setează discount-ul corect
                    cmd.Parameters.Add(new OracleParameter("discount", OracleDbType.Double)).Value = (object)clientabonament.Discount ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}

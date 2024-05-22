using _2_1058_PISLARU_INGRID.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

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
                        

                        data.Add(clientAbonament);
                    }

                }

                conn.Close();
            }

            return data;
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

        public bool ClientulAreAbonament(int clientId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM clientabonament WHERE clientid = :clientId";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool SuntClientiCuAcestAbonament(int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM clientabonament WHERE tipabonamentid = :abonament";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("abonament", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void AddClientTipAbonament(ClientAbonament clientabonament) 
        {
            string sql = "INSERT INTO clientabonament (clientid, tipabonamentid, datastart, discount) VALUES (:clientid, :tipabonamentid, :datastart, :discount)";

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("clientid", clientabonament.ClientId));
                    cmd.Parameters.Add(new OracleParameter("tipabonamentid", clientabonament.TipAbonamentId));

                    cmd.Parameters.Add(new OracleParameter("datastart", OracleDbType.Date)).Value = clientabonament.DataStart;

                    cmd.Parameters.Add(new OracleParameter("discount", OracleDbType.Double)).Value = (object)clientabonament.Discount ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClientAbonament(ClientAbonament clientAbonament)
        {
            string sql = $"delete from clientabonament where clientid=:client and tipabonamentid=:abonament";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("client", clientAbonament.ClientId));
                    cmd.Parameters.Add(new OracleParameter("abonament", clientAbonament.TipAbonamentId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditClientAbonament(int clientId, int tipAbonamentId, double? discount,DateTime dataStart)
        {
            var sql = $"update clientabonament set discount=:discount, dataStart=:dataStart where clientId=:clientId and tipabonamentId=:tipAbonamentId";
            using(OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                using(OracleCommand cmd = new OracleCommand( sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("discount", discount));
                    cmd.Parameters.Add(new OracleParameter("dataStart", dataStart));
                    cmd.Parameters.Add(new OracleParameter("clientId", clientId));
                    cmd.Parameters.Add(new OracleParameter("tipAbonamentId", tipAbonamentId));
                    cmd.ExecuteNonQuery ();

                }
                conn.Close();
            }
        }

        //returneaza true daca clientul platii plata era abonat la abonamentul platii la data de duedate
        public bool ClientulEraAbonatLaDataDe(Plata plata, DateTime dueDate)
        {
            var sql = "select DataStart from clientabonament where clientid = :clientId and tipabonamentid = :tipAbonamentId";
            DateTime dataStart;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("clientId", plata.ClientId));
                    cmd.Parameters.Add(new OracleParameter("tipAbonamentId", plata.TipAbonamentId));

                    using (OracleDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read()) 
                        {
                            dataStart = dataReader.GetDateTime(dataReader.GetOrdinal("DataStart"));
                        }
                        else //deja am verificat practic, deci nu se va ajunge pe ramura asta (daca o scoti nu mai e valid datastart)
                        {
                            throw new Exception("Nu s-au găsit înregistrări corespunzătoare în tabelul clientabonament.");
                        }
                    }
                }
            }
            return dataStart < dueDate;
        }


    }
}

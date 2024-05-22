using Oracle.ManagedDataAccess.Client;
using System;
using _2_1058_PISLARU_INGRID.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1058_PISLARU_INGRID.Repositories
{
    public class ClientRepository
    {

        public int GetTotalCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(*) FROM CLIENT";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }


        public int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM client";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    OracleDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        if (dataReader["max"] != DBNull.Value)
                        {
                            newId = int.Parse(dataReader["max"].ToString()) + 1;
                        }
                        else
                        {
                            newId = 1;
                        }
                    }
                }
            }

            return newId;
        }


        public int GetTotalCurrentClientsCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(DISTINCT c.id) FROM client c INNER JOIN clientabonament ca ON c.id = ca.clientid";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }

        public int GetTotalPastClientsCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(*) FROM client where id not in (select clientid from clientabonament)";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }

        public List<Client> FetchAllClients(int currentPage, int pageSize)
        {
            var data = new List<Client>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT * FROM CLIENT ORDER BY ID OFFSET :skip ROWS " +
                    $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client();
                        client.Id = int.Parse(dataReader["ID"].ToString());
                        client.Nume = dataReader["NUME"].ToString();
                        client.Email = dataReader["EMAIL"].ToString();

                        var telefon = dataReader["TELEFON"];
                        if (telefon != DBNull.Value)
                        {
                            client.Telefon = telefon.ToString();
                        }

                        data.Add(client);
                    }
                }

                conn.Close();
            }

            return data;
        }

        public List<Client> FetchCurrentClients(int currentPage, int pageSize)
        {
            var data = new List<Client>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT distinct c.* from client c inner join clientabonament ca on c.id=ca.clientid ORDER BY c.ID OFFSET :skip ROWS " +
                    $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client();
                        client.Id = int.Parse(dataReader["ID"].ToString());
                        client.Nume = dataReader["NUME"].ToString();
                        client.Email = dataReader["EMAIL"].ToString();

                        var telefon = dataReader["TELEFON"];
                        if (telefon != DBNull.Value)
                        {
                            client.Telefon = telefon.ToString();
                        }

                        data.Add(client);
                    }
                }

                conn.Close();
            }

            return data;
        }



        public List<Client> FetchPastClients(int currentPage, int pageSize)
        {
            var data = new List<Client>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT * from client where id not in (select clientid from clientabonament) order by id OFFSET :skip ROWS " + $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client();
                        client.Id = int.Parse(dataReader["ID"].ToString());
                        client.Nume = dataReader["NUME"].ToString();
                        client.Email = dataReader["EMAIL"].ToString();

                        var telefon = dataReader["TELEFON"];
                        if (telefon != DBNull.Value)
                        {
                            client.Telefon = telefon.ToString();
                        }

                        data.Add(client);
                    }
                }

                conn.Close();
            }

            return data;
        }

        public void AddClient(Client client)
        {
            string sql = $"INSERT INTO client(id, nume, email, telefon) VALUES ('{client.Id}', '{client.Nume}', '{client.Email}', '{client.Telefon}')";

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

        public void DeleteClient(Client client)
        {
            string sql = $"delete from client where id=:id";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", client.Id));
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void ModificaDateleClientului(int id, string nume, string telefon, string email)
        {
            string sql=$"update client set nume=:nume, telefon=:telefon, email=:email where id=:id";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("nume", nume));
                    cmd.Parameters.Add(new OracleParameter("telefon", telefon));
                    cmd.Parameters.Add(new OracleParameter("email", email));
                    cmd.Parameters.Add(new OracleParameter("id", id));
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
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
    }
}

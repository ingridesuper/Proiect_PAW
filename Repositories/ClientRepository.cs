﻿using Oracle.ManagedDataAccess.Client;
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

        public List<Client> FetchData(int currentPage, int pageSize)
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
    }
}

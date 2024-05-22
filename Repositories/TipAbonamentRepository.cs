using System;
using System.Collections.Generic;
using _2_1058_PISLARU_INGRID.Entities;
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

        public void DeleteTipAbonament(TipAbonament tipAbonament)
        {
            string sql = $"delete from tipabonament where id=:id";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", tipAbonament.Id));
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        //MAI TREBUIE SI SCHIMBATE TOATE PLATILE DACA PRETUL SE SCHIMBA
        public void EditTipAbonament(int id, string nume, double pret)
        {
            string sql = $"update tipabonament set nume=:numeNou, pret=:pretNou where id=:id";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("numeNou", nume));
                    cmd.Parameters.Add(new OracleParameter("pretNou", pret));
                    cmd.Parameters.Add(new OracleParameter("id", id));

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

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

        public int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM tipabonament";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    OracleDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        // verifica daca sunt valori în tabel
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
    }
}

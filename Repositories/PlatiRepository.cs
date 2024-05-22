using _2_1058_PISLARU_INGRID.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1058_PISLARU_INGRID.Repositories
{
    public class PlatiRepository
    {
        public int GetTotalCount()
        {
            int count;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var sql = "SELECT COUNT(*) FROM plata";
                using (var command = new OracleCommand(sql, conn))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }

                conn.Close();
            }

            return count;
        }


        public List<Plata> FetchAllPlati(int currentPage, int pageSize)
        {
            var data = new List<Plata>();

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                var skip = (currentPage - 1) * pageSize;
                var take = pageSize;

                string sql = $"SELECT * FROM plata ORDER BY clientid, tipabonamentid OFFSET :skip ROWS " +
                    $"FETCH NEXT :take ROWS ONLY";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("skip", OracleDbType.Int32).Value = skip;
                    cmd.Parameters.Add("take", OracleDbType.Int32).Value = take;

                    OracleDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Plata plata = new Plata();
                        plata.Id = int.Parse(dataReader["ID"].ToString());
                        plata.ClientId = int.Parse(dataReader["ClientId"].ToString());
                        plata.TipAbonamentId = int.Parse(dataReader["TipAbonamentId"].ToString());
                        plata.Statut =dataReader["Statut"].ToString();

                        var suma = dataReader["Suma"];
                        if (suma != DBNull.Value)
                        {
                            plata.Suma = double.Parse(suma.ToString());
                        }

                        var dueDate = dataReader["DueDate"];
                        plata.DueDate = dataReader.GetDateTime(dataReader.GetOrdinal("DueDate"));

                        data.Add(plata);

                    }

                }

                conn.Close();
            }

            return data;
        }

        public int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM plata";

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


        //cumva functioneaza si pentru cazurile in cale clientul sau abonamentul nu exista
        //de comasat cu cealalta met de la add clientabonament
        public bool ClientulAreAbonamentul (int clientId, int abonamentId)
        {
            string sql = "SELECT COUNT(*) FROM clientabonament WHERE clientid = :clientId and tipabonamentid=:abonamentId";
            using (OracleConnection conn=new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    cmd.Parameters.Add("abonamentId", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool ClientulAreDeExecutatPlati(int clientId, int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM plata WHERE clientid = :clientId and tipabonamentid=:tipabonament";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    cmd.Parameters.Add("tipabonament", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void AddPlata(Plata plata)
        {
            var sql = $"insert into plata(id, clientid, tipabonamentid, suma, duedate, statut) values (:id, :clientId, :tipAbonamentId, :suma, :dueDate, :statut)";

            using (OracleConnection conn=new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                using(OracleCommand cmd=new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", plata.Id));
                    cmd.Parameters.Add(new OracleParameter("clientId", plata.ClientId));
                    cmd.Parameters.Add(new OracleParameter("tipAbonamentId", plata.TipAbonamentId));
                    cmd.Parameters.Add(new OracleParameter("suma", plata.Suma));
                    cmd.Parameters.Add(new OracleParameter("dueDate", OracleDbType.Date)).Value = plata.DueDate;
                    cmd.Parameters.Add(new OracleParameter("statut", plata.Statut));
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void DeletePlata(Plata plata)
        {
            string sql = $"delete from plata where id=:plataId";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("plataId", plata.Id));
                    cmd.ExecuteNonQuery(); 
                }

                conn.Close();
            }
        }

        public void EditPlata(int id, DateTime dueDate, string statut)
        {
            var sql = "update plata set duedate=:dueDate, statut=:statut where id=:id";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("dueDate", OracleDbType.Date)).Value = dueDate;
                    cmd.Parameters.Add(new OracleParameter("statut", OracleDbType.Varchar2)).Value = statut;
                    cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = id;
                    cmd.ExecuteNonQuery(); 
                }
                conn.Close();
            }
        }

        public void RecalculeazaSuma(int tipAbonamentId, double pretNou)
        {
            var sql = Constants.sqlUpdatePlatiDupaAbonament;
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("tipAbonamentId", tipAbonamentId));
                    cmd.Parameters.Add(new OracleParameter("pretNou", pretNou));
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void RecalculeazaSumaPentruDiscountSchimbat(int clientId, int tipAbonamentId, double? discount) 
        {
            //actualizare toate platile pe care le are perechea asta
            var sql = "update plata set suma = (select (1 - nvl(:discount, 0) / 100) * pret from tipabonament where id = :tipAbonamentId)  where clientid=:clientId and tipabonamentid=:tipAbonamentId";
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("discount", discount));
                    cmd.Parameters.Add(new OracleParameter("tipAbonamentId", tipAbonamentId));
                    cmd.Parameters.Add(new OracleParameter("clientId", clientId));
                    
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        
    }
}

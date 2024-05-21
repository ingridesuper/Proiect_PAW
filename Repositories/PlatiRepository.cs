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
                    cmd.ExecuteNonQuery(); //de verificat ca nu s plati asociate
                }

                conn.Close();
            }
        }
    }
}

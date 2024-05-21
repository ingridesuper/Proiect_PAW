namespace _2_1058_PISLARU_INGRID
{
    public class Constants
    {
        public const string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=193.226.34.57)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orclpdb.docker.internal)));User Id=PISLARUI_61;Password=studnou;";
        public const string sqlUpdatePlatiDupaAbonament = @"
            declare
                cursor c is select * from plata where tipabonamentid = :tipAbonamentId;
            begin
                for rec in c loop
                    update plata
                    set suma = (
                        select (1 - nvl(discount, 0) / 100) * :pretNou
                        from clientabonament
                        where clientid = rec.clientid
                          and tipabonamentid = rec.tipabonamentid
                    )
                    where id = rec.id;
                end loop;
            end;
            ";

    }
}

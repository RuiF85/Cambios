
namespace Cambios.Servicos
{
    using System.Data.SQLite;
    using Cambios.Modelos;

    public class DataService
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private DialogService dialogService;

        public DataService()
        {
            dialogService = new DialogService();

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            var path = @"Data\Rates.sqlite";

            try
            {
                connection = new SQLiteConnection("DataSource=" + path);
                connection.Open();

                string sqlcommand = "create table if not exists rates(RateId int, Code varchar(5)," +
                    " TaxRate real, Name varchar(250))";
                command = new SQLiteCommand(sqlcommand, connection);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        public void Savedata(List<Rate> Rates)
        {
            try
            {
                foreach (var rate in Rates)
                {
                    string sql = string.Format("insert into Rates (RateId, Code, TaxRate, Name) values({0},'{1}','{2}','{3}')",
                        rate.RateId, rate.Code, rate.TaxRate, rate.Name);

                    command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        public List<Rate> GetData()
        {
            List<Rate> rates = new List<Rate>();

            try
            {
                string sql = "select RateId, Code, TaxRate, Name from Rates";

                command = new SQLiteCommand(@sql, connection);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rates.Add(new Rate
                    {
                        RateId = Convert.ToInt32( reader["RateId"]),
                        Code = Convert.ToString(reader["code"]),
                        Name = Convert.ToString(reader["name"]),
                        TaxRate = Convert.ToDouble(reader["TaxRate"]),
                    });
                }
                connection.Close();

                return rates;
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erros", e.Message);
                return null;
            }

        }

        public void DeleteData()
        {
            try
            {
                string sql = "delete from Rates";

                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }
    }
}

using data_04_03_25.Source.LocalDB;
using Microsoft.Data.SqlClient;
using System.Text;

namespace console_04_03_25
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            try
            {
                string connectionString = "Data Source=DESKTOP-F044K8I\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True;Trust Server Certificate=True";
                SqlDataProvider dataProvider = new(connectionString);
                Console.Write("Connection is open: ");
                Console.WriteLine(dataProvider.IsConnectionOpen());
                //Console.WriteLine("Executing query...");
                //dataProvider.VoidExecute("DROP DATABASE TestDB");
                //Console.WriteLine("Query executed successfully.");
                Console.WriteLine("Executing query...");
                dataProvider.VoidExecute("USE Students");
                string? query;
                Console.Write("Enter query: ");
                query = Console.ReadLine();
                Dictionary<int, List<string?>> result = dataProvider.ReaderExecute(query);
                foreach (var item in result)
                {
                    foreach (var value in item.Value)
                    {
                        Console.Write($" {value} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}

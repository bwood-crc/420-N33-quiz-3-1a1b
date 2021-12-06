using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3_1A1B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The sum is " + GetScalerSales("sum"));
            Console.WriteLine("The average is " + GetScalerSales("average"));

            Console.Write("Enter the target level to find jobs in range >");
            int level = int.Parse(Console.ReadLine());

            GetJobs(level).ForEach(j => Console.WriteLine(j));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int GetScalerSales(string type)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=pubs;Integrated Security=True;"))
            {
                string query = string.Empty;

                if (type.Equals("sum"))
                    query = "SELECT sum(qty) from sales;";

                if (type.Equals("average"))
                    query = "SELECT avg(qty) from sales;";

                int sumOfqty = 0;

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    sumOfqty = (int)command.ExecuteScalar();
                }

                return sumOfqty;
            }
        }

        static List<Job> GetJobs(int level)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=pubs;Integrated Security=True;"))
            {
                List<Job> jobs = new List<Job>();

                string query = "SELECT * from jobs where @level >= min_lvl and @level <= max_lvl;";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@level", level);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Job newJob = new Job(
                            (int)reader["job_id"], 
                            (string)reader["job_desc"],
                            (int) reader["min_lvl"], 
                            (int)reader["max_lvl"]);

                        jobs.Add(newJob);
                    }
                }

                return jobs;
            }
        }
    }
}

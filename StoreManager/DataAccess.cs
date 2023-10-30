using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace StoreManager
{
    class DataAccess
    {
        public static int c = 0;

        public static int insertData(string connectionString)
        {
            int CategoryId, Price;
            string name, img, Description, addmore="y";

           

            while (addmore == "y")
            {
                Console.WriteLine("insert CategoryId");
                CategoryId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("insert Price");
                Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("insert name");
                name = Console.ReadLine();
                Console.WriteLine("insert img");
                img = Console.ReadLine();
                Console.WriteLine("insert Description");
                Description = Console.ReadLine();



                string query = "INSERT INTO Product(CategoryId,Price,name,img,Description)" +
                "VALUES(@CategoryId,@Price,@name,@img,@Description)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {

                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar, 50).Value = img;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = Description;
                    cn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    c++;
                    cn.Close();
                    Console.WriteLine("add more");
                    addmore = Console.ReadLine();


                }


            }
            return 0;

        }






        internal static void readSata(string connectionString)
        {
            string queryString = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                    };
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }
                Console.ReadLine();
            }

        }
        
        

    }

}
       
       





    


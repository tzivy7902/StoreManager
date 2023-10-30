using StoreManager;
using System;

namespace ManagerStore
{
    class Program
    {
        static void Main(String[] args)
        {
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=StoreDatabase;Integrated Security=True";
        
            DataAccess da = new DataAccess();
           DataAccess.insertData(connectionString);
            Console.WriteLine(DataAccess.c + "row effected");
            DataAccess.readSata(connectionString);
          
        }

    }
 


}

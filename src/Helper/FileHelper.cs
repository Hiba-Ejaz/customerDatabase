using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDatabaseManagement;

namespace src.Helper;

    public class FileHelper
    {
      public static List<Customer> GetAllCustomers(){
        List<Customer> customers=new List<Customer>();
         try{
            FileInfo fileInfo = new FileInfo("src/customers.csv");
            using(StreamReader reader=fileInfo.OpenText()){
                Console.WriteLine("data from file");
                string line;
                while((line=reader.ReadLine())!=null){
                string[] customerArray=line.Split(",");
                        string[] customerData = line.Split(',');
                        int id = int.Parse(customerData[0]);
                        string firstName = customerData[1];
                        string lastName = customerData[2];
                        string email = customerData[3];
                        string address = customerData[4];

                Customer customer = new Customer{ Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Address = address};
                 customers.Add(customer);
            }
            }
            
         }  
         catch{
            Console.WriteLine("file not found");
         }
         return customers; 
      } 
     public static void WriteAllCustomers(List<Customer> customers){
            try{
                FileInfo fileInfo = new FileInfo("src/customers.csv");
                 using (StreamWriter writer = fileInfo.CreateText())
                 {
                  foreach(Customer customer in customers){
                   string line = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
                   writer.WriteLine(line);
                  }

                }
             }
     catch{
Console.WriteLine("file not found for writing data to");
     } 
    }
    }

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
            //FileInfo fileInfo = new FileInfo("src/customers.csv");
          //  using(StreamReader reader=fileInfo.OpenText()){
            using(StreamReader reader=new StreamReader("src/customers.csv")){
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
         catch(Exception e){
            Console.WriteLine(ExceptionHandler.FetchDataException(e.Message));
         }
         return customers; 
      } 
     public static void WriteAllCustomers(List<Customer> customers){
            try{
                //FileInfo fileInfo = new FileInfo("src/customers.csv");
                // using (StreamWriter writer = fileInfo.CreateText())
                using(StreamWriter writer=new StreamWriter("src/customers.csv"))
                 {
                  foreach(Customer customer in customers){
                   string line = $"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}";
                   writer.WriteLine(line);
                  }

                }
             }
        catch(Exception e){
            Console.WriteLine(ExceptionHandler.UpdateDataException(e.Message));
         }
    }
    }

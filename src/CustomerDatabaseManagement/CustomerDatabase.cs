namespace CustomerDatabaseManagement;
using System;
using System.Collections.Generic;
using src.Helper;

// Create CustomerDatabase class: This class should contain the data structure used 
// to store customer information, such as a collection of customers. 
// It should also contain methods for adding, reading, updating, deleting.
//  Extra features:
// Email should be unique in the database.
// Implement a feature to search customers by their ID
// Implement an undo and redo feature which allows users to undo 
// their last action or redo an action that they have undone
    public class CustomerDatabase
    {        public CustomerDatabase()
        {
            GetAllCustomers();
        }

        public void GetAllCustomers()
        {
            customers=FileHelper.GetAllCustomers();
        }

        public void WriteAllCustomers()
        {
            FileHelper.WriteAllCustomers(customers);
        }
        List<Customer> customers=new List<Customer>();
        
        Stack<Customer> customerStack=new Stack<Customer>();
        private string lastOperation;
       private int indexOfRemovedCustomer;
       private int indexOfUpdatedCustomer;
        private Customer updatedCustomer;
        public void AddCustomer(Customer customer)
        {
           bool emailExists = customers.Exists(c => c.Email == customer.Email);
             if (emailExists)
         {
        throw new InvalidOperationException("Customer with the same email already exists.");
             }
          else
         {
             customers.Add(customer);
             customerStack.Push(customer);
             lastOperation="Add";
             
             
         }
        }
        public void ReadCustomer(Customer customer)
        {
        Customer readCustomer = customers.Find(c => c.Id == customer.Id);
        if (readCustomer != null)
        {
         Console.WriteLine($"customer id {readCustomer.Id} has name {readCustomer.FirstName} {readCustomer.LastName} address {readCustomer.Address} email {readCustomer.Email}");
        }  
         else{
            Console.WriteLine("Customer not found. Unable to read.");
       // throw new InvalidOperationException("Customer not found. Unable to read.");
         }  
         
        }
         public void UpdateCustomer(Customer customer)
        {
        indexOfUpdatedCustomer=customers.FindIndex(c => c.Id == customer.Id);
        if (indexOfUpdatedCustomer >= 0)
        {
        customerStack.Push(customers[indexOfUpdatedCustomer]);   
        customers[indexOfUpdatedCustomer]=customer;    
        lastOperation="Update";
        }  
         else{
             Console.WriteLine("Customer not found. Unable to update.");
      // throw new InvalidOperationException("Customer not found. Unable to update.");
         }    
        }
         public void DeleteCustomer(Customer customer)
        {
         int index = customers.FindIndex(c => c.Id == customer.Id);

        if (index >= 0)
        {
        Customer deletedCustomer = customers[index];
        customers.RemoveAt(index);
         customerStack.Push(deletedCustomer);
        indexOfRemovedCustomer = index;
        lastOperation = "Delete";
        Console.WriteLine("Customer removed");
         }
        //     /////// Find didnot work in the above scenerio as it is refernce type
        //  Customer deleteCustomer = customers.Find(c => c.Id == customer.Id);
        //  indexOfRemovedCustomer=customers.FindIndex(c => c.Id == customer.Id);
        // if (deleteCustomer != null)
        // {
        // customers.Remove(customer);
        // Console.WriteLine("customeeer removed");
        // lastOperation="Delete";
        // }   
        else{
           Console.WriteLine("Customer not found. Unable to delete.");
       //  throw new InvalidOperationException("Customer not found. Unable to delete.");;
        }
        }
        public void SearchCustomerById(int id)
        {
         Customer foundCustomer = customers.Find(c => c.Id == id);
        if (foundCustomer != null)
        {
               Console.WriteLine($"customer id {foundCustomer.Id} has name {foundCustomer.FirstName} {foundCustomer.LastName} address {foundCustomer.Address} email {foundCustomer.Email}");
        }
    }
    public void Undo()
    {
        Console.WriteLine("Undo-last operation done was "+lastOperation);
        if(lastOperation=="Add"){
            //customerStack.Push(customers[customers.Count-1]);
            customers.RemoveAt(customers.Count-1);
        }
        else if(lastOperation=="Delete"){
           // customerStack.Push(customers[indexOfRemovedCustomer]);
            Customer deletedCustomer=customerStack.Pop();
            Console.WriteLine("index of removed Customer"+indexOfRemovedCustomer+"Deleted customer was ");
            ReadCustomer(deletedCustomer);
             customers.Insert(indexOfRemovedCustomer, deletedCustomer);
        }
        else if(lastOperation=="Update"){
            //customerStack.Push(customers[indexOfUpdatedCustomer]);
            updatedCustomer=customers[indexOfUpdatedCustomer];
            customers[indexOfUpdatedCustomer]=customerStack.Pop();
        }
    }       
        public void Redo()
    {
        Console.WriteLine("Redo-last operation done was "+lastOperation);
        if(lastOperation=="Add"){
            customers.Add(customerStack.Pop());
        }
        else if(lastOperation=="Delete"){
            customers.RemoveAt(indexOfRemovedCustomer);
            customerStack.Pop();
        }
        else if(lastOperation=="Update"){
            customerStack.Push(customers[indexOfUpdatedCustomer]);
            customers[indexOfUpdatedCustomer]=updatedCustomer;
        }
    }
    }

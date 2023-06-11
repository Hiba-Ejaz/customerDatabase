﻿using CustomerDatabaseManagement;
internal class Program
{
    private static void Main(string[] args)
    {
            CustomerDatabase customerDb = new CustomerDatabase();
            Customer customer1 = new Customer
            {
                Id = 3,
                FirstName = "Hiba",
                LastName = "Ejaz",
                Email = "hiba@example.com",
                Address = "helsinki"
            };
            Customer customer2 = new Customer
            {
                Id = 2,
                FirstName = "Faheem",
                LastName = "Ijaz",
                Email = "faheem@example.com",
                Address = "Espoo"
            };
            try
            {
                customerDb.AddCustomer(customer1);
                customerDb.AddCustomer(customer2);
                Console.WriteLine("Customers added successfully.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error adding customer: " + e.Message);
            }
            Console.WriteLine("Searching customer by ID...");
            customerDb.SearchCustomerById(2);
            Customer updatedCustomer = new Customer
            {
                Id = 2,
                FirstName = "Faheem",
                LastName = "Ijaz",
                Email = "faheem.ijaz@example.com",
                Address = "456 xyz Helsinki"
            };
            try
            {
                customerDb.UpdateCustomer(updatedCustomer);
                Console.WriteLine("Customer updated successfully.");
                 customerDb.SearchCustomerById(2);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error updating customer: " + e.Message);
            }
            try
            {
                customerDb.DeleteCustomer(customer1);
                Console.WriteLine("Customer deleted successfully.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error deleting customer: " + e.Message);
            }
            Console.WriteLine("trying to retrieve deleted customer");
            // customerDb.ReadCustomer(customer1);

        Console.WriteLine("Performing undo operation...");
        customerDb.Undo();
        Console.WriteLine("After Undo:");
        Console.WriteLine("Result:");
        // customerDb.ReadCustomer(customer1);
        Console.WriteLine("Performing redo operation...");
        customerDb.Redo();
        Console.WriteLine("After Redo:");
        Console.WriteLine("Result:");
        // customerDb.ReadCustomer(customer1);  
        customerDb.WriteAllCustomers();    
    }
    }


  

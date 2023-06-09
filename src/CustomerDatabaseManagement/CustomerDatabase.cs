namespace CustomerDatabaseManagement;

// Create CustomerDatabase class: This class should contain the data structure used 
// to store customer information, such as a collection of customers. 
// It should also contain methods for adding, reading, updating, deleting.
//  Extra features:
// Email should be unique in the database.
// Implement a feature to search customers by their ID
// Implement an undo and redo feature which allows users to undo 
// their last action or redo an action that they have undone
    public class CustomerDatabase
    {
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
        public bool ReadCustomer(Customer customer)
        {
         Customer readCustomer = customers.Find(c => c.Id == customer.Id);
        if (readCustomer != null)
        {
         Console.WriteLine($"customer id {readCustomer.Id} has name {readCustomer.FirstName} {readCustomer.LastName} address {readCustomer.Address} email {readCustomer.Email}");
        return true;
        }  
         else{
        return false;
         }  
         
        }
         public void UpdateCustomer(Customer customer)
        {
        indexOfUpdatedCustomer=customers.FindIndex(c => c.Id == customer.Id);
        if (indexOfUpdatedCustomer != null)
        {
        customerStack.Push(customers[indexOfUpdatedCustomer]);   
        customers[indexOfUpdatedCustomer]=customer;    
        lastOperation="Update";
        }  
         else{
       throw new InvalidOperationException("Customer not found. Unable to update.");
         }    
        }
         public void DeleteCustomer(Customer customer)
        {
         Customer deleteCustomer = customers.Find(c => c.Id == customer.Id);
         indexOfRemovedCustomer=customers.FindIndex(c => c.Id == customer.Id);
        if (deleteCustomer != null)
        {
        customers.Remove(customer);
        lastOperation="Delete";
        }  
        
        else{
         throw new InvalidOperationException("Customer not found. Unable to delete.");;
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
        if(lastOperation=="Add"){
            //customerStack.Push(customers[customers.Count-1]);
            customers.RemoveAt(customers.Count-1);
        }
        else if(lastOperation=="Delete"){
            customerStack.Push(customers[indexOfRemovedCustomer]);
             customers.Insert(indexOfRemovedCustomer, customerStack.Pop());
        }
        else if(lastOperation=="Update"){
            //customerStack.Push(customers[indexOfUpdatedCustomer]);
            updatedCustomer=customers[indexOfUpdatedCustomer];
            customers[indexOfUpdatedCustomer]=customerStack.Pop();
        }
    }       
    
    public void Redo()
    {
        if(lastOperation=="Add"){
            customers.Add(customerStack.Pop());
        }
        else if(lastOperation=="Delete"){
            customers.RemoveAt(indexOfRemovedCustomer);
            customerStack.Pop();
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

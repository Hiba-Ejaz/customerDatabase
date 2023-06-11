using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDatabaseManagement;

namespace src.Helper;

    public class ExceptionHandler:Exception
    {
        private string _message;
        private int _errorCode;
        public ExceptionHandler(string message)
        {
            _message = message;
           
        }
        public static ExceptionHandler FileException(string? message)
        {
            return new ExceptionHandler(message ?? "There is error happened when processing the file");
        }
        public static ExceptionHandler FetchDataException(string? message)
        {
            return new ExceptionHandler(message ?? "Cannot read data from the file");
        }
        public static ExceptionHandler UpdateDataException(string? message)
        {
            return new ExceptionHandler(message ?? "Cannot update data in the file");
        } 
         public static ExceptionHandler DeleteCustomerException(string? message)
        {
            return new ExceptionHandler(message );
        }
        public static ExceptionHandler IndexNotFoundException(string? message)
        {
            return new ExceptionHandler(message );
        }
         public static ExceptionHandler NullReferenceException(string? message){
             return new ExceptionHandler(message );
         }
          public static ExceptionHandler InvalidOperationException(string? message){
             return new ExceptionHandler(message );
         }
         
    }

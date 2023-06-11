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
        public ExceptionHandler(string message, int errorCode)
        {
            _message = message;
            _errorCode = errorCode;
        }
        public static ExceptionHandler FileException(string? message)
        {
            return new ExceptionHandler(message ?? "There is error happened when processing the file", 500);
        }
        public static ExceptionHandler FetchDataException(string? message)
        {
            return new ExceptionHandler(message ?? "Cannot read data from the file", 500);
        }
        public static ExceptionHandler UpdateDataException(string? message)
        {
            return new ExceptionHandler(message ?? "Cannot update data in the file", 500);
        } 
    }

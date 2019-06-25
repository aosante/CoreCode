
using System;
using CoreCode.Entities.POJO;

namespace CoreCode.Exceptions
{
    public class BussinessException : Exception
    {
        public int ExceptionId;
        public ApplicationMessage AppMessage { get; set; }
       
        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId; 
        }
    }
}

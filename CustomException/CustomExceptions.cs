using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPublisher.CustomException
{
    public class JsonHelperException : Exception
    {
        public JsonHelperException(string message) : base(message) { 
        public JsonHelperException(string message, Exception innerException) : base(message, innerException) { }
    }

    
    public class FileHelperException : Exception
    {
        public FileHelperException(string message) : base(message) { }
        public FileHelperException(string message, Exception innerException) : base(message, innerException) { }
    }
}

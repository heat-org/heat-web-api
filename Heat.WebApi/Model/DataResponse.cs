using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heat
{
    public class DataResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public DataResponse(T content, bool success = false, string message = "")
        {
            Data = content;
            Success = success;
            Message = message;
        }
    }
}
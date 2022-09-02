using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Domain.Common
{
    public class Response<T>
    {
        public T payload { get; set; } = default(T);
        public bool success { get; set; }
        public string description { get; set; }
    }
}

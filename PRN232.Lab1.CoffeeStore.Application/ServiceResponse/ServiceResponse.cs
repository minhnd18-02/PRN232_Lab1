using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.ServiceResponse
{
    public class ServiceResponse<T>
    {
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }
        public bool Success { get; set; } = false;
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; } = null;
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; set; } = null;

        //public string? Hint { get; set; } = null;

        //public double? PriceTotal { get; set; } = null;
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? ErrorMessages { get; set; } = null;
    }
}

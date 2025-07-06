using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantAPI.Application.Commons.Responses
{
    public record ServiceResponse<T> (T Data, bool isSuccess, string Message = null!)
    {
        public static ServiceResponse<T> Success(T? data, string message = null!)
        {
            return new ServiceResponse<T>(data!, true, message);
        }
        public static ServiceResponse<T> Failure(string message)
        {
            return new ServiceResponse<T>(default!, false, message);
        }
    }
}

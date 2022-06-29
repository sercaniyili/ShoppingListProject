using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Domain.Common.Response
{
    public class BaseResponse
    {
        public BaseResponse(string message, bool ısSuccess)
        {
            Message = message;
            IsSuccess = ısSuccess;
        }
        public String Message { get; set; }
        public bool IsSuccess { get; set; } 
    }
}

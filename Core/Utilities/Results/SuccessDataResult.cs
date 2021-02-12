using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data, true, message)
        {
            //data and message output
        }
        public SuccessDataResult(T data) : base(data, true)
        {
            //only data output
        }
        public SuccessDataResult(string message) : base(default, true, message)
        {
            //only message output
        }
        public SuccessDataResult() : base(default, true)
        {
            //no output
        }
    }
}

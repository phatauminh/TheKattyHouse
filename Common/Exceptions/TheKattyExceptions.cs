using Common.Messages;
using System;

namespace Common.Exceptions
{
    public class TheKattyExceptions : Exception
    {
        public FaultResponse FaultResponse { get; private set; }

        public TheKattyExceptions() { }

        public TheKattyExceptions(FaultResponse faultResponse)
               : base(faultResponse.ToString())
        {
            FaultResponse = faultResponse;
        }


        public TheKattyExceptions(FaultResponse faultResponse, Exception innerException)
               : base(faultResponse.ToString(), innerException)
        {
            FaultResponse = faultResponse;
        }

    }
}

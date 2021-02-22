using System;

namespace ThreadFormsHW1
{
    public class Response
    {
        public int Number { get; private set; }
        public Response(int n) =>  Number = n;
    }
}

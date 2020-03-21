using System;

namespace KMA.ProgrammingInCSharp2020.Lab4.Exceptions
{
    internal class InvalidDateFilterBordersException : Exception
    {
            public InvalidDateFilterBordersException(string message)
            : base(message)
            {
            }

            public InvalidDateFilterBordersException(string message, Exception inner)
            : base(message, inner)
            {
            }
        
    }
}

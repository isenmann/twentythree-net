using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet.Exceptions
{
    /// <summary>
    /// Error: 96: Invalid signature
    /// </summary>
    /// <remarks>
    /// The passed signature was invalid.
    /// </remarks>
    public class InvalidSignatureException : TwentyThreeApiException
    {
        internal InvalidSignatureException(string message)
            : base(96, message)
        {
        }
    }
}

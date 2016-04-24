using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet.Exceptions
{
    /// <summary>
    /// Error: 98: Login failed / Invalid auth token
    /// </summary>
    /// <remarks>
    /// The login details or auth token passed were invalid.
    /// </remarks>
    public class LoginFailedInvalidTokenException : TwentyThreeApiException
    {
        internal LoginFailedInvalidTokenException(string message)
            : base(98, message)
        {
        }
    }
}

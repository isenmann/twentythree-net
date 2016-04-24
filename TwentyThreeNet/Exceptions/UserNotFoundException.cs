using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet.Exceptions
{
    /// <summary>
    /// No user with the user ID supplied to the method could be found.
    /// </summary>
    /// <remarks>
    /// This could mean the user does not exist, or that you do not have permission to view the user.
    /// </remarks>
    public class UserNotFoundException : TwentyThreeApiException
    {
        internal UserNotFoundException(int code, string message)
            : base(code, message)
        {
        }
    }
}

using System;

using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet.Exceptions
{
    /// <summary>
    /// A user was included in a description or comment which Flickr rejected.
    /// </summary>
    public sealed class BadUrlFoundException : TwentyThreeApiException
    {
        internal BadUrlFoundException(string message)
            : base(111, message)
        {
        }

    }
}

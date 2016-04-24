using System;

namespace TwentyThreeNet
{
    /// <summary>
    /// Generic Flickr.Net Exception.
    /// </summary>
    public class TwentyThreeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeException"/> class.
        /// </summary>
        public TwentyThreeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public TwentyThreeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public TwentyThreeException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

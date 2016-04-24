using System;

namespace TwentyThreeNet
{
    /// <summary>
    /// Exception thrown when a communication error occurs with a web call.
    /// </summary>
    [Serializable]
    public class TwentyThreeWebException : TwentyThreeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeWebException"/> class.
        /// </summary>
        public TwentyThreeWebException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeWebException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public TwentyThreeWebException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeWebException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public TwentyThreeWebException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}

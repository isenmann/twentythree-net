using System;
using System.Security.Permissions;

namespace TwentyThreeNet
{
    /// <summary>
    /// Exception thrown when the Flickr API returned a specifi error code.
    /// </summary>
    [Serializable]
    public class TwentyThreeApiException : TwentyThreeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeApiException"/> class with a specific code and message.
        /// </summary>
        /// <remarks>
        /// The code and message returned from Flickr are used to generate the exceptions message.
        /// </remarks>
        /// <param name="code">The error code supplied by Flickr.</param>
        /// <param name="message">The error message supplied by Flickr.</param>
        public TwentyThreeApiException(int code, string message) : base()
        {
            Code = code;
            OriginalMessage = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeApiException"/> class.
        /// </summary>
        public TwentyThreeApiException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public TwentyThreeApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyThreeApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public TwentyThreeApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        /// <summary>
        /// Get the code of the Flickr error.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets the orignal message returned by Flickr.
        /// </summary>
        public string OriginalMessage { get; set; }
        
        /// <summary>
        /// Overrides the message to return custom error message.
        /// </summary>
        public override string Message
        {
            get
            {
                return OriginalMessage + " (" + Code + ")";
            }
        }

    }
}

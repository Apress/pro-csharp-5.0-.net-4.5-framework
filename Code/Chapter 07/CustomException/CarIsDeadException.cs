using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    #region Take One
    // This custom exception describes the details of the car-is-dead condition.
    /*
    public class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException( string message,
          string cause, DateTime time )
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // Override the Exception.Message property.
        public override string Message
        {
            get
            {
                return string.Format("Car Error Message: {0}", messageDetails);
            }
        }
    }
    */
    #endregion

    #region Take Two
    /*
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }

        // Feed message to parent constructor.
        public CarIsDeadException( string message, string cause, DateTime time )
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
    */
    #endregion

    #region Take Three
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }

        // Feed message to parent constructor.
        public CarIsDeadException( string message, string cause, DateTime time )
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public CarIsDeadException( string message ) : base(message) { }
        public CarIsDeadException( string message,
                                  System.Exception inner )
            : base(message, inner) { }
        protected CarIsDeadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context )
            : base(info, context) { }

        // Any additional custom properties, constructors and data members...
    }
    #endregion
}

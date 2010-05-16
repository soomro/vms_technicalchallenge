using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Exceptions
{
    /// <summary>
    /// This class is used to pass validation results to the user. 
    /// </summary>
    public class VMSException : Exception
    {
        public VMSException(string Message)
            : base(Message)
        {
            Messages.Add(Message);
        }
        /// <summary>
        /// Contains different messages for different errors.
        /// </summary>
        public IList<string> Messages = new List<string>();

        public VMSException(IList<string> Messages)
            : base("")
        {
            foreach (var message in Messages)
                this.Messages.Add(message);
        }

        public VMSException()
        {
        }

        public void AddMessage(string msg)
        {
            this.Messages.Add(msg);
        }
    }
}
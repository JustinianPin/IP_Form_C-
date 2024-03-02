using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_IP
{
    public class TrigException : Exception
    {
        #region Fields
        private double _argument;
        private string _message;
        #endregion
        #region Properties
        public string Message
        {
            get
            {
                return _message; 
            }
        }
        #endregion
        #region Methods
        public TrigException(string message, double argument) : base(message) 
        {
            _message = message;
            _argument = argument;
        }
        #endregion
    }
}


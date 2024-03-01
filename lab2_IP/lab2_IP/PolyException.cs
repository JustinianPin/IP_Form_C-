using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_IP
{
    public class PolyException : Exception
    {
        #region Fields
        private string _message;
        private double _x0;
        private double _x1;
        private double _x2;
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
        public PolyException(string message, double x2, double x1, double x0) : base(message) 
        {
            _message = message;
            _x2 = x2;
            _x1 = x1;
            _x0 = x0;  
        }
        #endregion
    }
}

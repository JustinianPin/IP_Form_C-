using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_IP
{
    public class TrigEquation : IEquation
    {
        #region Fields
        private double _arg = 0.5;
        private TrigonometricFunction _function = TrigonometricFunction.Sin;
        #endregion

        #region Methods
        public TrigEquation(TrigonometricFunction tf, double argument)
        {
            _function = tf;
            _arg = argument; //argumentul e rezultatul, deci noi facem operatia inversa
        }
        public string Solve()
        {
            string solutia;
            double sol = 0;
            if((_function == TrigonometricFunction.Arcsin || _function == TrigonometricFunction.Arccos) && (_arg > 1 || _arg < -1))
            {
                throw new TrigException("Argument invalid", _arg);
            }
            switch (_function)
            {
                case TrigonometricFunction.Sin:
                    sol = Math.Asin(_arg);
                    break;
                case TrigonometricFunction.Cos:
                    sol = Math.Acos(_arg);
                    break;
                case TrigonometricFunction.Tan:
                    sol = Math.Atan(_arg);
                    break;
                case TrigonometricFunction.Arcsin:
                    sol = Math.Sin(_arg);
                    break;
                case TrigonometricFunction.Arccos:
                    sol = Math.Cos(_arg);
                    break;
                case TrigonometricFunction.Arctan:
                    sol = Math.Tan(_arg);
                    break;

            }
            solutia = "x= " + sol.ToString("0.00");
            return solutia;
        }
        #endregion
        #region Nested Types
        public enum TrigonometricFunction { Sin = 0, Cos = 1, Tan = 2, Arcsin = 3, Arccos = 4, Arctan = 5 };
        #endregion
    }
}

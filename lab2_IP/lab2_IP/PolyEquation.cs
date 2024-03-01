using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2_IP;

namespace lab2_IP
{
    public class PolyEquation : IEquation
    {
        #region Fields

        private EquationType _eqType = EquationType.Grad2;
        private double _x0 = 1;
        private double _x1 = 1;
        private double _x2 = 1;

        #endregion

        #region Methods
        public PolyEquation(double x2, double x1, double x0)
        {
            _x0 = x0;
            _x1 = x1;
            _x2 = x2;
            if(_x2 != 0) 
            {
                _eqType = EquationType.Grad2;
            }
            else
            {
                _eqType = EquationType.Grad1;
            }
        }
        public string Solve()
        {
            string solutia;
            double delta = _x1 * _x1 - 4 * _x2 * _x0;
            if (_x2 == 0 && _x1 == 0 && _x0 == 0)
            {
                throw new PolyException("O infinitate de solutii", _x2, _x1, _x0);
            }
            else if (_x2 == 0 && _x1 == 0 && _x0 != 0)
            {
                throw new PolyException("Nicio solutie", _x2, _x1, _x0);
            }
            else if (_eqType == EquationType.Grad1)
            {
                double sol = -_x0 / _x1;
                solutia = "x1 = " + sol.ToString("0.00");
            }
            else if (delta > 0)
            {
                double sqrtDelta = Math.Sqrt(delta);
                double sol1 = (-_x1 + sqrtDelta) / (2.0 * _x2);
                double sol2 = (-_x1 - sqrtDelta) / (2.0 * _x2);
                // soluții: sol1, sol2
                solutia = "x1 = " + sol1.ToString("0.00") + " x2 = " + sol2.ToString("0.00");
            }
            else if (delta == 0)
            {
                double sol = (-_x1) / (2.0 * _x2);
                // soluție: sol
                solutia = "x1 = x2 =" + sol.ToString("0.00");

            }
            else
            {
                double rsol = -_x1 / (2.0 * _x2);
                double isol = Math.Sqrt(-delta) / (2.0 * _x2);
                // soluții: rsol ± isol
                solutia = "x1 = " + rsol.ToString("0.00") + " + " + isol.ToString("0.00") + "i, x2 = " + rsol.ToString("0.00") + " - " + isol.ToString("0.00") + "i";
            }
            return solutia;
        }
        #endregion
        #region Nested Types
        public enum EquationType { Grad1 = 1, Grad2 = 2 };
        #endregion
    }
}

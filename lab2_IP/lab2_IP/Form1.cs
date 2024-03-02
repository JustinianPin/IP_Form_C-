using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lab2_IP.TrigEquation;
//using System.Math;

namespace lab2_IP
{
    public partial class FormEcuatii : Form
    {
        public FormEcuatii()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //DE AICI GESTIUONEZ CUM IA BUTOANELE: cu Checked (vizual...)
        private void radioButtonEcuatiePolinomiala_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEcuatiePolinomiala.Checked)
            {
                radioButtonEcuatieTrigonometrica.Checked = false;
            }
        }
        private void radioButtonEcuatieTrigonometrica_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEcuatieTrigonometrica.Checked)
            {
                radioButtonEcuatiePolinomiala.Checked = false;
            }
        }
        private void buttonDespre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Despre aplicatie");
        }

        private void buttonIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCalculeaza_Click(object sender, EventArgs e)
        {
            //// AICI TRATEZ SI EXCEPTIILE pentru ceea ce e scris in casuta, daca sunt numere valide.
            #region Declarare parametrii
            double x2, x1, x0, arg;
            TrigonometricFunction tf;
            IEquation eq = null;
            #endregion

            #region Colectare argumente
            x2 = Convert.ToDouble(textBoxX2.Text);
            x1 = Convert.ToDouble(textBoxX1.Text);
            x0 = Convert.ToDouble(textBoxX0.Text);
            arg = Convert.ToDouble(textBoxTrigonometric.Text);
            switch(comboBoxTrigonometric.Text)
            {
                case "sin(x)":
                    tf = TrigonometricFunction.Sin;
                    break;
                case "cos(x)":
                    tf = TrigonometricFunction.Cos;
                    break;
                case "tan(x)":
                    tf = TrigonometricFunction.Tan;
                    break;
                default:
                    tf = TrigonometricFunction.Sin;
                    break;
            }
            #endregion

            #region Alegere buton radio
            if (radioButtonEcuatiePolinomiala.Checked)
            {
                eq = new PolyEquation(x2, x1, x0);
            }
            else if (radioButtonEcuatieTrigonometrica.Checked)
            {
                eq = new TrigEquation(tf, arg);
            }
            #endregion
            #region Bloc try-catch
            try
            {
                textBoxSolutie.Text = eq.Solve();
            }
            catch (PolyException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (TrigException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception) //exceptii generale
            {
                MessageBox.Show("Introduceti caractere numerice!");
            }
            #endregion

            //  try + 3 catch: PolyExc, TrigExc, GenericExc: ex: a citi caract nenumerice


        }


    }

  

    


    
    

}

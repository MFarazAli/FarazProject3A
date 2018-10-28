using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarazAliProject3A
{
    


    public partial class frmDivision : Form
    {

        public class CustomException : Exception
        {
            public CustomException()
            {
            }

            public CustomException(string message)
                : base(message)
            {
            }

            public CustomException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public frmDivision()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal input1 = Convert.ToDecimal(txtInput1.Text);
                decimal input2 = Convert.ToDecimal(txtInput2.Text);

                if (input1 <= 1)
                    throw new CustomException("Input1 must be greater than 1");

                decimal result = input1 / input2;
                txtResult.Text = result.ToString("n");
            }

            catch(FormatException)
            {
                MessageBox.Show("Invalid numeric format. Please check all the entries.", "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Please enter smaller values.", "Entry Error");
            }

            catch (DivideByZeroException)
            {
                MessageBox.Show("You tried to divide by Zero. Please check the second entry.", "Entry Error");
            }

            catch (CustomException ce)
            {
                MessageBox.Show(ce.Message, "Custom Exception");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
           



            txtInput1.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInput1.Text = "";
            txtInput2.Text = "";
            txtResult.Text = "";

            txtInput1.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
        
}

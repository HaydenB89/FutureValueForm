using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValueForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) 
        {
            this.Close();
        }


        // creating a method to clear out Future Value when new data is  
        // being typed in any of the text boxes  vvvv
        private void ClearFutureValue(object sender, EventArgs e) 
        {
            txtFutureValue.Text = String.Empty;
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //adding exceptions w/try and catch
            try
            {

                decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                decimal yearlyInterestRate = Convert.ToDecimal(txtYearlyInterestRate.Text);
                int years = Convert.ToInt32(txtNumberOfYears.Text);

                int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                // this next method is a call to the main method for calculate button vvv
                decimal futureValue = CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);

                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
            }
            catch(FormatException)
            {
                MessageBox.Show(
                    "Invalid numeric format. Please check all values.",
                    "Entry Error");
            }
            catch(OverflowException)
            {
                MessageBox.Show(
                    "Overflow error. Please enter smaller values.",
                    "Entry Error");
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    ex.GetType().ToString());
            }
        }

        private static decimal CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate)
        {
            decimal futureValue = 0m;
            for (int idx = 0; idx < months; idx++)
            {
                futureValue = (futureValue + monthlyInvestment)
                               * (1 + monthlyInterestRate);
            }

            return futureValue;
        }
    }
}
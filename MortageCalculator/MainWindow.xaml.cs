using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MortageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // adding variables
        static public double amountBorrowed { get; set; }
        static public double interestRate { get; set; }
        static public int mortgagePeriod { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // get and parse values 
            amountBorrowed = (double)Int32.Parse(Amount.text);
            // get interest rate
            decimal result;
            if (Decimal.TryParse(Interest.Text, out result))
                interestRate = (double)result;

            //get mortgage period
            mortgagePeriod = Int32.Parse(Period.Text);
            // calculate mortgage
            MonthlyPayments.Text =
                CalcMortgage(amountBorrowed, interestRate,
                             mortgagePeriod);
        }
        private string CalcMortgage(double amountBorrowed,
                           double interestRate,
                           int mortgagePeriod)
        {
            double p = amountBorrowed;
            double r = ConvertToMonthlyInterest(interestRate);
            double n = YearsToMonths(mortgagePeriod);

            //c=r(1+r)power n/ (1+r)power n - 1 multiply by p is written as below for mortgage calculation

            var c = (decimal)(((r * p) * Math.Pow((1 + r), n)) /
                    (Math.Pow((1 + r), n) - 1));

            return ($"${Math.Round(c, MidpointRounding.AwayFromZero)}");
        }
        private int YearsToMonths(int years)
        {
            return (12 * years);
        }

        private double ConvertToMonthlyInterest(double percent)
        {
            return (percent / 12) / 100;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}

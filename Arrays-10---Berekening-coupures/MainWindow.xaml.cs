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

namespace Arrays_10___Berekening_coupures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float[] _units = new float[15] {
                500.0f,
                200.0f,
                100.0f,
                50.0f,
                20.0f,
                10.0f,
                5.0f,
                2.0f,
                1.0f,
                0.5f,
                0.2f,
                0.1f,
                0.05f,
                0.02f,
                0.01f };

        private float[] _numbers = new float[15];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            float restAmount;
            bool isSucceeded = float.TryParse(amountTextBox.Text, out restAmount);
            if (!isSucceeded)
            {
                resultTextBox.Text = "Geef een correct bedrag in!";
                return;
            }

            // Alle briefjes één voor één proberen. Start met grootste briefje
            for (int i = 0; i < _units.Length; i++)
            {
                do
                {
                    restAmount -= _units[i];
                    _numbers[i]++;
                } while (restAmount > 0);

                if (restAmount < 0)
                {
                    restAmount += _units[i];
                    _numbers[i]--;
                }
            }

            // Bouw resultaat op
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _numbers.Length; i++)
            {
                if (_numbers[i] > 0)
                    builder.AppendLine($"{_numbers[i],3} stuk(s) van {_units[i]:c}");
            }
            // Toon resultaat
            resultTextBox.Text = builder.ToString();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            amountTextBox.Clear();
            resultTextBox.Clear();
            amountTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

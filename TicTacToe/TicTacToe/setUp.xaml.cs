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
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for setUp.xaml
    /// </summary>
    public partial class setUp : Window
    {

        private int fieldSize;
        private int win;

        public setUp()
        {
            InitializeComponent();
           // MessageBox.Show("Nastavte herní pole, X na X.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (_checkInput())
            {
                new MainWindow(fieldSize, win).Show();
                this.Close();              
            }

        }

        private bool _checkInput()
        {
            try
            {
                fieldSize = Int32.Parse(gameField.Text);
                win = Int32.Parse(winNum.Text);

                if (fieldSize > 0 && win > 0 && fieldSize > win)
                {
                    return true;
                }


                return false;
                

             
            }
            catch (Exception)
            {

                MessageBox.Show("Zadejte čísla!");

                return false;
            }
           
          


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_checkInput())
            {
                new MultiplayerWindow(fieldSize, win).Show();
                this.Close();
            }
        }
    }
}

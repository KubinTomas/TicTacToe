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
    /// Interaction logic for endGame.xaml
    /// </summary>
    public partial class endGame : Window
    {
        private string win;

        public endGame(string win)
        {
            InitializeComponent();
            this.win = win;
            winner.Text = win;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new setUp().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

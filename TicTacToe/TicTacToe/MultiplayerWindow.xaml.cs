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
    /// Interaction logic for MultiplayerWindow.xaml
    /// </summary>
    public partial class MultiplayerWindow : Window
    {

        private int size;
        private int win;

        public MultiplayerWindow(int size, int win)
        {
            InitializeComponent();
            this.size = size;
            this.win = win;
        }

        private void server_Click(object sender, RoutedEventArgs e)
        {
            new Server(int.Parse(txtPort.Text), size, win);
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            new Client(txtIp.Text, int.Parse(txtPort.Text), size, win);
        }
    }
}

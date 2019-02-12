using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe
{
    class Client
    {

        private StreamReader sReader;
        private StreamWriter sWriter;

        private MainWindow mainWindow;


        public Client(string ip, int port, int size, int win)
        {
            mainWindow = new MainWindow(size, win);
            mainWindow.Show();

            mainWindow.setEvent(new MyDel(this.recieveData));
            _setClient(ip, port);
        }
        private void _setClient(string ip, int port)
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ip), port);


            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(serverAddress);

            NetworkStream netStream = new NetworkStream(socket);

            sReader = new StreamReader(netStream);
            sWriter = new StreamWriter(netStream);

            sWriter.AutoFlush = true;

            new Thread(delegate () {

                while (true)
                {
                    try
                    {
                        string tmp = sReader.ReadLine();
                        
                        _draw(tmp);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }


                }


            }).Start();
        }
        public void recieveData(Point p)
        {
            string tmp = "" + p.X + "|" + p.Y;
            sWriter.WriteLine(tmp);
        }
        public void sendData(string data)
        {
            sWriter.WriteLine(data);
        }
        private Point _toPoint(string tmp)
        {
            string[] split = tmp.Split('|');
            Point p = new Point();
            p.X = Double.Parse(split[0]);
            p.Y = Double.Parse(split[1]);

            return p;
        }

        private void _draw(string tmp)
        {
            mainWindow.serverDrawCross(_toPoint(tmp));
        }
    }
}

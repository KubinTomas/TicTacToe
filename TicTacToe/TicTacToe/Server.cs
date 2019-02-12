using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe;

namespace TicTacToe
{



    class Server
    {
        private StreamReader sReader;
        private StreamWriter sWriter;

        private MainWindow mainWindow;

        public Server(int port, int size, int win)
        {
            mainWindow = new MainWindow(size, win);
            mainWindow.Show();
            mainWindow.setEvent(new MyDel(this.recieveData));

            _serverSetUp(port);
        }
        private void _serverSetUp(int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));

            socket.Listen(10);

            new Thread(delegate ()
            {
                Socket client = socket.Accept();

                NetworkStream netStream = new NetworkStream(client);

                sReader = new StreamReader(netStream);
                sWriter = new StreamWriter(netStream);
                sWriter.AutoFlush = true;

                while (true)
                {
                    try
                    {
                        string tmp = sReader.ReadLine();
                        MessageBox.Show(tmp);
                        mainWindow.serverDrawCross(_toPoint(tmp));

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
    }

}
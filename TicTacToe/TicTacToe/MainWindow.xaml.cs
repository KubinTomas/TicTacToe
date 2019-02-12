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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   public delegate void MyDel(Point point);

    public partial class MainWindow : Window
    {
        private event MyDel sendPointEvt;
        private bool isEventDone;

        private gameField gameField;
        private int numberToWin;

        private Circle circle;
        private Cross cross;

        private bool circleTurn;

        private Rectangle[,] field;
        private Polygons[,] players;

        private int height;
        private int width;

        private int rcHei;
        private int rcWi;

        private int rectSize;
        private int n;

        public MainWindow(int size, int win)
        {
            InitializeComponent();

            width = (int)myCanvas.Width;
            numberToWin = win;
            rectSize = width/size;
            _start();

            _responzive();

            _drawGameField();
        }
        public void setEvent(MyDel function)
        {
            isEventDone = true;
            sendPointEvt += function;
        }
        private void _callEvent(Point p)
        {
            sendPointEvt.Invoke(p);
        }
        private void _start()
        {
            circleTurn = true;

            isEventDone = false;

            circle = new Circle(rectSize, rectSize, 0, 0);
            cross = new Cross(rectSize, rectSize);
        }

        private void _responzive()
        {
            width = (int)myCanvas.Width;
            height = (int)myCanvas.Height;

            n = width / rectSize;
           
            players = new Polygons[n, n];

            // MessageBox.Show(width + ", " + height + " One Rect will be: " + rectSize);
            _gameFieldSetUp();
        }

        private void _gameFieldSetUp()
        {
            // MessageBox.Show(n.ToString() + " " + rectSize);
            gameField = new gameField(n, rectSize);
            field = gameField.getField();
        }

        private void _drawGameField()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //   MessageBox.Show(field[i, j].ToString());
                    // if (field[i, j] != null)
                    Canvas.SetLeft(field[i, j], j * rectSize);
                    Canvas.SetTop(field[i, j], i * rectSize);
                    myCanvas.Children.Add(field[i, j]);
                }
            }

        }

        public void serverDrawCross(Point p)
        {
            players[(int)p.X, (int)p.Y] = cross;
            _addOnCanvas(cross.getCross(), (int)p.X, (int)p.Y, cross.getWidth());
        }

        private void myKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(myCanvas);

            int i = (int)p.Y / rectSize;
            int j = (int)p.X / rectSize;

            Point p2 = new Point();
            p2.X = i;
            p2.Y = j;

            if(isEventDone)
            {
                _callEvent(p2);
            }


            if (players[i,j] == null)
            {
                if (circleTurn)
                {
                    _playerCircle(i, j);
                    circleTurn = !circleTurn;

                    if (_endGame(i, j, players[i, j]))
                    {                      
                        new endGame("Circle won the game!").Show();
                        this.Close();                        
                    }

                }
                else
                {
                    _playerCross(i, j);
                    circleTurn = !circleTurn;

                    if (_endGame(i, j, players[i, j]))
                    {
                        MessageBox.Show("Cross won the game.");
                        new endGame("Cross won the game!").Show();
                        this.Close();
                    }
                }
            }

            //     MessageBox.Show("Mouse position is: " + p.ToString() + "||||   I: " + i + "J: " + j);
        }

        private void _playerCircle(int i, int j)
        {        
                players[i, j] = circle;

                _addOnCanvas(circle.getCircle(), i, j, circle.getWidth());      
        }

        private void _playerCross(int i, int j)
        {
            players[i, j] = cross;

            _addOnCanvas(cross.getCross(), i, j, cross.getWidth());
        }
        private void _addOnCanvas(Shape shape, int i, int j, double ellSize)
        {
            Canvas.SetLeft(shape, j * ellSize);
            Canvas.SetTop(shape, i * ellSize);
            myCanvas.Children.Add(shape);
        }
        private bool _endGame(int i, int j, Polygons pol)
        {
            // MessageBox.Show("Type is: " + pol.GetType());

            int horizontal = 0;
            int vertical = 0;
            int leftDia = 0;
            int rightDia = 0;

            for (int x = -numberToWin; x <= numberToWin; x++)
            {
                // DODELAT CHECK NA WIN GAME
                try
                {
                    // Horizontalni
                    if ((j + x) >= 0)
                    {
                        if (players[i, j + x] != null && players[i, j + x].GetType() == pol.GetType())
                        {
                            horizontal++;

                            if (horizontal >= numberToWin)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            horizontal = 0;
                        }
                    }
                    // Vertical
                    if ((i + x) >= 0)
                    {
                        if (players[i + x, j] != null && players[i + x, j].GetType() == pol.GetType())
                        {
                            vertical++;

                            if (vertical >= numberToWin)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            vertical = 0;
                        }
                    }
                    // Left Dia
                    if ((i + x) >= 0 && (j + x) >= 0)
                    {
                        if (players[i + x, j + x] != null && players[i + x, j + x].GetType() == pol.GetType())
                        {
                          //  MessageBox.Show("Founded I: " + (i+x) + "J: " + (j+x));

                            leftDia++;

                            if (leftDia >= numberToWin)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            leftDia = 0;
                        }
                    }
                    // Right Dia
                    if ((i - x) >= 0 && (j + x) >= 0)
                    {
                        if (players[i - x, j + x] != null && players[i - x, j + x].GetType() == pol.GetType())
                        {
                            //MessageBox.Show("Founded I: " + (i - x) + "J: " + (j + x));

                            rightDia++;

                            if (rightDia >= numberToWin)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            rightDia = 0;
                        }
                    }

                }
                catch (Exception ex)
                {
                
                }


            }

            if (horizontal >= numberToWin || vertical >= numberToWin)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}

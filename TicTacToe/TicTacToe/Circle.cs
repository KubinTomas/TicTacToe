using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe
{
    class Circle : Polygons
    {

        private Ellipse ellipse;

        private int posX;
        private int posY;

        private int height;
        private int width;

        public Circle(int height, int width, int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
        }

        public Ellipse getCircle()
        {

            ellipse = new Ellipse();

            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Fill =  new SolidColorBrush(Colors.Blue);

            return ellipse;
        }
        public Double getWidth()
        {
            return width;
        }
    }
}

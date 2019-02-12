using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace TicTacToe
{
    class Cross : Polygons
    {

        private Rectangle rect;

        private int height;
        private int width;

        public Cross(int height, int width)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle getCross()
        {

            rect = new Rectangle();
            

            rect.Width = width;
            rect.Height = height;
            rect.Fill = new ImageBrush(new BitmapImage(
            new Uri(@"Images\Cross.png", UriKind.Relative)));

            return rect;
        }
  
        public Double getWidth()
        {
            return width;
        }
    }
}


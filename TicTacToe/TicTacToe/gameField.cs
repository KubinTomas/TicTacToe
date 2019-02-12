using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe
{
    class gameField
    {
        private Rectangle rect;

        private Rectangle[,] field;

        private int fieldSize;
        private int rectSize;

        public gameField(int fieldSize, int rectSize)
        {
            this.fieldSize = fieldSize;
            this.rectSize = rectSize;          
            field = new Rectangle[fieldSize,fieldSize];

            _fillField();

        }

        private void _fillField()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = _getRect();
                }
            }
        }

        private Rectangle _getRect()
        {
            rect = new Rectangle();
            rect.Width = rectSize;
            rect.Height = rectSize;
            rect.Fill = new SolidColorBrush(Colors.White);
            rect.Stroke = new SolidColorBrush(Colors.Black);

            return rect;
        }

        public Rectangle[,] getField()
        {
            return field;
        }
    }
}

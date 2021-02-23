using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace WindowsFormsApplication1
{
    class DrawChessBoard
    {
        //棋盘数据
        private int intTop;
        private int intLeft;
        private int intFrameLenght;
        private int intSize;
        private int intCoordinateTop;
        private int intCoordinateLeft;
        private int intMid;
        private int intDotRadius;
        private int intDotInterva;
        //画图工具
        private Graphics graphics;
        private Pen penBlack;
        private Font font;
        private Brush bruBlack;
        private RectangleF rectangleF;

        public DrawChessBoard(Graphics graphics)
        {
            intFrameLenght = ConstView.CB_FrameLenght;
            intSize = ConstView.CB_Size;
            intTop = ConstView.CB_Top;
            intLeft = ConstView.CB_Left;
            intCoordinateTop = intTop - 10;
            intCoordinateLeft = intLeft - 10;
            intMid = intSize / 2;
            intDotRadius = ConstView.CB_DotRadius;
            intDotInterva = ConstView.CB_DoTInterval;

            this.graphics = graphics;
            penBlack = new Pen(Color.Black, 1);
            font = new Font("宋体", 10);
            bruBlack = new SolidBrush(Color.Black);
        }
        public void Draw()
        {
            graphics.Clear(Color.YellowGreen);
            for (int i = 0; i < intSize; i++)
            {
                graphics.DrawLine(penBlack, intTop, intLeft + i * intFrameLenght,
                    intTop + (intSize - 1) * intFrameLenght, intLeft + i * intFrameLenght);
                graphics.DrawLine(penBlack, intTop + i * intFrameLenght, intLeft,
                    intTop + i * intFrameLenght, intLeft + (intSize - 1) * intFrameLenght);

                rectangleF = new RectangleF(intCoordinateTop, intCoordinateLeft + i * intFrameLenght, intFrameLenght, intFrameLenght);
                graphics.DrawString(i.ToString(), font, bruBlack, rectangleF, null);
                rectangleF = new RectangleF(intCoordinateTop + i * intFrameLenght, intCoordinateLeft, intFrameLenght, intFrameLenght);
                graphics.DrawString(i.ToString(), font, bruBlack, rectangleF, null);
            }
            rectangleF = new RectangleF(intTop - intDotRadius / 2 + intMid * intFrameLenght, intLeft - intDotRadius / 2 + intMid * intFrameLenght,
                intDotRadius, intDotRadius);
            graphics.FillEllipse(bruBlack, rectangleF);

            rectangleF = new RectangleF(intTop - intDotRadius / 2 + (intMid - intDotInterva) * intFrameLenght, intLeft - intDotRadius / 2 + (intMid - intDotInterva) * intFrameLenght,
                intDotRadius, intDotRadius);
            graphics.FillEllipse(bruBlack, rectangleF);

            rectangleF = new RectangleF(intTop - intDotRadius / 2 + (intMid - intDotInterva) * intFrameLenght, intLeft - intDotRadius / 2 + (intMid + intDotInterva) * intFrameLenght,
                intDotRadius, intDotRadius);
            graphics.FillEllipse(bruBlack, rectangleF);

            rectangleF = new RectangleF(intTop - intDotRadius / 2 + (intMid + intDotInterva) * intFrameLenght, intLeft - intDotRadius / 2 + (intMid - intDotInterva) * intFrameLenght,
                intDotRadius, intDotRadius);
            graphics.FillEllipse(bruBlack, rectangleF);

            rectangleF = new RectangleF(intTop - intDotRadius / 2 + (intMid + intDotInterva) * intFrameLenght, intLeft - intDotRadius / 2 + (intMid + intDotInterva) * intFrameLenght,
                intDotRadius, intDotRadius);
            graphics.FillEllipse(bruBlack, rectangleF);
        }
    }
}

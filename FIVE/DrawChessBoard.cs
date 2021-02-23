using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 画棋盘背景的类，YellowGreen背景，线条、坐标和圆点
    /// </summary>
    class DrawChessBoard
    {
        //棋盘数据
        private int intTop;
        private int intLeft;
        private int intFrameLenght;//格子边长
        private int intSize;//19格
        private int intCoordinateTop;//上坐标0-18
        private int intCoordinateLeft;//左坐标0-18
        private int intMid;//中心点
        private int intDotRadius;//点的半径
        private int intDotInterva;//点的间隔，用于计算的吗？
        //画图工具
        private Graphics graphics;
        private Pen penBlack;//画线条
        private Font font;//字体
        private Brush bruBlack;//画圆点
        private RectangleF rectangleF;//坐标宽高，矩阵

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
            graphics.Clear(Color.YellowGreen);//YellowGreen背景
            for (int i = 0; i < intSize; i++)
            {
                //画线条
                graphics.DrawLine(penBlack, intTop, intLeft + i * intFrameLenght,
                    intTop + (intSize - 1) * intFrameLenght, intLeft + i * intFrameLenght);
                graphics.DrawLine(penBlack, intTop + i * intFrameLenght, intLeft,
                    intTop + i * intFrameLenght, intLeft + (intSize - 1) * intFrameLenght);

                //画坐标
                rectangleF = new RectangleF(intCoordinateTop, intCoordinateLeft + i * intFrameLenght, intFrameLenght, intFrameLenght);
                graphics.DrawString(i.ToString(), font, bruBlack, rectangleF, null);
                rectangleF = new RectangleF(intCoordinateTop + i * intFrameLenght, intCoordinateLeft, intFrameLenght, intFrameLenght);
                graphics.DrawString(i.ToString(), font, bruBlack, rectangleF, null);
            }

            //画五个点
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

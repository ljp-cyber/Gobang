using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 棋盘画面常量
    /// </summary>
    static class ConstView
    {
        /// <summary>
        /// ChessBoard简称CB，棋盘大小
        /// </summary>
        public const int CB_Lenght = 650;
        /// <summary>
        /// 一格边长
        /// </summary>
        public const int CB_FrameLenght = 30;
        /// <summary>
        /// 19格
        /// </summary>
        public const int CB_Size = 19;
        /// <summary>
        /// 上边界
        /// </summary>
        public const int CB_Top = 30;
        /// <summary>
        /// 左边界
        /// </summary>
        public const int CB_Left = 30;
        /// <summary>
        /// 点半径
        /// </summary>
        public const int CB_DotRadius = 10;
        /// <summary>
        /// 点间隔
        /// </summary>
        public const int CB_DoTInterval = 4;

        /// <summary>
        /// 段长度，应该是减去线的一个边长
        /// </summary>
        public const int PieceLenght = 28;


        /// <summary>
        /// 根据坐标计算所在格
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int[] GetPos(int x, int y)
        {
            x = (int)(x- (CB_Top - CB_FrameLenght / 2)) / CB_FrameLenght;
            y = (int)(y - (CB_Left - CB_FrameLenght / 2)) / CB_FrameLenght;
            if (x < 0) { x = 0; }
            if (y < 0) { y = 0; }
            if (x > ConstFive.B_MAX_XY) { x = ConstFive.B_MAX_XY; }
            if (y > ConstFive.B_MAX_XY) { y = ConstFive.B_MAX_XY; }
            return new int[] { x, y };
        }
    }
}

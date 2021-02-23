using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 传入Graphics绘图工具和游戏逻辑类画棋子
    /// </summary>
    class DrawGame
    {
        /// <summary>
        /// 减去线条的一个边长
        /// </summary>
        private int intPieceLenght;
        /// <summary>
        /// 一格边长
        /// </summary>
        private int intCB_FrameLenght;
        private int intBlackSign;//黑棋标识
        private int intWhiteSign;//白旗标识
        private int intCB_Size;
        /// <summary>
        /// 误差，应该是线条大小
        /// </summary>
        private int intError;
        private int intCB_Top;
        private int intCB_left;

        private Game Game;//游戏逻辑类
        private int[,] arrGame;//游戏数组
        private int[] focal;//焦点

        private Pen penRed;//红色格字钢笔
        private SolidBrush brushWhite;//白棋画笔
        private SolidBrush brushBlack;//黑棋画笔

        /// <summary>
        /// 传入游戏逻辑类初始化
        /// </summary>
        /// <param name="Game">游戏逻辑类</param>
        public DrawGame( Game Game)
        {
            intPieceLenght = ConstView.PieceLenght;
            intCB_FrameLenght = ConstView.CB_FrameLenght;
            intCB_Size = ConstView.CB_Size;
            intBlackSign = ConstFive.BLACK_SIGN;
            intWhiteSign = ConstFive.WHITE_SIGN;
            intError = (intCB_FrameLenght - intPieceLenght) / 2;
            intCB_Top = ConstView.CB_Top;
            intCB_left = ConstView.CB_Left;

            this.Game = Game;
            arrGame = Game.GetGameArray();
            focal = Game.GetFocal();
            penRed = new Pen(Color.Red, 1);
            brushWhite = new SolidBrush(Color.White);
            brushBlack = new SolidBrush(Color.Black);
        }

        /// <summary>
        /// 画图，白棋、黑棋和红色焦点框
        /// </summary>
        /// <param name="g">Graphics绘图工具的引用</param>
        public void Draw(Graphics g)
        {
            for (int i = 0; i < intCB_Size; i++)
            {
                for (int j = 0; j < intCB_Size; j++)
                {
                    if (arrGame[i, j] == intBlackSign)
                    {
                        //画黑棋
                        g.FillEllipse(brushBlack,
                            intCB_Top - intCB_FrameLenght / 2 + i * intCB_FrameLenght + intError,
                            intCB_left - intCB_FrameLenght / 2 + j * intCB_FrameLenght + intError,
                            intPieceLenght, intPieceLenght);
                    }
                    if (arrGame[i, j] == intWhiteSign)
                    {
                        //画白旗
                        g.FillEllipse(brushWhite,
                            intCB_Top - intCB_FrameLenght / 2 + i * intCB_FrameLenght + intError,
                            intCB_left - intCB_FrameLenght / 2 + j * intCB_FrameLenght + intError,
                            intPieceLenght, intPieceLenght);
                    }
                }
            }

            //画焦点框
            g.DrawRectangle(penRed,
                intCB_Top - intCB_FrameLenght / 2 + focal[0] * intCB_FrameLenght,
                intCB_left - intCB_FrameLenght / 2 + focal[1] * intCB_FrameLenght,
                intCB_FrameLenght, intCB_FrameLenght);
        }
    }
}

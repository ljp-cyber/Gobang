using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{
    class DrawGame
    {
        private int intPieceLenght;
        private int intCB_FrameLenght;
        private int intBlackSign;
        private int intWhiteSign;
        private int intCB_Size;
        private int intError;
        private int intCB_Top;
        private int intCB_left;

        private Game Game;
        private int[,] arrGame;
        private int[] focal;

        private Pen penRed;
        private SolidBrush brushWhite;
        private SolidBrush brushBlack;
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
        public void Draw(Graphics g)
        {
            for (int i = 0; i < intCB_Size; i++)
            {
                for (int j = 0; j < intCB_Size; j++)
                {
                    if (arrGame[i, j] == intBlackSign)
                    {
                        g.FillEllipse(brushBlack,
                            intCB_Top - intCB_FrameLenght / 2 + i * intCB_FrameLenght + intError,
                            intCB_left - intCB_FrameLenght / 2 + j * intCB_FrameLenght + intError,
                            intPieceLenght, intPieceLenght);
                    }
                    if (arrGame[i, j] == intWhiteSign)
                    {
                        g.FillEllipse(brushWhite,
                            intCB_Top - intCB_FrameLenght / 2 + i * intCB_FrameLenght + intError,
                            intCB_left - intCB_FrameLenght / 2 + j * intCB_FrameLenght + intError,
                            intPieceLenght, intPieceLenght);
                    }
                }
            }
            g.DrawRectangle(penRed,
                intCB_Top - intCB_FrameLenght / 2 + focal[0] * intCB_FrameLenght,
                intCB_left - intCB_FrameLenght / 2 + focal[1] * intCB_FrameLenght,
                intCB_FrameLenght, intCB_FrameLenght);
        }
    }
}

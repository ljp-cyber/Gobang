using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Game
    {
        private int[,] arrGame;
        private int[] arrFocal;
        private List<int[]> lstAllPlayed;

        private bool gameOver;
        private int round;
        private int next;

        private int computer1;
        private int computer2;


        public Game()
        {
            arrGame = new int[ConstFive.BL, ConstFive.BL];
            arrFocal = new int[2] { ConstFive.BL / 2, ConstFive.BL / 2 };
            lstAllPlayed = new List<int[]>();
            gameOver = true;
            round = -1;
            next = ConstFive.BLACK_SIGN;
            computer1 = ConstFive.NONE_SIGN;
            computer2 = ConstFive.NONE_SIGN;
        }
        public void GameStart(int playerSum, bool first)
        {
            if (playerSum == 0)
            {
                computer1 = ConstFive.BLACK_SIGN;
                computer2 = ConstFive.WHITE_SIGN;
            }
            else if (playerSum == 1)
            {
                if (!first)
                {
                    computer1 = ConstFive.BLACK_SIGN;
                }
                else
                {
                    computer1 = ConstFive.WHITE_SIGN;
                }
            }
            for (int i = 0; i < ConstFive.BL; i++)
            {
                for (int j = 0; j < ConstFive.BL; j++)
                {
                    arrGame[i, j] = ConstFive.SPACE_SIGN;
                }
            }
            arrFocal[0] = ConstFive.BL / 2;
            arrFocal[1] = ConstFive.BL / 2;
            lstAllPlayed.Clear();
            next = ConstFive.BLACK_SIGN;
            round = 1;
            gameOver = false;
        }
        //获取数据
        public int[,] GetGameArray() 
        {
            return arrGame;
        }
        public int[] GetFocal()
        {
            return arrFocal;
        }
        public bool GetIsGameOver()
        {
            return gameOver;
        }
        //走一步
        public void PalyA(int x,int y)
        {
            if (gameOver == false)
            {
                if (round == 1 && next == ConstFive.BLACK_SIGN)
                {
                    x = ConstFive.BL / 2;
                    y = ConstFive.BL / 2;
                }
                else
                {
                    if (next == computer1)
                    {
                        int[] temp = AIPlayA();
                        x = temp[0];
                        y = temp[1];
                    }
                    else if (next == computer2)
                    {
                        int[] temp = AIPlayA();
                        x = temp[0];
                        y = temp[1];
                    }
                }
                if (arrGame[x, y] == ConstFive.SPACE_SIGN)
                {
                    arrGame[x, y] = next;
                    lstAllPlayed.Add(new int[] { x, y, next });
                    gameOver = IsGameOver(x, y);
                    NextPlayer();
                }
            }
            arrFocal[0] = x;
            arrFocal[1] = y;
        }
        //其他操作
        public void LookChess()
        {
            //List<int[]> listAllPlayer = new List<int[]>();
            //listAllPlayer.Add(new int[] { 10, 8, 1 });
            //listAllPlayer.Add(new int[] { 12, 8, 1 });
            //listAllPlayer.Add(new int[] { 13, 8, 1 });
            //listAllPlayer.Add(new int[] { 14, 8, 1 });
            //listAllPlayer.Add(new int[] { 15, 8, 1 });
            //listAllPlayer.Add(new int[] { 9, 4, 2 });
            //listAllPlayer.Add(new int[] { 9, 5, 2 });
            //listAllPlayer.Add(new int[] { 9, 6, 2 });
            //listAllPlayer.Add(new int[] { 9, 2, 2 });

            SearchChessType search = new SearchChessType(lstAllPlayed, ConstFive.BLACK_SIGN);
            int[][][][] tempcom = search.GetMeLinkArray();
            int[] tempcountcom = search.GetMeLinkArrayCount();
            MessageBox.Show("电脑方： Five:" + tempcountcom[0] + ",FOUR:" + tempcountcom[1] + ",SFOUR:" + tempcountcom[2] +
                ",THREE:" + tempcountcom[3] + ",STHREE:" + tempcountcom[4] + ",TWO:" + tempcountcom[5] + ",STWO:" + tempcountcom[6]);
            int[][][][] temppeo = search.GetEnemyLinkArray();
            int[] tempcountpeo = search.GetEnemyLinkArrayCount();
            MessageBox.Show("人方： Five:" + tempcountpeo[0] + ",FOUR:" + tempcountpeo[1] + ",SFOUR:" + tempcountpeo[2] +
                ",THREE:" + tempcountpeo[3] + ",STHREE:" + tempcountpeo[4] + ",TWO:" + tempcountpeo[5] + ",STWO:" + tempcountpeo[6]);
        }
        public void VCF()
        {
            AIPlayer ai = new AIPlayer(arrGame, lstAllPlayed, next, next);
            int[] temp = ai.GetVCF();
            if (temp == null)
            {
                MessageBox.Show("不能VCF");
            }
            else
            {
                MessageBox.Show("VCF:" + temp[0] + "," + temp[1]);
            }
        }
        public void VCT()
        {
            AIPlayer ai = new AIPlayer(arrGame, lstAllPlayed, next, next);
            int[] temp = ai.GetVCT();
            if (temp == null)
            {
                MessageBox.Show("不能VCT");
            }
            else
            {
                MessageBox.Show("VCT:" + temp[0] + "," + temp[1]);
            }
        }
        public void UnDo()
        {
            if (round > 1)
            {
                int intUnDoX = lstAllPlayed[lstAllPlayed.Count - 1][0];
                int intUnDoY = lstAllPlayed[lstAllPlayed.Count - 1][1];
                lstAllPlayed.RemoveAt(lstAllPlayed.Count - 1);
                arrGame[intUnDoX, intUnDoY] = ConstFive.SPACE_SIGN;
                NextPlayer();
                if (gameOver == true) { gameOver = false; }
                if (next == computer1 || next == computer2)
                {
                    intUnDoX = lstAllPlayed[lstAllPlayed.Count - 1][0];
                    intUnDoY = lstAllPlayed[lstAllPlayed.Count - 1][1];
                    lstAllPlayed.RemoveAt(lstAllPlayed.Count - 1);
                    arrGame[intUnDoX, intUnDoY] = ConstFive.SPACE_SIGN;
                    NextPlayer();
                }
                arrFocal[0] = intUnDoX;
                arrFocal[1] = intUnDoY;
            }
        }

        private bool IsGameOver(int x, int y)
        {
            bool over = false;
            int link1 = 0;
            int link2 = 0;
            int link3 = 0;
            int link4 = 0;
            for (int i = -4; i < 5; i++)
            {
                if (0 <= y + i && y + i <= ConstFive.B_MAX_XY)
                {
                    if (arrGame[x, y + i] == next) { link1++; if (link1 == 5) { break; } }
                    else { link1 = 0; }
                }
                if (0 <= x + i && x + i <= ConstFive.B_MAX_XY)
                {
                    if (arrGame[x + i, y] == next) { link2++; if (link2 == 5) { break; } }
                    else { link2 = 0; }
                }
                if (0 <= x + i && x + i <= ConstFive.B_MAX_XY && 0 <= y + i && y + i <= ConstFive.B_MAX_XY)
                {
                    if (arrGame[x + i, y + i] == next) { link3++; if (link3 == 5) { break; } }
                    else { link3 = 0; }
                }
                if (0 <= x - i && x - i <= ConstFive.B_MAX_XY && 0 <= y + i && y + i <= ConstFive.B_MAX_XY)
                {
                    if (arrGame[x - i, y + i] == next) { link4++; if (link4 == 5) { break; } }
                    else { link4 = 0; }
                }
            }
            if (link1 == 5 || link2 == 5 || link3 == 5 || link4 == 5) { over = true; }
            return over;
        }
        private void NextPlayer() 
        {
            if (next == ConstFive.BLACK_SIGN)
            {
                next = ConstFive.WHITE_SIGN;
            }
            else
            {
                round++;
                next = ConstFive.BLACK_SIGN;
            }
        }
        private int[] AIPlayA() 
        {
            AIPlayer ai = new AIPlayer(arrGame, lstAllPlayed, next, next);
            return ai.GetTarget();
        }
    }
}

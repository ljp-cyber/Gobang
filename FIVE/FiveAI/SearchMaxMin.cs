using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class SearchMaxMin
    {
        private int[,] arrGame;
        private List<int[]> lstAllPlayed;
        private int intNext;
        private int intMeSign;
        private PointsAndScore pointsAndScore;
        public SearchMaxMin(int[,] arrGame, List<int[]> lstAllPlayed,int intNext,int intMeSign)
        {
            this.arrGame = arrGame;
            this.lstAllPlayed = lstAllPlayed;
            this.intNext = intNext;
            this.intMeSign = intMeSign;
        }
        private void MaxMin()
        {
 
        }
        private void PlayA(int x,int y)
        {
            arrGame[x, y] = intNext;
            lstAllPlayed.Add(new int[] { x, y, intNext });
            NextPlayer();
        }
        private void UnDoA(int x,int y)
        {
            arrGame[x, y] = ConstFive.SPACE_SIGN;
            lstAllPlayed.RemoveAt(lstAllPlayed.Count - 1);
            NextPlayer();
        }
        private void UnDoA()
        {
            int end = lstAllPlayed.Count - 1;
            int x = lstAllPlayed[end][0];
            int y = lstAllPlayed[end][1];
            arrGame[x, y] = ConstFive.SPACE_SIGN;
            lstAllPlayed.RemoveAt(lstAllPlayed.Count - 1);
            NextPlayer();
        }
        private void NextPlayer()
        {
            intNext = intNext == ConstFive.BLACK_SIGN ? ConstFive.WHITE_SIGN : ConstFive.BLACK_SIGN;
        }
    }
}

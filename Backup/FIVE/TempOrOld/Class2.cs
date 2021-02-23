using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Class2
    {
        private const int B_MIN_X = 0;
        private const int B_MIN_Y = 0;
        private const int B_MAX_X = 18;
        private const int B_MAX_Y = 18;
        private const int BLACK_SIGN = 1;
        private const int WHITE_SIGN = 2;
        private const int SPACE_SIGN = 0;
        private const int NONE_SIGN = -1;

        private int[,] arrGameBoard;
        private int intMeSign;

        private int[][] arrMePlayed;
        private int intMePlayedSum;
        private int[][] arrEnemyPlayed;
        private int intEnemyPlayedSum;

        private List<int[]> listMePlayed;
        private List<int[]> listEnemyPlayed;

        public Class2(int[,] arrGameBoard, int intMeSign, int[][] arrMePlayed, int intMePlayedSum, int[][] arrEnemyPlayed, int intEnemyPlayedSum)
        {
            this.arrGameBoard = arrGameBoard;
            this.intMeSign = intMeSign;

            this.arrMePlayed = arrMePlayed;
            this.intMePlayedSum = intMePlayedSum;
            this.arrEnemyPlayed = arrEnemyPlayed;
            this.intEnemyPlayedSum = intEnemyPlayedSum;
            this.listMePlayed = ArrayToList(arrMePlayed, intMePlayedSum);
            this.listEnemyPlayed = ArrayToList(arrEnemyPlayed, intEnemyPlayedSum);
        }

        public Class2(int[,] arrGameBoard, int intMeSign, int[][] arrMePlayed, int[][] arrEnemyPlayed)
        {
            this.arrGameBoard = arrGameBoard;
            this.intMeSign = intMeSign;

            this.arrMePlayed = arrMePlayed;
            this.arrEnemyPlayed = arrEnemyPlayed;
            this.listMePlayed = ArrayToList(arrMePlayed);
            this.listEnemyPlayed = ArrayToList(arrEnemyPlayed);
        }

        private Class2(int[,] arrGameBoard,int intMeSign, List<int[]> listMePlayed, List<int[]> listEnemyPlayed)
        {
            this.arrGameBoard = arrGameBoard;
            this.intMeSign = intMeSign;
            this.listMePlayed = listMePlayed;
            this.listEnemyPlayed = listEnemyPlayed;
        }

        private void GetMeAllPoints()
        {
            List<int[]> listMePoints = new List<int[]>();
            for (int i = intMePlayedSum - 1; i >= 0; i--)
            {
                int[] temp;
                temp = new int[2] { arrMePlayed[i][0], arrMePlayed[i][1] - 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0], arrMePlayed[i][1] + 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0]-1, arrMePlayed[i][1] };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0] + 1, arrMePlayed[i][1] };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0] - 1, arrMePlayed[i][1] - 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0] + 1, arrMePlayed[i][1] - 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0] - 1, arrMePlayed[i][1] + 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
                temp = new int[2] { arrMePlayed[i][0] + 1, arrMePlayed[i][1] + 1 };
                if (GetSign(temp) == ConstFive.SPACE_SIGN)
                {
                    JoinPointsList(listMePoints, temp);
                }
            }
        }

        private int GetSign(int x,int y)
        {
            int sign = 0;
            if (x < ConstFive.B_MIN_X || y < ConstFive.B_MIN_Y || x > ConstFive.B_MAX_X || y > ConstFive.B_MAX_Y)
            { 
                sign = ConstFive.NONE_SIGN; 
            }
            else
            {
                sign = arrGameBoard[x, y];
            }
            return sign;
        }
        private int GetSign(int[] xy)
        {
            int sign = 0;
            int x = xy[0];
            int y = xy[1];
            if (x < ConstFive.B_MIN_X || y < ConstFive.B_MIN_Y || x > ConstFive.B_MAX_X || y > ConstFive.B_MAX_Y)
            {
                sign = ConstFive.NONE_SIGN;
            }
            else
            {
                sign = arrGameBoard[x, y];
            }
            return sign;
        }
        private List<int[]> ArrayToList(int[][] arrPlayed, int arrPalyedSum)
        {
            List<int[]> listPlayed=new List<int[]>();
            for (int i = 0; i < arrPalyedSum; i++)
            {
                listPlayed.Add(arrPlayed[i]);
            }
            return listPlayed;
        }
        private List<int[]> ArrayToList(int[][] arrPlayed)
        {
            List<int[]> listPlayed = new List<int[]>();
            int i=0;
            while (arrPlayed[i] != null)
            {
                listPlayed.Add(arrPlayed[i]);
                i++;
            }
            return listPlayed;
        }
        private void JoinPointsList(List<int[]> listPoints,int[] aPoint)
        {
            for (int i = 0; i < listPoints.Count; i++)
            {
                if (aPoint[0] == listPoints[i][0] && aPoint[1] == listPoints[i][1])
                {
                    break;
                }
                else
                {
                    listPoints.Add(aPoint);
                }
            }
        }
    }
}

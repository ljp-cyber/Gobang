using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Class5
    {
        private int[,] arrGameArray;
        private int[][] arrPlayer1Array = new int[50][];
        private int[][] arrPlayer2Array = new int[50][];
        private int intPlayer1ArraySum;
        private int intPlayer2ArraySum;
        private int intMeSign;
        private int intEnemySign;
        private int intNext;

        Random ran = new Random();

        private const int MMIN = -1000000;
        private const int MMAX = 1000000;
        private const int LINK210_0_ = 0;
        private const int LINK2100_ = 1;
        private const int LINK2_0_0_ = 2;
        private const int LINK2_00_ = 3;
        private const int LINK3100_0_ = 4;
        private const int LINK31000_ = 5;
        private const int LINK3_00_0_ = 6;
        private const int LINK3_000_ = 7;
        private const int LINK41000_0_ = 8;
        private const int LINK410000_ = 9;
        private const int LINK4_000_0_ = 10;
        private const int LINK4_0000_ = 11;
        private const int LINK500000 = 12;
        private const int LINK50000_0 = 13;

        public Class5(int[,] gamearray, int next, int[][] player1array, int[][] player2array, int intPlayer1ArraySum, int intPlayer2ArraySum)
        {
            this.intMeSign = next;
            if (this.intMeSign == 1) { this.intEnemySign = 2; }
            else { this.intEnemySign = 1; }
            this.arrGameArray = gamearray;
            this.intPlayer1ArraySum = intPlayer1ArraySum;
            this.intPlayer2ArraySum = intPlayer2ArraySum;
            this.arrPlayer1Array = player1array;
            this.arrPlayer2Array = player2array;
            this.intNext = next;
        }

        public int[] GetTarget() 
        {
            return Where(arrGameArray, arrPlayer1Array, arrPlayer2Array, intPlayer1ArraySum, intPlayer2ArraySum, intNext, intMeSign, intEnemySign);
        }

        private int[] Where(int[,] arrGameArray, int[][] arrPlayer1Array, int[][] arrPlayer2Array,
            int intPlayer1ArraySum, int intPlayer2ArraySum, int intNext, int intMeSign, int intEnemySign)
        {
            int deep = 2;
            int[][] arrBestPoints=new int[50][];
            int intBestPointsSum = 0;

            int[][] arrMeArray;
            int intMeArraySum;
            int[][] arrEnemyArray;
            int intEnemyArraySum;
            if (intMeSign == 1)
            {
                arrMeArray = arrPlayer1Array;
                intMeArraySum = intPlayer1ArraySum;
                arrEnemyArray = arrPlayer2Array;
                intEnemyArraySum = intPlayer2ArraySum;
            }
            else
            {
                arrMeArray = arrPlayer2Array;
                intMeArraySum = intPlayer2ArraySum;
                arrEnemyArray = arrPlayer1Array;
                intEnemyArraySum = intPlayer1ArraySum;
            }

            int[][] arrPoints = GetPoints(arrMeArray, intMeArraySum, arrEnemyArray, intEnemyArraySum, arrGameArray);
            int intPointsSum = arrPoints[199][0];
            int best = MMIN;

            for (int i = 0; i < intPointsSum; i++)
            {
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                arrMeArray[intMeArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                intMeArraySum++;
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }

                int intThisScore = MIN(arrGameArray, arrMeArray, arrEnemyArray, intMeArraySum, intEnemyArraySum, intNext, intMeSign, deep-1);
                if (best == intThisScore)
                {
                    arrBestPoints[intBestPointsSum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                    intBestPointsSum++;
                }
                if (intThisScore > best)
                {
                    best = intThisScore;
                    arrBestPoints = new int[50][];
                    intBestPointsSum = 0;
                    arrBestPoints[intBestPointsSum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                    intBestPointsSum++;
                } 

                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                arrMeArray[intMeArraySum-1] = null;
                intMeArraySum--;
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
            }
            int[] arrTarget = arrBestPoints[ran.Next(0, intBestPointsSum - 1)];
            return arrTarget;
        }
        private int MAX(int[,] arrGameArray, int[][] arrMeArray, int[][] arrEnemyArray,
            int intMeArraySum, int intEnemyArraySum, int intNext, int intMeSign, int deep) 
        {
            int intScore = GetSituationScore(arrGameArray, intMeSign, arrMeArray, arrEnemyArray, intMeArraySum, intEnemyArraySum);
            if (deep <= 0 || intScore>50000)
            {
                return intScore;
            }
            int best = MMIN;
            int[][] arrPoints = GetPoints(arrMeArray, intMeArraySum, arrEnemyArray, intEnemyArraySum,arrGameArray);
            int intPointsSum = arrPoints[199][0];

            for (int i = 0; i < intPointsSum; i++)
            {
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                arrMeArray[intMeArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                intMeArraySum++;
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                int intThisScore = MIN(arrGameArray, arrMeArray, arrEnemyArray, intMeArraySum, intEnemyArraySum, intNext, intMeSign, deep-1);
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                arrMeArray[intMeArraySum-1] = null;
                intMeArraySum--;
                if (intNext == 2) { intNext = 1; } else { intNext = 2; }
                if (intThisScore > best) { best = intThisScore; }
            }

            return best;
        }

        private int MIN(int[,] arrGameArray, int[][] arrMeArray, int[][] arrEnemyArray,
            int intMeArraySum, int intEnemyArraySum, int intNext, int intMeSign, int deep)
        {
            int intScore = GetSituationScore(arrGameArray, intMeSign, arrMeArray, arrEnemyArray, intMeArraySum, intEnemyArraySum);
            if (deep <= 0||intScore<-50000)
            {
                return intScore;
            }
            int best = MMAX;
            int[][] arrPoints = GetPoints(arrMeArray, intMeArraySum, arrEnemyArray, intEnemyArraySum, arrGameArray);
            int intPointsSum = arrPoints[199][0];

            for (int i = 0; i < intPointsSum;i++ )
            {
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                arrEnemyArray[intEnemyArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                intEnemyArraySum++;
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                int intThisScore = MAX(arrGameArray, arrMeArray, arrEnemyArray, intMeArraySum, intEnemyArraySum, intNext, intMeSign, deep-1);
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                arrEnemyArray[intEnemyArraySum-1] = null;
                intEnemyArraySum--;
                if (intNext == 2) { intNext = 1; } else { intNext = 2; }
                if (intThisScore < best) { best = intThisScore; }
            }

            return best;
        }

        private int GetSituationScore(int[,] arrGameArray, int intMeSign, int[][] arrPlayer1Array, int[][] arrPlayer2Array, int intPlayer1ArraySum, int intPlayer2ArraySum)
        {
            Class4 class4 = new Class4(arrGameArray, intMeSign, arrPlayer1Array, arrPlayer2Array, intPlayer1ArraySum, intPlayer2ArraySum);

            //int[][][][] melinkarray = class4.GetMeLinkArray();
            //int[][][][] enemylinkarray = class4.GetEnemyLinkArray();

            int[] melinkNUMarray = class4.GetMeLinkArrayCount();
            int[] enemylinkNUMarray = class4.GetEnemyLinkArrayCount();

            class4 = null;

            int mescore = GetScore(melinkNUMarray);
            int enemyscore = GetScore(enemylinkNUMarray);
            int situationscore = mescore - enemyscore;
            return situationscore;
        }

        private int[][] GetPoints(int[][] arrPlayer2,int intPlayer2Sum,int[,] arrGameArray)
        {
            int[][] arrPoints=new int[100][];
            int intPointsSum=0;
            for (int i = 0; i < intPlayer2Sum; i++)
            {
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
            }
            return arrPoints;
        }

        private int[][] GetPoints(int[][] arrPlayer, int intPlayerSum, int[][] arrPlayer2, int intPlayer2Sum, int[,] arrGameArray)
        {
            int[][] arrPoints = new int[200][];
            int intPointsSum = 0;
            for (int i = 0; i < intPlayerSum; i++)
            {
                if (EveryOne(arrPlayer[i][0] - 1, arrPlayer[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] - 1, arrPlayer[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] - 2, arrPlayer[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] - 2, arrPlayer[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0] + 1, arrPlayer[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] + 1, arrPlayer[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] + 2, arrPlayer[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] + 2, arrPlayer[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0], arrPlayer[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0], arrPlayer[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0], arrPlayer[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0], arrPlayer[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0], arrPlayer[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0], arrPlayer[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0], arrPlayer[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0], arrPlayer[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0] - 1, arrPlayer[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] - 1, arrPlayer[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] - 2, arrPlayer[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] - 2, arrPlayer[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0] - 1, arrPlayer[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] - 1, arrPlayer[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] - 2, arrPlayer[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] - 2, arrPlayer[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0] + 1, arrPlayer[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] + 1, arrPlayer[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] + 2, arrPlayer[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] + 2, arrPlayer[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer[i][0] + 1, arrPlayer[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer[i][0] + 1, arrPlayer[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer[i][0] + 2, arrPlayer[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer[i][0] + 2, arrPlayer[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
            } 
            for (int i = 0; i < intPlayer2Sum; i++)
            {
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1], arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1], arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0], arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0], arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] - 1, arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] - 1, arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] - 2, arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] - 2, arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1] - 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] - 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1] - 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] - 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
                if (EveryOne(arrPlayer2[i][0] + 1, arrPlayer2[i][1] + 1, arrGameArray) == 0)
                {
                    int[] temp = new int[] { arrPlayer2[i][0] + 1, arrPlayer2[i][1] + 1 };
                    if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                    {
                        arrPoints[intPointsSum] = temp;
                        intPointsSum++;
                    }
                    if (EveryOne(arrPlayer2[i][0] + 2, arrPlayer2[i][1] + 2, arrGameArray) == 0)
                    {
                        temp = new int[] { arrPlayer2[i][0] + 2, arrPlayer2[i][1] + 2 };
                        if (JoinPointsArray(arrPoints, intPointsSum, temp) == true)
                        {
                            arrPoints[intPointsSum] = temp;
                            intPointsSum++;
                        }
                    }
                }
            }
            arrPoints[199] = new int[] { intPointsSum ,0};
            return arrPoints;
        }

        private bool JoinPointsArray(int[][] arrPoints, int intPointsSum, int[] arrPoint)
        {
            bool blnJoin = true;
            for (int i = 0; i < intPointsSum; i++)
            {
                if (arrPoint[0] == arrPoints[i][0] && arrPoint[1] == arrPoints[i][1])
                {
                    blnJoin = false;
                }
            }
            return blnJoin;
        }

        private int EveryOne(int x,int y,int[,] arrGameArray) 
        {
            int color=0;
            if (x > 18 || x < 0 || y > 18 || y < 0) { color = -1; }
            else 
            {
                color = arrGameArray[x, y];
            }
            return color;
        }

        private int GetScore(int[] arrLinkArrayCount)
        {
            //int intAddScore=1;
            int score = 0;
            score += arrLinkArrayCount[LINK210_0_] * 9;
            score += arrLinkArrayCount[LINK2100_] * 10;
            score += arrLinkArrayCount[LINK2_0_0_] * 95;
            score += arrLinkArrayCount[LINK2_00_] * 100;
            score += arrLinkArrayCount[LINK3100_0_] * 95;
            score += arrLinkArrayCount[LINK31000_] * 100;
            score += arrLinkArrayCount[LINK3_00_0_] * 950;
            score += arrLinkArrayCount[LINK3_000_] * 1000;
            score += arrLinkArrayCount[LINK41000_0_] * 950;
            score += arrLinkArrayCount[LINK410000_] * 1000;
            score += arrLinkArrayCount[LINK4_000_0_] * 9500;
            score += arrLinkArrayCount[LINK4_0000_] * 10000;
            score += arrLinkArrayCount[LINK50000_0] * 1000;
            score += arrLinkArrayCount[LINK500000] * 100000;
            return score;
        }
    }
}

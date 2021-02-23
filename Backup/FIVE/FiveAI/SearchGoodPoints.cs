using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class SearchGoodPoints
    {
        private int[][][][] arrMeLink;
        private int[] arrMeLinkCount;
        private int[][][][] arrEnemyLink;
        private int[] arrEnemyLinkCount;

        private int[,] arrGame;
        private List<int[]> listAllPlayed;
        private int intMeSign;
        //private int intNext;

        public SearchGoodPoints(int[,] arrGame, int intMeSign, List<int[]> listAllPlayed,
            int[][][][] arrMeLink, int[] arrMeLinkCount, int[][][][] arrEnemyLink, int[] arrEnemyLinkCount)
        {
            this.arrGame = arrGame;
            this.intMeSign = intMeSign;
            this.listAllPlayed = listAllPlayed;
            this.arrMeLink = arrMeLink;
            this.arrMeLinkCount = arrMeLinkCount;
            this.arrEnemyLink = arrEnemyLink;
            this.arrEnemyLinkCount = arrEnemyLinkCount;
        }


        public SearchGoodPoints(int[,] arrGame, int intMeSign, List<int[]> listAllPlayed)
        {
            this.arrGame = arrGame;
            this.intMeSign = intMeSign;
            this.listAllPlayed = listAllPlayed;
            GetLinkArray();
        }


        public void SetNewData(int[,] arrGame, int intMeSign, List<int[]> listAllPlayed,
            int[][][][] arrMeLink, int[] arrMeLinkCount, int[][][][] arrEnemyLink, int[] arrEnemyLinkCount)
        {
            this.arrGame = arrGame;
            this.intMeSign = intMeSign;
            this.listAllPlayed = listAllPlayed;
            this.arrMeLink = arrMeLink;
            this.arrMeLinkCount = arrMeLinkCount;
            this.arrEnemyLink = arrEnemyLink;
            this.arrEnemyLinkCount = arrEnemyLinkCount;
        }


        public void SetNewData(int[,] arrGame, int intMeSign, List<int[]> listAllPlayed)
        {
            this.arrGame = arrGame;
            this.intMeSign = intMeSign;
            this.listAllPlayed = listAllPlayed;
            GetLinkArray();
        }


        private void GetLinkArray()
        {
            SearchChessType search = new SearchChessType(listAllPlayed, intMeSign);
            arrMeLink = search.GetMeLinkArray();
            arrMeLinkCount = search.GetMeLinkArrayCount();
            arrEnemyLink = search.GetEnemyLinkArray();
            arrEnemyLinkCount = search.GetEnemyLinkArrayCount();
        }


        public int[][] GetAllPoints()
        {
            return GetPoints();
        }


        public int[][] GetSomePoints(int WillLink, bool isMe)
        {
            int[][] arrResult = new int[50][];
            int intResultSum = 0;
            int[][][][] tempLink;
            int[] tempLinkCount;
            if (isMe == true)
            {
                tempLink = arrMeLink;
                tempLinkCount = arrMeLinkCount;
            }
            else
            {
                tempLink = arrEnemyLink;
                tempLinkCount = arrEnemyLinkCount;
            }
            switch (WillLink)
            {
                case ConstFive.FIVE:
                    return FindWillFIVE(tempLink, tempLinkCount);
                case ConstFive.FOUR:
                    if (isMe == true)
                        return FindWillN(tempLink[ConstFive.THREE], tempLinkCount[ConstFive.THREE], 3, 0, false);
                    else
                        return FindEnemyWill4(tempLink[ConstFive.THREE], tempLinkCount[ConstFive.THREE], 3, false);
                case ConstFive.SFOUR:
                    return FindWillN(tempLink[ConstFive.STHREE], tempLinkCount[ConstFive.STHREE], 3, 1, false);
                case ConstFive.THREE:
                    return FindWillN(tempLink[ConstFive.TWO], tempLinkCount[ConstFive.TWO], 2, 1, false);
                case ConstFive.VCF:
                    return FindWillVCF(tempLink, tempLinkCount);
                case ConstFive.VCT:
                    return FindWillVCT(tempLink,tempLinkCount);
            }
            arrResult[49] = new int[2] { intResultSum, -1 };
            return arrResult;
        }


        private void AddAllPoints(int[][] arrPoints, ref int intPointsSum)
        {
            for (int i = 0; i < listAllPlayed.Count; i++)
            {
                int[] temp = new int[2] { listAllPlayed[i][0], listAllPlayed[i][1] - 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0], listAllPlayed[i][1] + 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] - 1, listAllPlayed[i][1] };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] + 1, listAllPlayed[i][1] };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] - 1, listAllPlayed[i][1] - 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] - 1, listAllPlayed[i][1] + 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] + 1, listAllPlayed[i][1] - 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                temp = new int[2] { listAllPlayed[i][0] + 1, listAllPlayed[i][1] + 1 };
                if (GetSign(temp[0], temp[1]) == 0)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, temp);
                }
                if (listAllPlayed[i][2] == intMeSign)
                {
                    temp = new int[2] { listAllPlayed[i][0], listAllPlayed[i][1] - 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0], listAllPlayed[i][1] + 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] - 2, listAllPlayed[i][1] };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] + 2, listAllPlayed[i][1] };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] - 2, listAllPlayed[i][1] - 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] - 2, listAllPlayed[i][1] + 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] + 2, listAllPlayed[i][1] - 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                    temp = new int[2] { listAllPlayed[i][0] + 2, listAllPlayed[i][1] + 2 };
                    if (GetSign(temp[0], temp[1]) == 0)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, temp);
                    }
                }
            }
        }


        private int[][] GetPoints()
        {
            int[][] arrPoints = new int[200][];
            int intPointsSum = 0;
            int[][] arrTemp = new int[10][];
            int intTempSum = 0;
            //判断我方可否成五
            if (arrMeLinkCount[ConstFive.FOUR] > 0)
            {
                //Console.WriteLine("GetPoints-我成5");
                return GetLinkToAPlay(arrMeLink[ConstFive.FOUR][0], 4, 0);
            }
            else if (arrMeLinkCount[ConstFive.SFOUR] > 0)
            {
                //Console.WriteLine("GetPoints-我成5");
                return GetLinkToAPlay(arrMeLink[ConstFive.SFOUR][0], 4, 0);
            }
            //判断敌方可否成五
            else if (arrEnemyLinkCount[ConstFive.FOUR] > 0)
            {
                //Console.WriteLine("GetPoints-敌成5");
                return GetLinkToAPlay(arrEnemyLink[ConstFive.FOUR][0], 4, 0);
            }
            else if (arrEnemyLinkCount[ConstFive.SFOUR] > 0)
            {
                //Console.WriteLine("GetPoints-敌成5");
                return GetLinkToAPlay(arrEnemyLink[ConstFive.SFOUR][0], 4, 0);
            }
            //判断我方可否成活四
            else if (arrMeLinkCount[ConstFive.THREE] > 0)
            {
                //Console.WriteLine("GetPoints-我成活4");
                return GetLinkToAPlay(arrMeLink[ConstFive.THREE][0], 3, 0);
            }
            //判断我方可否成44
            arrTemp = FindWill44(arrMeLink, arrMeLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0)
            {
                //Console.WriteLine("GetPoints-我成44");
                return arrTemp;
            }
            //判断我方可否成43
            arrTemp = FindWill43(arrMeLink, arrMeLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0 && arrEnemyLinkCount[ConstFive.STHREE] + arrEnemyLinkCount[ConstFive.THREE] == 0)
            {
                return arrTemp;
            }
            else if (intTempSum > 0)
            {
                for (int i = 0; i < intTempSum; i++)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                }
            }
            //判断敌方可否成活4
            if (arrEnemyLinkCount[ConstFive.THREE] > 0 && arrMeLinkCount[ConstFive.STHREE] == 0)
            {
                //Console.WriteLine("GetPoints-敌成活4");
                return GetLinkToAPlay3(arrEnemyLink[ConstFive.THREE][0], 3);
            }
            //判断敌方可否成44
            arrTemp = FindWill44(arrEnemyLink, arrEnemyLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0)
            {
                //Console.WriteLine("GetPoints-敌成44");
                for (int i = 0; i < intTempSum; i++)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                }
            }
            //判断敌方可否成43
            arrTemp = FindWill43(arrEnemyLink, arrEnemyLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0)
            {
                for (int i = 0; i < intTempSum; i++)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                }
            }
            else if (arrEnemyLinkCount[ConstFive.THREE] > 0)
            {
                for (int j = 0; j < arrEnemyLinkCount[ConstFive.THREE]; j++)
                {
                    arrTemp = GetLinkToAPlay3(arrEnemyLink[ConstFive.THREE][j], 3);
                    for (int i = 0; i < intTempSum; i++)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                    }
                }
            }
            //判断我方可否成33
            arrTemp = FindWill33(arrMeLink, arrMeLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0 && arrEnemyLinkCount[ConstFive.STHREE] + arrEnemyLinkCount[ConstFive.THREE] == 0)
            {
                return arrTemp;
            }
            else if (intTempSum > 0)
            {
                for (int i = 0; i < intTempSum; i++)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                }
            }
            //判断敌方可否成33
            arrTemp = FindWill33(arrEnemyLink, arrEnemyLinkCount);
            intTempSum = arrTemp[arrTemp.Length - 1][0];
            if (intTempSum > 0)
            {
                for (int i = 0; i < intTempSum; i++)
                {
                    JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                }
            }
            //判断我方是否冲4
            if (arrMeLinkCount[ConstFive.STHREE] > 0)
            {
                for (int j = 0; j < arrMeLinkCount[ConstFive.STHREE]; j++)
                {
                    arrTemp = GetLinkToAPlay(arrMeLink[ConstFive.STHREE][j], 3, 1);
                    intTempSum = arrTemp[arrTemp.Length - 1][0];
                    for (int i = 0; i < intTempSum; i++)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                    }
                }
            }
            //判断敌方是否冲4
            if (arrEnemyLinkCount[ConstFive.STHREE] > 0)
            {
                for (int j = 0; j < arrEnemyLinkCount[ConstFive.STHREE]; j++)
                {
                    arrTemp = GetLinkToAPlay(arrEnemyLink[ConstFive.STHREE][0], 3, 1);
                    intTempSum = arrTemp[arrTemp.Length - 1][0];
                    for (int i = 0; i < intTempSum; i++)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                    }
                }
            }
            //判断我方是否成活3
            if (arrMeLinkCount[ConstFive.TWO] > 0)
            {
                for (int j = 0; j < arrMeLinkCount[ConstFive.TWO]; j++)
                {
                    arrTemp = GetLinkToAPlay(arrMeLink[ConstFive.TWO][0], 2, 1);
                    intTempSum = arrTemp[arrTemp.Length - 1][0];
                    for (int i = 0; i < intTempSum; i++)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                    }
                }
            }
            //判断敌方是否成活3
            if (arrEnemyLinkCount[ConstFive.TWO] > 0)
            {
                for (int j = 0; j < arrEnemyLinkCount[ConstFive.TWO]; j++)
                {
                    arrTemp = GetLinkToAPlay(arrEnemyLink[ConstFive.TWO][0], 2, 1);
                    intTempSum = arrTemp[arrTemp.Length - 1][0];
                    for (int i = 0; i < intTempSum; i++)
                    {
                        JoinPointsArray(arrPoints, ref intPointsSum, arrTemp[i]);
                    }
                }
            }
            AddAllPoints(arrPoints, ref intPointsSum);
            arrPoints[199] = new int[] { intPointsSum, -1 };
            return arrPoints;
        }


        private int[][] FindWillN(int[][][] arrSameLink, int intSameLinkSum, int intLink, int intCompactness, bool repeat)
        {
            int[][] result = new int[50][];
            int resultSum = 0;
            if (intSameLinkSum > 0)
            {
                if (repeat)
                {
                    for (int i = 0; i < intSameLinkSum; i++)
                    {
                        int[][] temp = GetLinkToAPlay(arrSameLink[i], intLink, intCompactness);
                        int tempSum = temp[temp.Length - 1][0];
                        for (int j = 0; j < tempSum; j++)
                        {
                            result[resultSum] = temp[j];
                            resultSum++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < intSameLinkSum; i++)
                    {
                        int[][] temp = GetLinkToAPlay(arrSameLink[i], intLink, intCompactness);
                        int tempSum = temp[temp.Length - 1][0];
                        for (int j = 0; j < tempSum; j++)
                        {
                            JoinPointsArray(result, ref resultSum, temp[j]);
                        }
                    }
                }
            }
            result[49] = new int[2] { resultSum, -1 };
            return result;
        }


        private int[][] FindEnemyWill4(int[][][] arrSameLink, int intSameLinkSum, int intLink, bool repeat)
        {
            int[][] result = new int[50][];
            int resultSum = 0;
            if (intSameLinkSum > 0)
            {
                if (repeat)
                {
                    for (int i = 0; i < intSameLinkSum; i++)
                    {
                        int[][] temp = GetLinkToAPlay3(arrSameLink[i], intLink);
                        int tempSum = temp[temp.Length - 1][0];
                        for (int j = 0; j < tempSum; j++)
                        {
                            result[resultSum] = temp[j];
                            resultSum++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < intSameLinkSum; i++)
                    {
                        int[][] temp = GetLinkToAPlay3(arrSameLink[i], intLink);
                        int tempSum = temp[temp.Length - 1][0];
                        for (int j = 0; j < tempSum; j++)
                        {
                            JoinPointsArray(result, ref resultSum, temp[j]);
                        }
                    }
                }
            }
            result[49] = new int[2] { resultSum, -1 };
            return result;
        }


        private int[][] FindWillFIVE(int[][][][] arrLink, int[] arrLinkCount)
        {
            int int4Sum = arrLinkCount[ConstFive.FOUR];
            int intS4Sum = arrLinkCount[ConstFive.SFOUR];
            int[][] will5 = new int[10][];
            int will5Sum = 0;
            if (int4Sum + intS4Sum > 0)
            {
                for (int i = 0; i < int4Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.FOUR][i], 4, 0);
                    for (int j = 0; j < temp[temp.Length - 1][0]; j++)
                    {
                        JoinPointsArray(will5, ref will5Sum, temp[j]);
                    }
                }
                for (int i = 0; i < intS4Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.SFOUR][i], 4, 0);
                    for (int j = 0; j < temp[temp.Length - 1][0]; j++)
                    {
                        JoinPointsArray(will5, ref will5Sum, temp[j]);
                    }
                }
            }
            will5[9] = new int[2] { will5Sum, -1 };
            return will5;
        }


        private int[][] FindWillVCT(int[][][][] arrLink, int[] arrLinkCount)
        {
            int[][] arrWillVCT = new int[30][];
            int intWillVCTSum = 0;

            int intLink3Sum = arrLinkCount[ConstFive.THREE];
            int intLinkS3Sum = arrLinkCount[ConstFive.STHREE];
            int intLink2Sum = arrLinkCount[ConstFive.TWO];
            if (intLink3Sum > 0)
            {
                for (int i = 0; i < intLink3Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay3(arrLink[ConstFive.THREE][i], 3);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        JoinPointsArray(arrWillVCT, ref intWillVCTSum, temp[j]);
                    }
                }
            }
            if (intLinkS3Sum > 0)
            {
                for (int i = 0; i < intLinkS3Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.STHREE][i], 3, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        JoinPointsArray(arrWillVCT, ref intWillVCTSum, temp[j]);
                    }
                }
            }
            if (intLink2Sum > 0)
            {
                for (int i = 0; i < intLink2Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.TWO][i], 2, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        JoinPointsArray(arrWillVCT, ref intWillVCTSum, temp[j]);
                    }
                }
            }
            arrWillVCT[29] = new int[] { intWillVCTSum, -1 };
            return arrWillVCT;
        }


        private int[][] FindWillVCF(int[][][][] arrLink, int[] arrLinkCount)
        {
            int[][] arrWillVCF = new int[30][];
            int intWillVCFSum = 0;

            int intLink3Sum = arrLinkCount[ConstFive.THREE];
            int intLinkS3Sum = arrLinkCount[ConstFive.STHREE];
            if (intLink3Sum > 0)
            {
                for (int i = 0; i < intLink3Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay3(arrLink[ConstFive.THREE][i], 3);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        JoinPointsArray(arrWillVCF, ref intWillVCFSum, temp[j]);
                    }
                }
            }
            if (intLinkS3Sum > 0)
            {
                for (int i = 0; i < intLinkS3Sum; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.STHREE][i], 3, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        JoinPointsArray(arrWillVCF, ref intWillVCFSum, temp[j]);
                    }
                }
            }
            arrWillVCF[29] = new int[] { intWillVCFSum, -1 };
            return arrWillVCF;
        }


        private int[][] FindWill44(int[][][][] arrLink, int[] arrLinkCount)
        {
            int[][] will44 = new int[10][];
            int will44Sum = 0;
            int[][] arrAll = new int[30][];
            int intAllSum = 0;
            if (arrLinkCount[ConstFive.STHREE] > 2)
            {
                for (int i = 0; i < arrLinkCount[ConstFive.STHREE]; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.STHREE][i], 3, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        arrAll[intAllSum] = temp[j];
                        intAllSum++;
                    }
                }
                for (int i = 0; i < intAllSum; i++)
                {
                    for (int j = i + 1; j < intAllSum; j++)
                    {
                        if (arrAll[j][0] == arrAll[i][0] && arrAll[j][1] == arrAll[i][1])
                        {
                            JoinPointsArray(will44, ref will44Sum, arrAll[j]);
                        }
                    }
                }
            }
            will44[9] = new int[] { will44Sum, -1 };
            return will44;
        }


        private int[][] FindWill43(int[][][][] arrLink, int[] arrLinkCount)
        {
            int[][] will43 = new int[20][];
            int will43Sum = 0;
            int[][] arrAll4 = new int[30][];
            int intAll4Sum = 0;
            int[][] arrAll3 = new int[50][];
            int intAll3Sum = 0;
            if (arrLinkCount[ConstFive.STHREE] > 1 && arrLinkCount[ConstFive.TWO] > 1)
            {
                for (int i = 0; i < arrLinkCount[ConstFive.STHREE]; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.STHREE][i], 3, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        arrAll4[intAll4Sum] = temp[j];
                        intAll4Sum++;
                    }
                }
                for (int i = 0; i < arrLinkCount[ConstFive.TWO]; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.TWO][i], 2, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        arrAll3[intAll3Sum] = temp[j];
                        intAll3Sum++;
                    }
                }
                for (int i = 0; i < intAll4Sum; i++)
                {
                    for (int j = 0; j < intAll3Sum; j++)
                    {
                        if (arrAll4[i][0] == arrAll3[j][0] && arrAll4[i][1] == arrAll3[j][1])
                        {
                            JoinPointsArray(will43, ref will43Sum, arrAll3[j]);
                        }
                    }
                }
            }
            will43[19] = new int[] { will43Sum, -1 };
            return will43;
        }


        private int[][] FindWill33(int[][][][] arrLink, int[] arrLinkCount)
        {
            int[][] will33 = new int[20][];
            int will33Sum = 0;
            int[][] arrAll = new int[50][];
            int intAllSum = 0;
            if (arrLinkCount[ConstFive.TWO] > 2)
            {
                for (int i = 0; i < arrLinkCount[ConstFive.TWO]; i++)
                {
                    int[][] temp = GetLinkToAPlay(arrLink[ConstFive.TWO][i], 2, 1);
                    int tempSum = temp[temp.Length - 1][0];
                    for (int j = 0; j < tempSum; j++)
                    {
                        arrAll[intAllSum] = temp[j];
                        intAllSum++;
                    }
                }
                for (int i = 0; i < intAllSum; i++)
                {
                    for (int j = i + 1; j < intAllSum; j++)
                    {
                        if (arrAll[j][0] == arrAll[i][0] && arrAll[j][1] == arrAll[i][1])
                        {
                            JoinPointsArray(will33, ref will33Sum, arrAll[i]);
                        }
                    }
                }
            }
            will33[19] = new int[] { will33Sum, -1 };
            return will33;
        }


        private int[][] GetLinkToAPlay3(int[][] arrALink, int intLink)
        {
            int[][] temp = new int[10][];
            int tempSum = 0;
            int x = arrALink[1][0] - arrALink[0][0];
            int y = arrALink[1][1] - arrALink[0][1];
            if (Math.Abs(x) != 1 && x != 0) { x = x / Math.Abs(x); }
            if (Math.Abs(y) != 1 && y != 0) { y = y / Math.Abs(y); }
            for (int i = 1; i < intLink; i++)
            {
                if (arrALink[i][0] - arrALink[i - 1][0] == 2 * x && arrALink[i][1] - arrALink[i - 1][1] == 2 * y)
                {
                    temp[tempSum] = new int[] { arrALink[i][0] - x, arrALink[i][1] - y };
                    tempSum++;
                }
            }
            if (GetSign(arrALink[0][0] - x, arrALink[0][1] - y) == 0)
            {
                temp[tempSum] = new int[] { arrALink[0][0] - x, arrALink[0][1] - y };
                tempSum++;
            }
            if (GetSign(arrALink[intLink - 1][0] + x, arrALink[intLink - 1][1] + y) == 0)
            {
                temp[tempSum] = new int[] { arrALink[intLink - 1][0] + x, arrALink[intLink - 1][1] + y };
                tempSum++;
            }
            //if (tempSum == 0) 
            //{
            //    MessageBox.Show("！！！！"); 
            //}
            temp[9] = new int[] { tempSum, -1 };
            return temp;
        }


        //intCompactness参数规定走子的紧密度
        private int[][] GetLinkToAPlay(int[][] arrALink, int intLink, int intCompactness)
        {
            int[][] arrAPlay = new int[10][];
            int intAPlaySum = 0;
            int x = 0;
            int y = 0;
            if (intLink != 1)
            {
                x = arrALink[1][0] - arrALink[0][0];
                y = arrALink[1][1] - arrALink[0][1];
                int intAbsX = Math.Abs(x);
                int intAbsY = Math.Abs(y);
                if (intAbsX != 1 && x != 0) { x = x / intAbsX; }
                if (intAbsY != 1 && y != 0) { y = y / intAbsY; }
            }
            else { }
            int space = 0;
            for (int i = 1; i < intLink; i++)
            {
                int spaceX = arrALink[i][0] - arrALink[i - 1][0];
                int spaceY = arrALink[i][1] - arrALink[i - 1][1];
                if (spaceX != x || spaceY != y)
                {
                    int thisSpace = spaceX == 0 ? spaceY / y - 1 : spaceX / x - 1;
                    space += thisSpace;
                    for (int j = 1; j <= thisSpace; j++)
                    {
                        arrAPlay[intAPlaySum] = new int[] { arrALink[i][0] - j * x, arrALink[i][1] - j * y };
                        intAPlaySum++;
                    }
                }
            }
            if (space <= intCompactness)
            {
                space++;
                if (GetSign(arrALink[0][0] - x, arrALink[0][1] - y) == ConstFive.SPACE_SIGN)
                {
                    arrAPlay[intAPlaySum] = new int[] { arrALink[0][0] - x, arrALink[0][1] - y };
                    intAPlaySum++;
                    if (space <= intCompactness && GetSign(arrALink[0][0] - x * 2, arrALink[0][1] - y * 2) == ConstFive.SPACE_SIGN)
                    {
                        arrAPlay[intAPlaySum] = new int[] { arrALink[0][0] - x * 2, arrALink[0][1] - y * 2 };
                        intAPlaySum++;
                    }
                }
                if (GetSign(arrALink[intLink - 1][0] + x, arrALink[intLink - 1][1] + y) == ConstFive.SPACE_SIGN)
                {
                    arrAPlay[intAPlaySum] = new int[] { arrALink[intLink - 1][0] + x, arrALink[intLink - 1][1] + y };
                    intAPlaySum++;
                    if (space <= intCompactness && GetSign(arrALink[intLink - 1][0] + x * 2, arrALink[intLink - 1][1] + y * 2) == ConstFive.SPACE_SIGN)
                    {
                        arrAPlay[intAPlaySum] = new int[] { arrALink[intLink - 1][0] + x * 2, arrALink[intLink - 1][1] + y * 2 };
                        intAPlaySum++;
                    }
                }
            }
            arrAPlay[9] = new int[] { intAPlaySum, -1 };
            return arrAPlay;

        }


        private int GetSign(int x, int y)
        {
            int sign = 0;
            if (x > ConstFive.B_MAX_X || x < ConstFive.B_MIN_X || y > ConstFive.B_MAX_Y || y < ConstFive.B_MIN_Y) 
            {
                sign = -1; 
            }
            else
            {
                sign = arrGame[x, y];
            }
            return sign;
        }


        //去重入数组
        private void JoinPointsArray(int[][] arrPoints, ref int intPointsSum, int[] arrPoint)
        {
            bool blnJoin = true;
            for (int i = 0; i < intPointsSum; i++)
            {
                if (arrPoint[0] == arrPoints[i][0] && arrPoint[1] == arrPoints[i][1])
                {
                    blnJoin = false;
                    break;
                }
            }
            if (blnJoin)
            {
                arrPoints[intPointsSum] = arrPoint;
                intPointsSum++;
            }
        }

    }
}

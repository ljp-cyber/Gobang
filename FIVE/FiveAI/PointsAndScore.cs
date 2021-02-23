using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PointsAndScore
    {
        SearchGoodPoints SGP;
        private int[][][][] arrMeLink;
        private int[] arrMeLinkCount;
        private int[][][][] arrEnemyLink;
        private int[] arrEnemyLinkCount;

        private int[,] arrGame;
        private int intMeSign;
        private int intEnemySign;
        private int intNext;
        private List<int[]> listAllPlayed;

        public PointsAndScore(int[,] arrGame, int intMeSign, List<int[]> listAllPlayed, int intNext)
        {
            this.arrGame = arrGame;
            this.intMeSign = intMeSign;
            this.intEnemySign = this.intMeSign == ConstFive.BLACK_SIGN ? ConstFive.WHITE_SIGN : ConstFive.BLACK_SIGN;
            this.intNext = intNext;
            this.listAllPlayed = listAllPlayed;
            GetLinkArray();
            if (intNext == intMeSign)
            {
                SGP = new SearchGoodPoints(arrGame, intMeSign, listAllPlayed, arrMeLink, arrMeLinkCount, arrEnemyLink, arrEnemyLinkCount);
            }
            else
            {
                SGP = new SearchGoodPoints(arrGame, intEnemySign, listAllPlayed, arrEnemyLink, arrEnemyLinkCount, arrMeLink, arrMeLinkCount);
            }
        }


        public void SetNewData(int intNext)
        {
            this.intNext = intNext;
            GetLinkArray();
            if (intNext == intMeSign)
            {
                SGP.SetNewData(arrGame, intMeSign, listAllPlayed, arrMeLink, arrMeLinkCount, arrEnemyLink, arrEnemyLinkCount);
            }
            else
            {
                SGP.SetNewData(arrGame, intEnemySign, listAllPlayed, arrEnemyLink, arrEnemyLinkCount, arrMeLink, arrMeLinkCount);
            }
        }


        public int GetSituationScore()
        {
            int intMeScore = GetScore(arrMeLinkCount, arrEnemyLinkCount, intMeSign == intNext ? true : false);
            int intEnemyScore = GetScore(arrEnemyLinkCount, arrMeLinkCount, intEnemySign == intNext ? true : false);
            int intSituationScore = intMeScore - intEnemyScore;
            return intSituationScore;
        }


        public int[][] GetAllPoints()
        {
            return SGP.GetAllPoints();
        }


        public int[][] GetSomePoints(int willLink,bool isMe)
        {
            return SGP.GetSomePoints(willLink, isMe);
        }

        /// <summary>
        /// 从寻找棋型类获取所有棋型表
        /// </summary>
        private void GetLinkArray()
        {
            SearchChessType search = new SearchChessType(listAllPlayed, intMeSign);
            arrMeLink = search.GetMeLinkArray();
            arrMeLinkCount = search.GetMeLinkArrayCount();
            arrEnemyLink = search.GetEnemyLinkArray();
            arrEnemyLinkCount = search.GetEnemyLinkArrayCount();
        }


         private int GetScore(int[] arrLinkArray1Count, int[] arrLinkArray2Count, bool isNext)
        {
            int willWin = 0;
            int will_4_ = 0;
            if (isNext == true) 
            { 
                willWin = 100000; 
            }
            if (isNext == true && arrLinkArray2Count[ConstFive.FIVE] + arrLinkArray2Count[ConstFive.SFOUR] + arrLinkArray2Count[ConstFive.FOUR] == 0)
            { 
                will_4_ = 100000; 
            }
            int score = 0;
            score += arrLinkArray1Count[ConstFive.SONE] * 1;
            score += arrLinkArray1Count[ConstFive.ONE] * 2;
            score += arrLinkArray1Count[ConstFive.STWO] * 10;
            score += arrLinkArray1Count[ConstFive.TWO] * 100;
            score += arrLinkArray1Count[ConstFive.STHREE] * 100;
            score += arrLinkArray1Count[ConstFive.THREE] * (1000 + will_4_);
            score += arrLinkArray1Count[ConstFive.SFOUR] * (1000 + willWin);
            score += arrLinkArray1Count[ConstFive.FOUR] * (100000 + willWin);
            score += arrLinkArray1Count[ConstFive.FIVE] * 1000000;
            return score;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class SearchChessType_Test
    {
        private int intMeSign;
        private int intEnemySign;
        private int intSpaceSign;
        private int[,] arrGameArray;

        private int[][] arrMeArray;
        private int intMeArraySum;
        private int[][] arrEnemyArray;
        private int intEnemyArraySum;

        private int[][][][] arrLinkArray;
        private int[] arrLinkArrayCount; 

        private const int LINK110_=0;
        private const int LINK1_0_ = 1;
        private const int LINK210_0_ = 2;
        private const int LINK2100_ = 3;
        private const int LINK2_0_0_ = 4;
        private const int LINK2_00_ = 5;
        private const int LINK3100_0_ = 6;
        private const int LINK31000_ = 7;
        private const int LINK3_00_0_ = 8;
        private const int LINK3_000_ = 9;
        private const int LINK41000_0_ = 10;
        private const int LINK410000_ = 11;
        private const int LINK4_000_0_ = 12;
        private const int LINK4_0000_ = 13;
        private const int LINK500000 = 14;
        private const int LINK50000_0 = 15;
        private const int LINK5000_00 = 16;


        public SearchChessType_Test(int[,] arrGameArray, int[][] arrMeArray, int intMeArraySum, int[][] arrEnemyArray, int intEnemyArraySum, int intMeSign)
        {
            this.intMeSign = intMeSign;
            if (this.intMeSign == 1) { this.intEnemySign = 2; }
            else { this.intEnemySign = 1; }
            this.intSpaceSign = 0;
            this.arrGameArray = arrGameArray;

            this.arrMeArray = arrMeArray;
            this.intMeArraySum = intMeArraySum;
            this.arrEnemyArray = arrEnemyArray;
            this.intEnemyArraySum = intEnemyArraySum;
        }
        public void SetNewDate(int[,] arrGameArray, int[][] arrMeArray, int intMeArraySum, int[][] arrEnemyArray, int intEnemyArraySum, int intMeSign)
        {
            this.intMeSign = intMeSign;
            if (this.intMeSign == 1) { this.intEnemySign = 2; }
            else { this.intEnemySign = 1; }
            this.intSpaceSign = 0;
            this.arrGameArray = arrGameArray;

            this.arrMeArray = arrMeArray;
            this.intMeArraySum = intMeArraySum;
            this.arrEnemyArray = arrEnemyArray;
            this.intEnemyArraySum = intEnemyArraySum;
        }
        public void GoToSearch(int Sign)
        {
            if (Sign == intMeSign)
            {
                Initialization();
                SearchByDirection(arrMeArray, intMeArraySum, 1);
                SearchByDirection(arrMeArray, intMeArraySum, 2);
                SearchByDirection(arrMeArray, intMeArraySum, 3);
                SearchByDirection(arrMeArray, intMeArraySum, 4);
            }
            else
            {
                Initialization();
                if (intMeSign == 2) { this.intMeSign = 1; this.intEnemySign = 2; }
                else { this.intMeSign = 2; this.intEnemySign = 1; }
                SearchByDirection(arrEnemyArray, intEnemyArraySum, 1);
                SearchByDirection(arrEnemyArray, intEnemyArraySum, 2);
                SearchByDirection(arrEnemyArray, intEnemyArraySum, 3);
                SearchByDirection(arrEnemyArray, intEnemyArraySum, 4);
                if (intMeSign == 1) { this.intMeSign = 2; this.intEnemySign = 1; }
                else { this.intMeSign = 1; this.intEnemySign = 2; }
            }
        }
        public int[][][][] GetLinkArray()
        {
            return arrLinkArray;
        }
        public int[] GetLinkArrayCount()
        {
            return arrLinkArrayCount;
        }


        private void SearchByDirection(int[][] arrPlayerArray, int arrPlayerArraySum, int intDirection)
        {
            int[] arrUsed = new int[37];
            int intUsedSum = 0;
            int[][] arrTemp = new int[19][];
            int intTempSum = 0;
            for (int i = 0; i < arrPlayerArraySum; i++)
            {
                int intThisUsed = TheSameLineFeature(arrPlayerArray[i][0], arrPlayerArray[i][1], intDirection);
                bool blnIsUsed = false;
                for (int a = 0; a < intUsedSum; a++)
                {
                    if (intThisUsed == arrUsed[a])
                    {
                        blnIsUsed = true;
                        break;
                    }
                }
                if (blnIsUsed == false)
                {
                    arrUsed[intUsedSum] = intThisUsed;
                    intUsedSum++;
                    arrTemp[intTempSum] = new int[] { arrPlayerArray[i][0], arrPlayerArray[i][1] };
                    intTempSum++;
                    for (int j = i + 1; j < arrPlayerArraySum; j++)
                    {
                        if (TheSameLineFeature(arrPlayerArray[j][0], arrPlayerArray[j][1], intDirection) == intThisUsed)
                        {
                            arrTemp[intTempSum] = new int[] { arrPlayerArray[j][0], arrPlayerArray[j][1] };
                            intTempSum++;
                        }
                    }
                    if (intTempSum >= 1)
                    {
                        arrTemp = SortByWhich(arrTemp, intTempSum, intDirection);
                        IsLink(arrTemp, intTempSum, intDirection);
                    }
                    arrTemp = new int[19][];
                    intTempSum = 0;
                }
            }
        }
        private int[][] SortByWhich(int[][] array, int count, int direction)
        {
            int which = 1;
            if (direction == 2) which = 0;
            //根据数组的二维第which个进行升序排序
            for (int i = 1; i < count; i++)
            {
                if (array[i][which] < array[i - 1][which])
                {
                    int j = i - 1;
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    while (j >= 0 && temp[which] < array[j][which])
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }
        private void IsLink(int[][] arrLineArray, int intLineArraySum,int intDirection)
        {
            bool go = true;
            int[][] arrLink = new int[10][];
            int link = 0;
            int space = 0;
            int afterSpaceLink = 0;
            int lastspacestart = -1;
            int[] arrThis = new int[2];
            int[] arrLast = new int[2];
            int[] arrSpace = new int[2];
            arrThis[0] = arrLineArray[0][0];
            arrThis[1] = arrLineArray[0][1];
            arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
            link++;
            arrLast[0] = arrLineArray[0][0];
            arrLast[1] = arrLineArray[0][1];
            for (int i = 1; i <= intLineArraySum; i++)
            {
                if (i != intLineArraySum)
                {
                    arrThis[0] = arrLineArray[i][0];
                    arrThis[1] = arrLineArray[i][1];
                    if (link == 4 && space == 1) { go = false; }
                    else if (link == 5) { go = false; }
                    else
                    {
                        int thisSpace = GetSpace(arrThis, arrLast, intDirection);
                        if (thisSpace == 2)
                        {
                            int[] temp = GetNeighbor(arrThis, -1, 1, intDirection);
                            if (GetSign(temp) == intSpaceSign)
                            {
                                space++;
                                if (space == 1) 
                                {
                                    arrSpace = temp;
                                    lastspacestart = i; 
                                }
                                if (space == 2) { go = false; }
                            }
                            else
                            {
                                go = false;
                            }
                        }
                        else if (thisSpace >= 3)
                        {
                            go = false;
                        }
                    }

                }
                else { go = false; }
                if (go == true)
                {
                    if (space != 0) { afterSpaceLink++; }
                    arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                    link++;
                    arrLast[0] = arrLineArray[i][0];
                    arrLast[1] = arrLineArray[i][1];
                }
                else
                {
                    int[] arrTou = arrLink[0];
                    int[] arrWei = arrLink[link - 1];
                    int[] arrTou1 = GetNeighbor(arrTou, -1, 1, intDirection);
                    int[] arrTou2 = GetNeighbor(arrTou, -1, 2, intDirection);
                    int[] arrTou3 = GetNeighbor(arrTou, -1, 3, intDirection);
                    int[] arrWei1 = GetNeighbor(arrWei, 1, 1, intDirection);
                    int[] arrWei2 = GetNeighbor(arrWei, 1, 2, intDirection);
                    int[] arrWei3 = GetNeighbor(arrWei, 1, 3, intDirection);
                    int intTou1Sign = GetSign(arrTou1);
                    int intTou2Sign = GetSign(arrTou2);
                    int intTou3Sign = GetSign(arrTou3);
                    int intWei1Sign = GetSign(arrWei1);
                    int intWei2Sign = GetSign(arrWei2);
                    int intWei3Sign = GetSign(arrWei3);
                    //这个canlink判断能不能连到五
                    int canlink = link;
                    //有没有空格
                    bool havespace = false;
                    if (space != 0) { havespace = true; }
                    if (havespace == true) { canlink++; }
                    //头尾通不通
                    bool _0_ = false;
                    bool tou1 = false;
                    bool wei1 = false;
                    if (intTou1Sign != intEnemySign) { tou1 = true; }
                    if (intWei1Sign != intEnemySign) { wei1 = true; }
                    if (tou1 == true && wei1 == true) { _0_ = true; }
                    if (tou1 == true) { canlink++; }
                    if (wei1 == true) { canlink++; }
                    //能不能连到五
                    bool tou2 = false;
                    bool wei2 = false;
                    bool tou3 = false;
                    bool wei3 = false;
                    if (tou1 == true && intTou2Sign != intEnemySign) { tou2 = true; }
                    if (tou2 == true && intTou3Sign != intEnemySign) { tou3 = true; }
                    if (wei1 == true && intWei2Sign != intEnemySign) { wei2 = true; }
                    if (wei2 == true && intWei3Sign != intEnemySign) { wei3 = true; }
                    if (tou2 == true) { canlink++; }
                    if (wei2 == true) { canlink++; }
                    if (tou3 == true) { canlink++; }
                    if (wei3 == true) { canlink++; }
                    if (link == 1 && canlink < 5)
                    {
                        int[] arrTou4 = GetNeighbor(arrTou, -1, 4, intDirection);
                        int[] arrWei4 = GetNeighbor(arrWei, 1, 4, intDirection);
                        if (tou3 == true && GetSign(arrTou4) != intEnemySign) { canlink++; }
                        if (wei3 == true && GetSign(arrWei4) != intEnemySign) { canlink++; }
                    }
                    if (canlink >= 5)
                    {
                        //把比较好的走法加进数组
                        int intGoodPlay = 5;
                        if (havespace)
                        {
                            arrLink[intGoodPlay] = arrSpace; intGoodPlay++;
                            if (intTou1Sign == intSpaceSign)
                            {
                                arrLink[intGoodPlay] = arrTou1; intGoodPlay++;
                            }
                            if (intWei1Sign == intSpaceSign)
                            {
                                arrLink[intGoodPlay] = arrWei1; intGoodPlay++;
                            }
                        }
                        else
                        {
                            if (intTou1Sign == intSpaceSign)
                            {
                                arrLink[intGoodPlay] = arrTou1; intGoodPlay++;
                            }
                            if (intWei1Sign == intSpaceSign)
                            {
                                arrLink[intGoodPlay] = arrWei1; intGoodPlay++;
                                if (intWei2Sign == intSpaceSign)
                                {
                                    arrLink[intGoodPlay] = arrWei2; intGoodPlay++;
                                }
                            }
                            if (intTou1Sign == intSpaceSign && intTou2Sign == intSpaceSign)
                            {
                                arrLink[intGoodPlay] = arrTou2; intGoodPlay++;
                            }
                        }
                        if (intGoodPlay == 5) 
                        {
                            MessageBox.Show("!!");
                        }
                        arrLink[9] = new int[] { intGoodPlay, 0 };
                        //是不是无敌带空格5连
                        //if (link == 5 && havespace == true)
                        //{
                        //    if ((afterSpaceLink == 4 && wei1 == true) || (afterSpaceLink == 1 && tou1 == true))
                        //        _0_ = true;
                        //}
                        if (link == 1) { arrLink[1] = new int[] { intDirection, -1 }; }
                        JoinLinkArray(link, havespace, _0_, arrLink);
                    }
                    if (i != intLineArraySum)
                    {
                        //重新开始判断
                        if (lastspacestart != -1 && (intWei1Sign == intMeSign || intWei2Sign == intMeSign))
                        {
                            i = lastspacestart;
                        }

                        go = true;
                        space = 0;
                        arrLink = new int[10][];
                        arrSpace = new int[2];
                        link = 0;
                        lastspacestart = -1;
                        afterSpaceLink = 0;
                        arrThis[0] = arrLineArray[i][0];
                        arrThis[1] = arrLineArray[i][1];
                        arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                        link++;
                        arrLast[0] = arrLineArray[i][0];
                        arrLast[1] = arrLineArray[i][1];
                    }

                }
            }
        }
        private void JoinLinkArray(int link, bool havespace, bool _0_, int[][] templink)
        {
            switch (link)
            {
                case 1:
                    if (_0_ == false)
                    {
                        arrLinkArray[LINK110_][arrLinkArrayCount[LINK110_]] = templink;
                        arrLinkArrayCount[LINK110_] += 1;

                    }
                    else
                    {
                        arrLinkArray[LINK1_0_][arrLinkArrayCount[LINK1_0_]] = templink;
                        arrLinkArrayCount[LINK1_0_] += 1;
                    }
                    break;
                case 2:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK210_0_][arrLinkArrayCount[LINK210_0_]] = templink;
                            arrLinkArrayCount[LINK210_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK2100_][arrLinkArrayCount[LINK2100_]] = templink;
                            arrLinkArrayCount[LINK2100_] += 1;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK2_0_0_][arrLinkArrayCount[LINK2_0_0_]] = templink;
                            arrLinkArrayCount[LINK2_0_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK2_00_][arrLinkArrayCount[LINK2_00_]] = templink;
                            arrLinkArrayCount[LINK2_00_] += 1;
                        }
                    }
                    break;
                case 3:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK3100_0_][arrLinkArrayCount[LINK3100_0_]] = templink;
                            arrLinkArrayCount[LINK3100_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK31000_][arrLinkArrayCount[LINK31000_]] = templink;
                            arrLinkArrayCount[LINK31000_] += 1;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK3_00_0_][arrLinkArrayCount[LINK3_00_0_]] = templink;
                            arrLinkArrayCount[LINK3_00_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK3_000_][arrLinkArrayCount[LINK3_000_]] = templink;
                            arrLinkArrayCount[LINK3_000_] += 1;
                        }
                    }
                    break;
                case 4:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK41000_0_][arrLinkArrayCount[LINK41000_0_]] = templink;
                            arrLinkArrayCount[LINK41000_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK410000_][arrLinkArrayCount[LINK410000_]] = templink;
                            arrLinkArrayCount[LINK410000_] += 1;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            arrLinkArray[LINK4_000_0_][arrLinkArrayCount[LINK4_000_0_]] = templink;
                            arrLinkArrayCount[LINK4_000_0_] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK4_0000_][arrLinkArrayCount[LINK4_0000_]] = templink;
                            arrLinkArrayCount[LINK4_0000_] += 1;
                        }
                    }
                    break;
                case 5:
                    if (havespace == true)
                    {
                        if (_0_ == true)
                        {
                            arrLinkArray[LINK50000_0][arrLinkArrayCount[LINK50000_0]] = templink;
                            arrLinkArrayCount[LINK50000_0] += 1;
                        }
                        else
                        {
                            arrLinkArray[LINK5000_00][arrLinkArrayCount[LINK5000_00]] = templink;
                            arrLinkArrayCount[LINK5000_00] += 1;
                        }
                    }
                    else
                    {
                        arrLinkArray[LINK500000][arrLinkArrayCount[LINK500000]] = templink;
                        arrLinkArrayCount[LINK500000] += 1;
                    }
                    break;
            }
        }
        private void Initialization()
        {
            arrLinkArray = new int[17][][][];
            arrLinkArray[0] = new int[30][][];
            arrLinkArray[1] = new int[30][][];
            arrLinkArray[2] = new int[20][][];
            arrLinkArray[3] = new int[20][][];
            arrLinkArray[4] = new int[20][][];
            arrLinkArray[5] = new int[20][][];
            arrLinkArray[6] = new int[20][][];
            arrLinkArray[7] = new int[20][][];
            arrLinkArray[8] = new int[10][][];
            arrLinkArray[9] = new int[10][][];
            arrLinkArray[10] = new int[5][][];
            arrLinkArray[11] = new int[5][][];
            arrLinkArray[12] = new int[5][][];
            arrLinkArray[13] = new int[5][][];
            arrLinkArray[14] = new int[5][][];
            arrLinkArray[15] = new int[5][][];
            arrLinkArray[16] = new int[5][][];
            arrLinkArrayCount = new int[17];

        }


        private int GetSign(int x, int y)
        {
            int sign = 0;
            if (x > 18 || x < 0 || y > 18 || y < 0) { sign = -1; }
            else
            {
                sign = arrGameArray[x, y];
            }
            return sign;
        }
        private int GetSign(int[] Coordinate)
        {
            int sign = 0;
            int x=Coordinate[0];
            int y=Coordinate[1];
            if (x > 18 || x < 0 || y > 18 || y < 0) { sign = intEnemySign; }
            else
            {
                sign = arrGameArray[x, y];
            }
            return sign;
        }
        private int GetSpace(int thisX, int thisY, int lastX, int lastY, int direction)
        {
            int space=0;
            switch (direction)
            {
                case 1: space = thisY - lastY; break;
                case 2: space = thisX - lastX; break;
                case 3: space = thisY - lastY; break;
                case 4: space = thisY - lastY; break;
            }
            return space;
        }
        private int GetSpace(int[] arrThis, int[] arrLast, int direction)
        {
            int thisX = arrThis[0];
            int thisY = arrThis[1];
            int lastX = arrLast[0];
            int lastY = arrLast[1];
            int space = 0;
            switch (direction)
            {
                case 1: space = thisY - lastY; break;
                case 2: space = thisX - lastX; break;
                case 3: space = thisY - lastY; break;
                case 4: space = thisY - lastY; break;
            }
            return space;
        }
        private int[] GetNeighbor(int[] lastCoordinate, int topdown, int number, int direction)
        {
            int[] newCoordinate = new int[2] { lastCoordinate[0], lastCoordinate[1] };
            switch (direction)
            {
                case 1: newCoordinate[1] = newCoordinate[1] + number * topdown; break;
                case 2: newCoordinate[0] = newCoordinate[0] + number * topdown; break;
                case 3:
                    newCoordinate[0] = newCoordinate[0] + number * topdown;
                    newCoordinate[1] = newCoordinate[1] + number * topdown;
                    break;
                case 4:
                    newCoordinate[0] = newCoordinate[0] - number * topdown;
                    newCoordinate[1] = newCoordinate[1] + number * topdown;
                    break;
            }
            return newCoordinate;
        }
        private int TheSameLineFeature(int x, int y, int direction)
        {
            int temp = 0;
            switch (direction)
            {
                case 1: temp = x; break;
                case 2: temp = y; break;
                case 3: temp = x - y; break;
                case 4: temp = x + y; break;
            }
            return temp;
        }
    }
}

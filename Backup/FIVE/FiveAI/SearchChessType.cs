using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class SearchChessType
    {
        private int intMeSign;
        private List<int[]> listAllPlay;

        private int[][][][] arrMeLink;
        private List<List<int[][]>> lstMeLink;
        private int[] arrMeLinkCount;
        private int[][][][] arrEnemyLink;
        private List<List<int[][]>> lstEnemyLink;
        private int[] arrEnemyLinkCount;

        public SearchChessType(List<int[]> listAllPlay, int intMeSign)
        {
            this.listAllPlay = listAllPlay;
            this.intMeSign = intMeSign;
            Initialization();
            SearchByDirection(1);
            SearchByDirection(2);
            SearchByDirection(3);
            SearchByDirection(4);
        }
        public int[] GetMeLinkArrayCount()
        {
            return arrMeLinkCount;
        }
        public int[] GetEnemyLinkArrayCount()
        {
            return arrEnemyLinkCount;
        }
        public int[][][][] GetMeLinkArray()
        {
            return arrMeLink;
        }
        public List<List<int[][]>> GetMeLinkList()
        {
            return lstMeLink;
        }
        public int[][][][] GetEnemyLinkArray()
        {
            return arrEnemyLink;
        }
        public List<List<int[][]>> GetEnemyLinkList()
        {
            return lstEnemyLink;
        }

        private void Initialization()
        {
            arrMeLinkCount=new int[9];
            arrEnemyLinkCount = new int[9];
            arrMeLink = new int[9][][][];
            arrEnemyLink = new int[9][][][];

            arrEnemyLink[0] = new int[2][][];
            arrEnemyLink[1] = new int[5][][];
            arrEnemyLink[2] = new int[5][][];
            arrEnemyLink[3] = new int[10][][];
            arrEnemyLink[4] = new int[15][][];
            arrEnemyLink[5] = new int[20][][];
            arrEnemyLink[6] = new int[30][][];
            arrEnemyLink[7] = new int[30][][];
            arrEnemyLink[8] = new int[50][][]; 
            
            arrMeLink[0] = new int[2][][];
            arrMeLink[1] = new int[5][][];
            arrMeLink[2] = new int[5][][];
            arrMeLink[3] = new int[10][][];
            arrMeLink[4] = new int[15][][];
            arrMeLink[5] = new int[20][][];
            arrMeLink[6] = new int[30][][];
            arrMeLink[7] = new int[30][][];
            arrMeLink[8] = new int[50][][];

            lstMeLink = new List<List<int[][]>>();
            lstEnemyLink = new List<List<int[][]>>();
            for (int i = 0; i < 9; i++)
            {
                lstMeLink.Add(new List<int[][]>());
                lstEnemyLink.Add(new List<int[][]>());
            }
        }
        private void JoinLinkArray(int[][] arrLink,int link,bool isSleep,int Sign)
        {
            int[] tempLinkCount;
            int[][][][] temp2Link;
            List<List<int[][]>> tempLink;
            if (Sign == intMeSign)
            {
                tempLink = lstMeLink;
                tempLinkCount = arrMeLinkCount;
                temp2Link = arrMeLink;
            }
            else
            {
                tempLink = lstEnemyLink;
                tempLinkCount = arrEnemyLinkCount;
                temp2Link = arrEnemyLink;
            }
            switch (link)
            {
                case 1:
                    if (isSleep == true)
                    {
                        tempLink[ConstFive.SONE].Add(arrLink);
                        temp2Link[ConstFive.SONE][tempLinkCount[ConstFive.SONE]] = arrLink;
                        tempLinkCount[ConstFive.SONE]++;
                    }
                    else
                    {
                        tempLink[ConstFive.ONE].Add(arrLink);
                        temp2Link[ConstFive.ONE][tempLinkCount[ConstFive.ONE]] = arrLink;
                        tempLinkCount[ConstFive.ONE]++;
                    }
                    break;
                case 2:
                    if (isSleep == true)
                    {

                        tempLink[ConstFive.STWO].Add(arrLink);
                        temp2Link[ConstFive.STWO][tempLinkCount[ConstFive.STWO]] = arrLink;
                        tempLinkCount[ConstFive.STWO]++;
                    }
                    else
                    {
                        tempLink[ConstFive.TWO].Add(arrLink);
                        temp2Link[ConstFive.TWO][tempLinkCount[ConstFive.TWO]] = arrLink;
                        tempLinkCount[ConstFive.TWO]++;
                    }
                    break;
                case 3:
                    if (isSleep == true)
                    {
                        tempLink[ConstFive.STHREE].Add(arrLink);
                        temp2Link[ConstFive.STHREE][tempLinkCount[ConstFive.STHREE]] = arrLink;
                        tempLinkCount[ConstFive.STHREE]++;
                    }
                    else
                    {
                        tempLink[ConstFive.THREE].Add(arrLink);
                        temp2Link[ConstFive.THREE][tempLinkCount[ConstFive.THREE]] = arrLink;
                        tempLinkCount[ConstFive.THREE]++;
                    } 
                    break;
                case 4:
                    if (isSleep == true)
                    {
                        tempLink[ConstFive.SFOUR].Add(arrLink);
                        temp2Link[ConstFive.SFOUR][tempLinkCount[ConstFive.SFOUR]] = arrLink;
                        tempLinkCount[ConstFive.SFOUR]++;
                    }
                    else
                    {
                        tempLink[ConstFive.FOUR].Add(arrLink);
                        temp2Link[ConstFive.FOUR][tempLinkCount[ConstFive.FOUR]] = arrLink;
                        tempLinkCount[ConstFive.FOUR]++;
                    } 
                    break;
                case 5:
                    tempLink[ConstFive.FIVE].Add(arrLink);
                    temp2Link[ConstFive.FIVE][tempLinkCount[ConstFive.FIVE]] = arrLink;
                    tempLinkCount[ConstFive.FIVE]++;
                    break;
            }
        }
        private void JoinLinkArray(int link, bool isSleep, int Sign)
        {
            int[] tempLinkCount;
            if (Sign == intMeSign)
            {
                tempLinkCount = arrMeLinkCount;
            }
            else
            {
                tempLinkCount = arrEnemyLinkCount;
            }
            switch (link)
            {
                case 1:
                    if (isSleep == true)
                    {
                        tempLinkCount[ConstFive.SONE]++;
                    }
                    else
                    {
                        tempLinkCount[ConstFive.ONE]++;
                    }
                    break;
                case 2:
                    if (isSleep == true)
                    {
                        tempLinkCount[ConstFive.STWO]++;
                    }
                    else
                    {
                        tempLinkCount[ConstFive.TWO]++;
                    }
                    break;
                case 3:
                    if (isSleep == true)
                    {
                        tempLinkCount[ConstFive.STHREE]++;
                    }
                    else
                    {
                        tempLinkCount[ConstFive.THREE]++;
                    }
                    break;
                case 4:
                    if (isSleep == true)
                    {
                        tempLinkCount[ConstFive.SFOUR]++;
                    }
                    else
                    {
                        tempLinkCount[ConstFive.FOUR]++;
                    }
                    break;
                case 5:
                    tempLinkCount[ConstFive.FIVE]++;
                    break;
            }
        }

        private void SearchByDirection(int intDirection)
        {
            List<int> used = new List<int>();
            List<int[]> line = new List<int[]>();
            for (int i = 0; i < listAllPlay.Count; i++)
            {
                int intThisUsed = TheSameLineFeature(listAllPlay[i][0], listAllPlay[i][1], intDirection);
                bool blnIsUsed = false;
                for (int a = 0; a < used.Count; a++)
                {
                    if (intThisUsed == used[a])
                    {
                        blnIsUsed = true;
                        break;
                    }
                } 
                if (blnIsUsed == false)
                {
                    used.Add(intThisUsed);
                    line.Add(new int[] { listAllPlay[i][0], listAllPlay[i][1], listAllPlay[i][2] });
                    for (int j = i + 1; j < listAllPlay.Count; j++)
                    {
                        if (TheSameLineFeature(listAllPlay[j][0], listAllPlay[j][1], intDirection) == intThisUsed)
                        {
                            JoinLineList(line, new int[] { listAllPlay[j][0], listAllPlay[j][1], listAllPlay[j][2] }, intDirection);
                        }
                    }
                    if (line.Count >= 1)
                    {
                        IsLink(line, intDirection);
                    }
                    line = new List<int[]>();
                }
            }
        }
        private void IsLink(List<int[]> line, int intDirection)
        {
            int lineCount = line.Count;//列表的长度

            bool go = true;
            int thisSign = -1;


            int[][] arrLink = new int[10][];
            int[] arrThis = new int[2];
            int[] arrLast = new int[2];
            int[] arrLeft =new int[2];
            int[] arrRight = new int[2];
            int link = 0;
            int space = 0;
            int canlink = 0;
            bool tou = true;
            bool wei = true;


            int lastspacestart = -1;
            int afterSpaceLink = 0;
            int afterSpaceSpace = 0;


            int a = 0;
            int first = 0;//从哪开始

            while (canlink < 5)
            {
                arrThis[0] = line[a][0];
                arrThis[1] = line[a][1];
                thisSign = line[a][2];
                if (a - 1 < 0)
                {
                    arrLeft = GetLeft(arrThis, intDirection);
                }
                else
                {
                    arrLeft[0] = line[a - 1][0];
                    arrLeft[1] = line[a - 1][1];
                }
                a++;
                first = a;
                while (a < lineCount && line[a][2] == thisSign)
                {
                    a++;
                }
                if (a < lineCount)
                {
                    arrRight = new int[] { line[a][0], line[a][1] };
                    canlink = GetSpace(arrRight, arrLeft, intDirection);
                }
                else
                {
                    arrRight = GetRight(arrThis, intDirection);
                    canlink = GetSpace(arrRight, arrLeft, intDirection);
                    break;
                }
            }
            if (canlink >= 5)
            {
                if(GetSpace(arrThis,arrLeft,intDirection)<=0)
                {
                    tou = false;
                }
                arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                link++;
                arrLast[0] = arrThis[0];
                arrLast[1] = arrThis[1];

                bool change = false;
                for (int i = first; i < lineCount; i++)
                {
                    arrThis[0] = line[i][0];
                    arrThis[1] = line[i][1];
                    int thisSpace = GetSpace(arrThis, arrLast, intDirection);
                    if (line[i][2] == thisSign)
                    {
                        //调试代码
                        if (arrThis[0] == 11 && arrThis[1] == 11)
                        {
 
                        }
                        //tiaoshi
                        if (thisSpace > 0)
                        {
                            space += thisSpace;
                            if (link + space >= 5)
                            {
                                go = false;
                            }
                            else
                            {
                                if (lastspacestart != -1)
                                {
                                    afterSpaceSpace += 1;
                                }
                                else if (lastspacestart == -1)
                                {
                                    lastspacestart = i;
                                }
                            }
                        }
                        else
                        {
                            if (link + space >= 5)
                            {
                                go = false;
                            }
                        }
                    }
                    else
                    {
                        go = false;
                        change = true;
                    }


                    if (go == true)
                    {
                        if (lastspacestart != -1) { afterSpaceLink++; }
                        arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                        link++;
                        arrLast[0] = arrThis[0];
                        arrLast[1] = arrThis[1];
                    }
                    else
                    {
                        //加入统计数组
                        if (change == true && thisSpace <= 0)
                        {
                            wei = false;
                        }
                        if (change != true)
                        {
                            space -= thisSpace;
                        }

                        bool sleep = true;
                        if (tou && wei && canlink > 5 && space + link <= 4)
                        {
                            sleep = false;
                        }

                        JoinLinkArray(arrLink,link, sleep, thisSign);
                        //写haole。。。。。。

                        //重新开始判断
                        tou = true;
                        wei = true;
                        if (change == true)
                        {
                            a = i;
                            do
                            {
                                arrThis[0] = line[a][0];
                                arrThis[1] = line[a][1];
                                thisSign = line[a][2];
                                arrLeft[0] = line[a - 1][0];
                                arrLeft[1] = line[a - 1][1];
                                first = a;
                                a++;
                                while (a < lineCount && line[a][2] == thisSign)
                                {
                                    a++;
                                }
                                if (a < lineCount)
                                {
                                    arrRight = new int[] { line[a][0], line[a][1] };
                                    canlink = GetSpace(arrRight, arrLeft, intDirection);
                                }
                                else
                                {
                                    arrRight = GetRight(arrThis, intDirection);
                                    canlink = GetSpace(arrRight, arrLeft, intDirection);
                                    break;
                                }
                            } while (canlink < 5);
                            if (canlink >= 5)
                            {
                                i = first;
                                if (GetSpace(arrThis, arrLeft, intDirection) <= 0)
                                {
                                    tou = false;
                                }
                            }
                            else
                            {
                                link = 0;
                                break;
                            }
                        }
                        else if (lastspacestart != -1 && i < lineCount - 1)
                        {
                            if (afterSpaceLink + afterSpaceSpace + thisSpace < 5)
                            {
                                i = lastspacestart;
                                arrThis[0] = line[i][0];
                                arrThis[1] = line[i][1];
                            }
                        }
                        change = false;
                        lastspacestart = -1;
                        afterSpaceLink = 0;
                        afterSpaceSpace = 0;
                        go = true;
                        arrLink = new int[10][];
                        link = 0;
                        space = 0;

                        arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                        link++;
                        arrLast[0] = arrThis[0];
                        arrLast[1] = arrThis[1];

                    }
                }
                if (link != 0)
                {
                    wei = GetSpace(arrRight, arrLast, intDirection) > 0 ? true : false;
                    bool sleepEnd = true;
                    if (tou && wei && canlink > 5 && space + link <= 4)
                    {
                        sleepEnd = false;
                    }
                    JoinLinkArray(arrLink, link, sleepEnd, thisSign);
                }
            }
        }


        private void JoinLineList(List<int[]> line, int[] one, int intDirection)
        {
            int i = 0;
            int t = line.Count;
            switch (intDirection)
            {
                case 1:
                    while (i < t && one[1] > line[i][1])
                    {
                        i++;
                    }
                    break;
                case 2:
                    while (i < t && one[0] > line[i][0])
                    {
                        i++;
                    }
                    break;
                case 3:
                    while (i < t && one[1] > line[i][1])
                    {
                        i++;
                    }
                    break;
                case 4:
                    while (i < t && one[1] > line[i][1])
                    {
                        i++;
                    }
                    break;
            }
            line.Insert(i, one);
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
            return space - 1;
        }
        private int[] GetLeft(int[] arrThis,int direction)
        {
            int x = arrThis[0];
            int y = arrThis[1];
            int[] temp = new int[2];
            switch (direction)
            {
                case 1:
                    temp[0] = x;
                    temp[1] = ConstFive.B_MIN_Y-1;
                    break;
                case 2:
                    temp[0] = ConstFive.B_MIN_X-1;
                    temp[1] = y; 
                    break;
                case 3:
                    int a = x > y ? y : x;
                    temp[0] = x - a - 1;
                    temp[1] = y - a - 1;
                    break;
                case 4:
                    temp[0] = x + y + 1;
                    temp[1] = 0 - 1;
                    break;
            }
            return temp;
        }
        private int[] GetRight(int[] arrThis, int direction)
        {
            int[] temp = new int[2]; 
            int x = arrThis[0];
            int y = arrThis[1];
            switch (direction)
            {
                case 1:
                    temp[0] = arrThis[0];
                    temp[1] = ConstFive.B_MAX_Y+1;
                    break;
                case 2:
                    temp[0] = ConstFive.B_MAX_X+1;
                    temp[1] = arrThis[1];
                    break;
                case 3:
                    int a = x > y ? ConstFive.B_MAX_X - x : ConstFive.B_MAX_Y - y;
                    temp[0] = x + a + 1;
                    temp[1] = y + a + 1;
                    break;
                case 4:
                    temp[0] = 0 - 1;
                    temp[1] = x + y + 1;
                    break;
            }
            return temp;
        }
    }
}

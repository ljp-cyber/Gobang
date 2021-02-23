using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class SearchChessType
    {
        private int intMeSign;//我方标识
        private List<int[]> listAllPlay;//走期记录

        private int[][][][] arrMeLink;//我方基本棋型记录表，四维应的九种基本棋型、出现次数、具体棋子、xy坐标
        private List<List<int[][]>> lstMeLink;
        private int[] arrMeLinkCount;//我方九种基本棋型出现次数
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

        /// <summary>
        /// 初始化九种棋型存储统计数组
        /// </summary>
        private void Initialization()
        {
            arrMeLinkCount=new int[9];//我方对应的九种基本棋型统计出现次数
            arrEnemyLinkCount = new int[9];//敌方对应的九种基本棋型统计出现次数
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

        /// <summary>
        /// 每个下过棋的格子，往四个方向每个线条查找线条上所有棋子的列表
        /// </summary>
        /// <param name="intDirection">四个方向之一</param>
        private void SearchByDirection(int intDirection)
        {
            List<int> used = new List<int>();//已经搜寻过的线条
            List<int[]> line = new List<int[]>();
            for (int i = 0; i < listAllPlay.Count; i++)
            {
                //判断有没有搜寻过此线条
                int intThisUsed = TheSameLineFeature(listAllPlay[i][0], listAllPlay[i][1], intDirection);//线条标识
                bool blnIsUsed = false;
                for (int a = 0; a < used.Count; a++)
                {
                    if (intThisUsed == used[a])
                    {
                        blnIsUsed = true;
                        break;
                    }
                }
                //如果没有搜寻过继续
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

        /// <summary>
        /// 根据一个线条上所有子排序的坐标适配棋型，头尾无阻挡、可连空间大于等于6、连子小于等于4是活子
        /// </summary>
        /// <param name="line">一个线条上所有子排序的坐标</param>
        /// <param name="intDirection">四个方向之一</param>
        private void IsLink(List<int[]> line, int intDirection)
        {
            int lineCount = line.Count;//列表的长度、一行的连子数

            bool go = true;//有阻挡或换色、结束一轮搜索
            int thisSign = -1;//当前颜色标识


            int[][] arrLink = new int[10][];//成连数组
            int[] arrThis = new int[2];//当前棋子坐标
            int[] arrLast = new int[2];//上一个棋子坐标
            int[] arrLeft =new int[2];//上一个阻挡坐标
            int[] arrRight = new int[2];//上一个阻挡坐标
            int link = 0;//当前几连
            int space = 0;//空格数量
            int canlink = 0;//是否连5空间
            bool tou = true;//前边是否阻挡
            bool wei = true;//后边是否阻挡

            //一个棋型有多个空格的情况，从上次有空格的地方开始历遍
            int lastspacestart = -1;//从上次有空格的地方开始历遍
            int afterSpaceLink = 0;//上次空格的后的连子数
            int afterSpaceSpace = 0;//上次空格的后的空格数


            int a = 0;//用一个变量向前预探看看是否可以有成五的空键
            int first = 0;//记录从哪开始变量，因为换色不成连问题

            //这个while向前预探判断有没有成五的空间
            while (canlink < 5)
            {
                arrThis[0] = line[a][0];
                arrThis[1] = line[a][1];
                thisSign = line[a][2];
                if (a - 1 < 0)//如果是第一个左边是边界
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
                while (a < lineCount && line[a][2] == thisSign)//直到遇到不同颜色或者最后一个子
                {
                    a++;
                }
                if (a < lineCount)//如果是最后一个右边是边界
                {
                    arrRight = new int[] { line[a][0], line[a][1] };
                    canlink = GetSpace(arrRight, arrLeft, intDirection);//如果没有成五继续下一轮前探
                }
                else
                {
                    arrRight = GetRight(arrThis, intDirection);
                    canlink = GetSpace(arrRight, arrLeft, intDirection);
                    break;//如果是最后一个跳出循环
                }
            }
            if (canlink >= 5)//如果都没有成五空间就可以结束啦
            {
                //判断前是否有阻挡
                if(GetSpace(arrThis,arrLeft,intDirection)<=0)
                {
                    tou = false;
                }
                //一个坐标记录入数组，开始下一个
                arrLink[link] = new int[2] { arrThis[0], arrThis[1] };
                link++;
                arrLast[0] = arrThis[0];
                arrLast[1] = arrThis[1];

                bool change = false;//颜色转变标识
                for (int i = first; i < lineCount; i++)
                {
                    arrThis[0] = line[i][0];
                    arrThis[1] = line[i][1];
                    int thisSpace = GetSpace(arrThis, arrLast, intDirection);//和上一个棋子的空格数量
                    if (line[i][2] == thisSign)//如果同色继续
                    {
                        //调试代码
                        if (arrThis[0] == 11 && arrThis[1] == 11)
                        {
 
                        }
                        //-----
                        if (thisSpace > 0)
                        {
                            space += thisSpace;
                            if (link + space >= 5)//如果空格和棋子数大于等于5，结束一轮搜索，继续下一颜色搜索
                            {
                                go = false;
                            }
                            else
                            {
                                if (lastspacestart != -1)//同一轮搜索多次出现空格，记录第一次出现空格的地方和上次空格数
                                {
                                    afterSpaceSpace += 1;
                                }
                                else if (lastspacestart == -1)
                                {
                                    lastspacestart = i;
                                }
                            }
                        }
                        else//无空格
                        {
                            if (link + space >= 5)//如果空格和棋子数大于等于5，结束搜索，继续下一颜色搜索
                            {
                                go = false;
                            }
                        }
                    }
                    else//不同色就结束搜索，继续下一颜色搜索
                    {
                        go = false;
                        change = true;
                    }


                    if (go == true)//如果一轮结束加入数组
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
                        //判断是否为眠棋型
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

        /// <summary>
        /// 根据不同的方向，把棋子坐标按顺序插入相应的位置
        /// </summary>
        /// <param name="line"></param>
        /// <param name="one"></param>
        /// <param name="intDirection"></param>
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

        /// <summary>
        /// 计算同一条直线上的标识、一条线上的是一样的
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 一条直线上两个连续的子之间的空间、一般用于判断有没有成五的空间
        /// </summary>
        /// <param name="arrThis"></param>
        /// <param name="arrLast"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 当前坐标直线到左边界的坐标
        /// </summary>
        /// <param name="arrThis"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 当前坐标直线到右边界的坐标
        /// </summary>
        /// <param name="arrThis"></param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
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

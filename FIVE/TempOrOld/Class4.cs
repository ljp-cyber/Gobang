using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Class4
    {
        private int[,] gamearray;
        private int[][] player1array=new int[50][];
        private int[][] player2array = new int[50][];
        private int intMeSign;
        private int intEnemySign;
        private int player1number;
        private int player2number;


        private int[][][][] linkarray = new int[14][][][];
        private int[] linkNUMarray=new int[14];
        private int[][][][] melinkarray = new int[14][][][];
        private int[] melinkNUMarray = new int[14];
        private int[][][][] enemylinkarray = new int[14][][][];
        private int[] enemylinkNUMarray = new int[14];

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

        private int numberlink210_0_ = 0;
        private int numberlink2100_ = 0;
        private int numberlink2_0_0_ = 0;
        private int numberlink2_00_ = 0;
        private int numberlink3100_0_ = 0;
        private int numberlink31000_ = 0;
        private int numberlink3_00_0_ = 0;
        private int numberlink3_000_ = 0;
        private int numberlink41000_0_ = 0;
        private int numberlink410000_ = 0;
        private int numberlink4_000_0_ = 0;
        private int numberlink4_0000_ = 0;
        private int numberlink50000_0 = 0;
        private int numberlink500000 = 0;

        public Class4(int[,] gamearray, int intMeSign, int[][] player1array, int[][] player2array, int player1number, int player2number)
        {
            this.gamearray = gamearray;
            this.player1number = player1number;
            this.player2number = player2number;
            this.player1array = player1array;
            this.player2array = player2array;
            this.intMeSign = intMeSign;
            if (this.intMeSign == 1) { this.intEnemySign = 2; }
            else { this.intEnemySign = 1; }
            Initialization();
            go1(player1array, player1number);
            go2(player1array, player1number);
            go3(player1array, player1number);
            go4(player1array, player1number);
            melinkarray = linkarray;
            melinkNUMarray = linkNUMarray;
            Initialization();
            this.intMeSign = 1; this.intEnemySign = 2;
            go1(player2array, player2number);
            go2(player2array, player2number);
            go3(player2array, player2number);
            go4(player2array, player2number);
            enemylinkarray = linkarray;
            enemylinkNUMarray = linkNUMarray;
            //Initialization();
            this.intMeSign = 2; this.intEnemySign = 1;
            
            //{
            //    go1(player2array, player2number);
            //    go2(player2array, player2number);
            //    go3(player2array, player2number);
            //    go4(player2array, player2number);
            //    melinkarray = linkarray;
            //    melinkNUMarray = linkNUMarray;
            //    Initialization();
            //    this.intMeSign = 1; this.intEnemySign = 2;
            //    go1(player1array, player1number);
            //    go2(player1array, player1number);
            //    go3(player1array, player1number);
            //    go4(player1array, player1number);
            //    enemylinkarray = linkarray;
            //    enemylinkNUMarray = linkNUMarray;
            //    Initialization();
            //    this.intMeSign = 2; this.intEnemySign = 1;
            //}
            //MessageBox.Show("我方：2:" + melinkNUMarray[0] + ", 2:" + melinkNUMarray[1]
            //    + ", 2:" + melinkNUMarray[2] + ", 2:" + melinkNUMarray[3]
            //    + ", 3:" + melinkNUMarray[4] + ", 3:" + melinkNUMarray[5]
            //    + ", 3:" + melinkNUMarray[6] + ", 3:" + melinkNUMarray[7]
            //    + ", 4:" + melinkNUMarray[8] + ", 4:" + melinkNUMarray[9]
            //    + ", 4:" + melinkNUMarray[10] + ", 4:" + melinkNUMarray[11]
            //    + ", 5:" + melinkNUMarray[12] + ", 5:" + melinkNUMarray[13]);
            //MessageBox.Show("敌方：2:" + enemylinkNUMarray[0] + ", 2:" + enemylinkNUMarray[1]
            //    + ", 2:" + enemylinkNUMarray[2] + ", 2:" + enemylinkNUMarray[3]
            //    + ", 3:" + enemylinkNUMarray[4] + ", 3:" + enemylinkNUMarray[5]
            //    + ", 3:" + enemylinkNUMarray[6] + ", 3:" + enemylinkNUMarray[7]
            //    + ", 4:" + enemylinkNUMarray[8] + ", 4:" + enemylinkNUMarray[9]
            //    + ", 4:" + enemylinkNUMarray[10] + ", 4:" + enemylinkNUMarray[11]
            //    + ", 5:" + enemylinkNUMarray[12] + ", 5:" + enemylinkNUMarray[13]);
        }

        public int[][][][] GetEnemyLinkArray()
        {
            return enemylinkarray;
        }

        public int[] GetEnemyLinkArrayCount()
        {
            return enemylinkNUMarray;
        }

        public int[][][][] GetMeLinkArray()
        {
            return melinkarray;
        }

        public int[] GetMeLinkArrayCount()
        {
            return melinkNUMarray;
        }


        private void go1(int[][] playerarray, int playernumber)
        {
            int[] used=new int[19];
            int usedNUM = 0;
            int[][] temp=new int[19][];
            int tempNUM=0;
            for (int i = 0; i < playernumber; i++)
            {
                bool isused = false;
                for (int a = 0; a < usedNUM; a++)
                {
                    if (playerarray[i][0] == used[a])
                    {
                        isused = true;
                        break;
                    }
                }
                if (isused == false)
                {
                    used[usedNUM] = playerarray[i][0];
                    usedNUM++;
                    temp[tempNUM] = new int[] { playerarray[i][0], playerarray[i][1] };
                    tempNUM++;
                    for (int j = i + 1; j < playernumber; j++)
                    {
                        if (used[usedNUM-1] == playerarray[j][0])
                        {
                            temp[tempNUM] = new int[] { playerarray[j][0], playerarray[j][1] };
                            tempNUM++;
                        }
                    }
                    if (tempNUM >= 2)
                    {
                        temp = sort1(temp, tempNUM);
                        IsLink1(temp, tempNUM);
                    }
                    temp = new int[19][];
                    tempNUM = 0;
                }
            }
        }

        private void go2(int[][] playerarray, int playernumber)
        {
            int[] used = new int[19];
            int usedNUM = 0;
            int[][] temp = new int[19][];
            int tempNUM = 0;
            for (int i = 0; i < playernumber; i++)
            {
                bool isused = false;
                for (int a = 0; a < usedNUM; a++)
                {
                    if (playerarray[i][1] == used[a])
                    {
                        isused = true;
                        break;
                    }
                }
                if (isused == false)
                {
                    used[usedNUM] = playerarray[i][1];
                    usedNUM++;
                    temp[tempNUM] = new int[] { playerarray[i][0], playerarray[i][1] };
                    tempNUM++;
                    for (int j = i + 1; j < playernumber; j++)
                    {
                        if (used[usedNUM - 1] == playerarray[j][1])
                        {
                            temp[tempNUM] = new int[] { playerarray[j][0], playerarray[j][1] };
                            tempNUM++;
                        }
                    }
                    if (tempNUM >= 2)
                    {
                        temp = sort2(temp, tempNUM);
                        IsLink2(temp, tempNUM);
                    }
                    temp = new int[19][];
                    tempNUM = 0;
                }
            }
        }

        private void go3(int[][] playerarray, int playernumber)
        {
            int[] used = new int[37];
            int usedNUM = 0;
            int[][] temp = new int[19][];
            int tempNUM = 0;
            for (int i = 0; i < playernumber; i++)
            {
                bool isused = false;
                for (int a = 0; a < usedNUM; a++)
                {
                    if (playerarray[i][0] - playerarray[i][1] == used[a])
                    {
                        isused = true;
                        break;
                    }
                }
                if (isused == false)
                {
                    used[usedNUM] = playerarray[i][0] - playerarray[i][1];
                    usedNUM++;
                    temp[tempNUM] = new int[] { playerarray[i][0], playerarray[i][1] };
                    tempNUM++;
                    for (int j = i + 1; j < playernumber; j++)
                    {
                        if (used[usedNUM - 1] == playerarray[j][0] - playerarray[j][1])
                        {
                            temp[tempNUM] = new int[] { playerarray[j][0], playerarray[j][1] };
                            tempNUM++;
                        }
                    }
                    if (tempNUM >= 2)
                    {
                        temp = sort3(temp, tempNUM);
                        IsLink3(temp, tempNUM);
                    }
                    temp = new int[19][];
                    tempNUM = 0;
                }
            }
        }

        private void go4(int[][] playerarray, int playernumber)
        {
            int[] used = new int[37];
            int usedNUM = 0;
            int[][] temp = new int[19][];
            int tempNUM = 0;
            for (int i = 0; i < playernumber; i++)
            {
                bool isused = false;
                for (int a = 0; a < usedNUM; a++)
                {
                    if (playerarray[i][0] + playerarray[i][1] == used[a])
                    {
                        isused = true;
                        break;
                    }
                }
                if (isused == false)
                {
                    used[usedNUM] = playerarray[i][0] + playerarray[i][1];
                    usedNUM++;
                    temp[tempNUM] = new int[] { playerarray[i][0], playerarray[i][1] };
                    tempNUM++;
                    for (int j = i + 1; j < playernumber; j++)
                    {
                        if (used[usedNUM - 1] == playerarray[j][0] + playerarray[j][1])
                        {
                            temp[tempNUM] = new int[] { playerarray[j][0], playerarray[j][1] };
                            tempNUM++;
                        }
                    }
                    if (tempNUM >= 2)
                    {
                        temp = sort4(temp, tempNUM);
                        IsLink4(temp, tempNUM);
                    }
                    temp = new int[19][];
                    tempNUM = 0;
                }
            }
        }

        private int[][] sort2(int[][] array,int count)
        {
            for (int i = 1; i < count; i++)
            {
                if (array[i][0] < array[i - 1][0])
                {
                    int j = i - 1;
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    while (j >= 0 && temp[0] < array[j][0])
                    {
                        array[j+1] = array[j ];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        private int[][] sort1(int[][] array, int count)
        {
            for (int i = 1; i < count; i++)
            {
                if (array[i][1] < array[i - 1][1])
                {
                    int j = i - 1;
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    while (j>=0&&temp[1] < array[j][1])
                    {
                        array[j+1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        private int[][] sort3(int[][] array, int count)
        {
            for (int i = 1; i < count; i++)
            {
                if (array[i][1] < array[i - 1][1])
                {
                    int j = i - 1;
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    while (j >= 0 && temp[1] < array[j][1])
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        private int[][] sort4(int[][] array, int count)
        {
            for (int i = 1; i < count; i++)
            {
                if (array[i][1] < array[i - 1][1])
                {
                    int j = i - 1;
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    while (j >= 0 && temp[1] < array[j][1])
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        private void IsLink1(int[][] linklist,int linkNUM)
        {
            bool go = true;
            int link = 0;
            int space = 0;
            int[][] templink = new int[5][];
            int templinkNUM=0;
            bool tou1 = false;
            bool tou2 = false;
            bool tou3 = false;
            bool wei1 = false;
            bool wei2 = false;
            bool wei3 = false;
            int lastspacestart = -1;
            //int lastspaceend = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i == 0)
                {
                    //link++;
                    //templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    //templinkNUM++;
                    if (linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }
                }
                else
                {
                    if (link == 5 ) 
                    {
                        go = false;
                        if (linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 1] != intEnemySign)
                        {
                            wei1 = true;
                        }
                        if (linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                        {
                            wei2 = true;
                        }
                        if (linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                        {
                            wei3 = true;
                        }
                    }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 1) { }
                        else if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0], linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i ; }
                                if (space == 2)
                                {
                                    go = false;
                                    wei1 = true;
                                    wei2 = true;
                                    if (linklist[i][1] + 1 <= 18 && gamearray[linklist[i][0], linklist[i][1] + 1] != intEnemySign)
                                    {
                                        wei3 = true;
                                    }

                                }
                            }
                            else
                            {
                                go = false;
                                wei1 = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                            if (linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 1] != intEnemySign)
                            {
                                wei1 = true;
                            }
                            if (linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                            {
                                wei2 = true;
                            }
                            if (linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                            {
                                wei3 = true;
                            }
                        }
                    }
                }
                if (i == linkNUM - 1 && go == true) 
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i ][1] + 1 <= 18 && gamearray[linklist[i ][0], linklist[i ][1] + 1] != intEnemySign)
                    {
                        wei1 = true;
                    }
                    if (linklist[i ][1] + 2 <= 18 && gamearray[linklist[i ][0], linklist[i ][1] + 2] != intEnemySign && wei1 == true)
                    {
                        wei2 = true;
                    }
                    if (linklist[i ][1] + 3 <= 18 && gamearray[linklist[i ][0], linklist[i ][1] + 3] != intEnemySign && wei2 == true)
                    {
                        wei3 = true;
                    }
                    go = false;
                }
                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                }
                else
                {

                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (i != linkNUM - 1&&lastspacestart != -1 &&
                        ((linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 1] == intMeSign) ||
                        (linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0], linklist[i - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                        lastspacestart = -1;
                    }

                     go = true;
                     link = 0;
                     space = 0;
                     templink = new int[5][];
                     templinkNUM = 0;
                     tou1 = false;
                     tou2 = false;
                     tou3 = false;
                     wei1 = false;
                     wei2 = false;
                     wei3 = false;
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0], linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }

                }
            }
        }

        private void IsLink2(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int space = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            bool tou1 = false;
            bool tou2 = false;
            bool tou3 = false;
            bool wei1 = false;
            bool wei2 = false;
            bool wei3 = false;
            int lastspacestart = -1;
            //int lastspaceend = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i == 0)
                {
                    //link++;
                    //templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    //templinkNUM++;
                    if (linklist[i][0] - 1 >= 0 && gamearray[linklist[i][0]-1, linklist[i][1] ] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] - 2 >= 0 && gamearray[linklist[i][0]-2, linklist[i][1] ] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] - 3 >= 0 && gamearray[linklist[i][0]-3, linklist[i][1] ] != intEnemySign && tou2 == true) { tou3 = true; }
                }
                else
                {
                    if (link == 5)
                    {
                        go = false;
                        if (linklist[i - 1][0] + 1 <= 18 && gamearray[linklist[i - 1][0]+1, linklist[i - 1][1] ] != intEnemySign)
                        {
                            wei1 = true;
                        }
                        if (linklist[i - 1][0] + 2 <= 18 && gamearray[linklist[i - 1][0]+2, linklist[i - 1][1] ] != intEnemySign && wei1 == true)
                        {
                            wei2 = true;
                        }
                        if (linklist[i - 1][0] + 3 <= 18 && gamearray[linklist[i - 1][0]+3, linklist[i - 1][1] ] != intEnemySign && wei2 == true)
                        {
                            wei3 = true;
                        }
                    }
                    else
                    {
                        if (linklist[i][0] - linklist[i - 1][0] == 1) { }
                        else if (linklist[i][0] - linklist[i - 1][0] == 2)
                        {
                            if (gamearray[linklist[i][0]-1, linklist[i][1] ] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                    wei1 = true;
                                    wei2 = true;
                                    if (linklist[i][0] + 1 <= 18 && gamearray[linklist[i][0]+1, linklist[i][1] ] != intEnemySign)
                                    {
                                        wei3 = true;
                                    }

                                }
                            }
                            else
                            {
                                go = false;
                                wei1 = false;
                            }
                        }
                        else if (linklist[i][0] - linklist[i - 1][0] >= 3)
                        {
                            go = false;
                            if (linklist[i - 1][0] + 1 <= 18 && gamearray[linklist[i - 1][0]+1, linklist[i - 1][1] ] != intEnemySign)
                            {
                                wei1 = true;
                            }
                            if (linklist[i - 1][0] + 2 <= 18 && gamearray[linklist[i - 1][0]+2, linklist[i - 1][1] ] != intEnemySign && wei1 == true)
                            {
                                wei2 = true;
                            }
                            if (linklist[i - 1][0] + 3 <= 18 && gamearray[linklist[i - 1][0]+3, linklist[i - 1][1] ] != intEnemySign && wei2 == true)
                            {
                                wei3 = true;
                            }
                        }
                    }
                }
                if (i == linkNUM - 1 && go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] + 1 <= 18 && gamearray[linklist[i][0]+1, linklist[i][1] ] != intEnemySign)
                    {
                        wei1 = true;
                    }
                    if (linklist[i][0] + 2 <= 18 && gamearray[linklist[i][0]+2, linklist[i][1] ] != intEnemySign && wei1 == true)
                    {
                        wei2 = true;
                    }
                    if (linklist[i][0] + 3 <= 18 && gamearray[linklist[i][0]+3, linklist[i][1] ] != intEnemySign && wei2 == true)
                    {
                        wei3 = true;
                    }
                    go = false;
                }
                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                }
                else
                {

                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (lastspacestart != -1 &&
                        ((linklist[i - 1][0] + 1 <= 18 && gamearray[linklist[i - 1][0]+1, linklist[i - 1][1] ] == intMeSign) ||
                        (linklist[i - 1][0] + 2 <= 18 && gamearray[linklist[i - 1][0]+2, linklist[i - 1][1] ] == intMeSign)))
                    {
                        i = lastspacestart;
                        lastspacestart = -1;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    tou1 = false;
                    tou2 = false;
                    tou3 = false;
                    wei1 = false;
                    wei2 = false;
                    wei3 = false;
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] - 1 >= 0 && gamearray[linklist[i][0]-1, linklist[i][1] ] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] - 2 >= 0 && gamearray[linklist[i][0]-2, linklist[i][1] ] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] - 3 >= 0 && gamearray[linklist[i][0]-3, linklist[i][1] ] != intEnemySign && tou2 == true) { tou3 = true; }

                }
            }
        }

        private void IsLink3(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int space = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            bool tou1 = false;
            bool tou2 = false;
            bool tou3 = false;
            bool wei1 = false;
            bool wei2 = false;
            bool wei3 = false;
            int lastspacestart = -1;
            //int lastspaceend = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i == 0)
                {
                    //link++;
                    //templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    //templinkNUM++;
                    if (linklist[i][0] - 1 >= 0 && linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0]-1, linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] - 2 >= 0 && linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0]-2, linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] - 3 >= 0 && linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0]-3, linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }
                }
                else
                {
                    if (link == 5)
                    {
                        go = false;
                        if (linklist[i - 1][0] + 1 <= 18 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0]+1, linklist[i - 1][1] + 1] != intEnemySign)
                        {
                            wei1 = true;
                        }
                        if (linklist[i - 1][0] + 2 <= 18 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0]+2, linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                        {
                            wei2 = true;
                        }
                        if (linklist[i - 1][0] + 3 <= 18 && linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0]+3, linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                        {
                            wei3 = true;
                        }
                    }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 1) { }
                        else if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0]-1, linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                    wei1 = true;
                                    wei2 = true;
                                    if (linklist[i][0] + 1 <= 18 && linklist[i][1] + 1 <= 18 && gamearray[linklist[i][0]+1, linklist[i][1] + 1] != intEnemySign)
                                    {
                                        wei3 = true;
                                    }

                                }
                            }
                            else
                            {
                                go = false;
                                wei1 = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                            if (linklist[i - 1][0] + 1 <= 18 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0] + 1, linklist[i - 1][1] + 1] != intEnemySign)
                            {
                                wei1 = true;
                            }
                            if (linklist[i - 1][0] + 2 <= 18 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0] + 2, linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                            {
                                wei2 = true;
                            }
                            if (linklist[i - 1][0] + 3 <= 18 && linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0] + 3, linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                            {
                                wei3 = true;
                            }
                        }
                    }
                }
                if (i == linkNUM - 1 && go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] + 1 <= 18 && linklist[i][1] + 1 <= 18 && gamearray[linklist[i][0]+1, linklist[i][1] + 1] != intEnemySign)
                    {
                        wei1 = true;
                    }
                    if (linklist[i][0] + 2 <= 18 && linklist[i][1] + 2 <= 18 && gamearray[linklist[i][0]+2, linklist[i][1] + 2] != intEnemySign && wei1 == true)
                    {
                        wei2 = true;
                    }
                    if (linklist[i][0] + 3 <= 18 && linklist[i][1] + 3 <= 18 && gamearray[linklist[i][0]+3, linklist[i][1] + 3] != intEnemySign && wei2 == true)
                    {
                        wei3 = true;
                    }
                    go = false;
                }
                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                }
                else
                {

                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (i != linkNUM - 1 && lastspacestart != -1 &&
                        ((linklist[i - 1][0] + 1 <= 18 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0]+1, linklist[i - 1][1] + 1] == intMeSign) ||
                        (linklist[i - 1][0] + 2 <= 18 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0]+2, linklist[i - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                        lastspacestart = -1;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    tou1 = false;
                    tou2 = false;
                    tou3 = false;
                    wei1 = false;
                    wei2 = false;
                    wei3 = false;
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] - 1 >= 0 && linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0] - 1, linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] - 2 >= 0 && linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0] - 2, linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] - 3 >= 0 && linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0] - 3, linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }

                }
            }
        }

        private void IsLink4(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int space = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            bool tou1 = false;
            bool tou2 = false;
            bool tou3 = false;
            bool wei1 = false;
            bool wei2 = false;
            bool wei3 = false;
            int lastspacestart = -1;
            //int lastspaceend = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i == 0)
                {
                    //link++;
                    //templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    //templinkNUM++;
                    if (linklist[i][0] + 1 <= 18 && linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0] + 1, linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] + 2 <= 18 && linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0] + 2, linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] + 3 <= 18 && linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0] + 3, linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }
                }
                else
                {
                    if (link == 5)
                    {
                        go = false;
                        if (linklist[i - 1][0] - 1 >= 0 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0] - 1, linklist[i - 1][1] + 1] != intEnemySign)
                        {
                            wei1 = true;
                        }
                        if (linklist[i - 1][0] - 2 >= 0 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0] - 2, linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                        {
                            wei2 = true;
                        }
                        if (linklist[i - 1][0] - 3 >= 0 && linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0] - 3, linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                        {
                            wei3 = true;
                        }
                    }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 1) { }
                        else if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0] + 1, linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                    wei1 = true;
                                    wei2 = true;
                                    if (linklist[i][0] - 1 >= 0 && linklist[i][1] + 1 <= 18 && gamearray[linklist[i][0] - 1, linklist[i][1] + 1] != intEnemySign)
                                    {
                                        wei3 = true;
                                    }

                                }
                            }
                            else
                            {
                                go = false;
                                wei1 = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                            if (linklist[i - 1][0] - 1 >= 0 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0] - 1, linklist[i - 1][1] + 1] != intEnemySign)
                            {
                                wei1 = true;
                            }
                            if (linklist[i - 1][0] - 2 >= 0 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0] - 2, linklist[i - 1][1] + 2] != intEnemySign && wei1 == true)
                            {
                                wei2 = true;
                            }
                            if (linklist[i - 1][0] - 3 >= 0 && linklist[i - 1][1] + 3 <= 18 && gamearray[linklist[i - 1][0] - 3, linklist[i - 1][1] + 3] != intEnemySign && wei2 == true)
                            {
                                wei3 = true;
                            }
                        }
                    }
                }
                if (i == linkNUM - 1 && go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] - 1 >= 0 && linklist[i][1] + 1 <= 18 && gamearray[linklist[i][0] - 1, linklist[i][1] + 1] != intEnemySign)
                    {
                        wei1 = true;
                    }
                    if (linklist[i][0] - 2 >= 0 && linklist[i][1] + 2 <= 18 && gamearray[linklist[i][0] - 2, linklist[i][1] + 2] != intEnemySign && wei1 == true)
                    {
                        wei2 = true;
                    }
                    if (linklist[i][0] - 3 >= 0 && linklist[i][1] + 3 <= 18 && gamearray[linklist[i][0] - 3, linklist[i][1] + 3] != intEnemySign && wei2 == true)
                    {
                        wei3 = true;
                    }
                    go = false;
                }
                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                }
                else
                {

                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (i != linkNUM - 1 && lastspacestart != -1 &&
                        ((linklist[i - 1][0] - 1 >= 0 && linklist[i - 1][1] + 1 <= 18 && gamearray[linklist[i - 1][0] - 1, linklist[i - 1][1] + 1] == intMeSign) ||
                        (linklist[i - 1][0] - 2 >= 0 && linklist[i - 1][1] + 2 <= 18 && gamearray[linklist[i - 1][0] - 2, linklist[i - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                        lastspacestart = -1;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    tou1 = false;
                    tou2 = false;
                    tou3 = false;
                    wei1 = false;
                    wei2 = false;
                    wei3 = false;
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (linklist[i][0] + 1 <= 18 && linklist[i][1] - 1 >= 0 && gamearray[linklist[i][0] + 1, linklist[i][1] - 1] != intEnemySign) { tou1 = true; }
                    if (linklist[i][0] + 2 <= 18 && linklist[i][1] - 2 >= 0 && gamearray[linklist[i][0] + 2, linklist[i][1] - 2] != intEnemySign && tou1 == true) { tou2 = true; }
                    if (linklist[i][0] + 3 <= 18 && linklist[i][1] - 3 >= 0 && gamearray[linklist[i][0] + 3, linklist[i][1] - 3] != intEnemySign && tou2 == true) { tou3 = true; }

                }
            }
        }

        private void IsLink11(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int[][] templink = new int[8][];
            int templinkNUM = 0;
            int space = 0;
            int lastspacestart = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i > 0)
                {
                    if (link == 5) { go = false; }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0], linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                go = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                        }
                    }
                }
                
                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (i == linkNUM - 1) { go = false; }
                }
                if (go == false)
                {
                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        bool tou1 = false;
                        bool tou2 = false;
                        bool tou3 = false;
                        bool wei1 = false;
                        bool wei2 = false;
                        bool wei3 = false;

                        if (templink[0][1] - 1 >= 0 && gamearray[templink[0][0], templink[0][1] - 1] != intEnemySign) { tou1 = true; }
                        if (tou1 == true && templink[0][1] - 2 >= 0 && gamearray[templink[0][0], templink[0][1] - 2] != intEnemySign) { tou2 = true; }
                        if (tou2 == true && templink[0][1] - 3 >= 0 && gamearray[templink[0][0], templink[0][1] - 3] != intEnemySign) { tou3 = true; }
                        if (templink[templinkNUM - 1][1] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0], templink[templinkNUM - 1][1] + 1] != intEnemySign) { wei1 = true; }
                        if (wei1 == true && templink[templinkNUM - 1][1] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0], templink[templinkNUM - 1][1] + 2] != intEnemySign) { wei2 = true; }
                        if (wei2 == true && templink[templinkNUM - 1][1] + 3 <= 18 && gamearray[templink[templinkNUM - 1][0], templink[templinkNUM - 1][1] + 3] != intEnemySign) { wei3 = true; }

                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            if (templink == null) { Console.WriteLine("templink为空"); }
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (lastspacestart != -1 &&
                        ((templink[templinkNUM - 1][1] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0], templink[templinkNUM - 1][1] + 1] == intMeSign) ||
                        (templink[templinkNUM - 1][1] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0], templink[templinkNUM - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    link++;
                    lastspacestart = -1;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;

                }
            }
        }

        private void IsLink22(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            int space = 0;
            int lastspacestart = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i > 0)
                {
                    if (link == 5) { go = false; }
                    else
                    {
                        if (linklist[i][0] - linklist[i - 1][0] == 2)
                        {
                            if (gamearray[linklist[i][0]-1, linklist[i][1]] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                go = false;
                            }
                        }
                        else if (linklist[i][0] - linklist[i - 1][0] >= 3)
                        {
                            go = false;
                        }
                    }
                }

                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (i == linkNUM - 1) { go = false; }
                }
                if (go == false)
                {
                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        bool tou1 = false;
                        bool tou2 = false;
                        bool tou3 = false;
                        bool wei1 = false;
                        bool wei2 = false;
                        bool wei3 = false;

                        if (templink[0][0] - 1 >= 0 && gamearray[templink[0][0]-1, templink[0][1] ] != intEnemySign) { tou1 = true; }
                        if (tou1 == true && templink[0][0] - 2 >= 0 && gamearray[templink[0][0]-2, templink[0][1] ] != intEnemySign) { tou2 = true; }
                        if (tou2 == true && templink[0][0] - 3 >= 0 && gamearray[templink[0][0]-3, templink[0][1] ] != intEnemySign) { tou3 = true; }
                        if (templink[templinkNUM - 1][0] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0]+1, templink[templinkNUM - 1][1] ] != intEnemySign) { wei1 = true; }
                        if (wei1 == true && templink[templinkNUM - 1][0] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0]+2, templink[templinkNUM - 1][1] ] != intEnemySign) { wei2 = true; }
                        if (wei2 == true && templink[templinkNUM - 1][0] + 3 <= 18 && gamearray[templink[templinkNUM - 1][0]+3, templink[templinkNUM - 1][1] ] != intEnemySign) { wei3 = true; }

                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            if (templink == null) { Console.WriteLine("templink为空"); }
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (lastspacestart != -1 &&
                        ((templink[templinkNUM - 1][0] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0]+1, templink[templinkNUM - 1][1] ] == intMeSign) ||
                        (templink[templinkNUM - 1][0] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0]+2, templink[templinkNUM - 1][1] ] == intMeSign)))
                    {
                        i = lastspacestart;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    link++;
                    lastspacestart = -1;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;

                }
            }
        }

        private void IsLink33(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            int space = 0;
            int lastspacestart = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i > 0)
                {
                    if (link == 5) { go = false; }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0]-1, linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                go = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                        }
                    }
                }

                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (i == linkNUM - 1) { go = false; }
                }
                if (go == false)
                {
                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        bool tou1 = false;
                        bool tou2 = false;
                        bool tou3 = false;
                        bool wei1 = false;
                        bool wei2 = false;
                        bool wei3 = false;

                        if (                templink[0][0] - 1 >= 0 && templink[0][1] - 1 >= 0 && 
                            gamearray[templink[0][0]-1, templink[0][1] - 1] != intEnemySign) { tou1 = true; }
                        if (tou1 == true && templink[0][0] - 2 >= 0 && templink[0][1] - 2 >= 0 && 
                            gamearray[templink[0][0]-2, templink[0][1] - 2] != intEnemySign) { tou2 = true; }
                        if (tou2 == true && templink[0][0] - 3 >= 0 && templink[0][1] - 3 >= 0 && 
                            gamearray[templink[0][0]-3, templink[0][1] - 3] != intEnemySign) { tou3 = true; }


                        if (                templink[templinkNUM - 1][0] + 1 <= 18 && templink[templinkNUM - 1][1] + 1 <= 18 && 
                            gamearray[templink[templinkNUM - 1][0]+1, templink[templinkNUM - 1][1] + 1] != intEnemySign) { wei1 = true; }
                        if (wei1 == true && templink[templinkNUM - 1][0] + 2 <= 18 && templink[templinkNUM - 1][1] + 2 <= 18 && 
                            gamearray[templink[templinkNUM - 1][0]+2, templink[templinkNUM - 1][1] + 2] != intEnemySign) { wei2 = true; }
                        if (wei2 == true && templink[templinkNUM - 1][0] + 3 <= 18 && templink[templinkNUM - 1][1] + 3 <= 18 && 
                            gamearray[templink[templinkNUM - 1][0]+3, templink[templinkNUM - 1][1] + 3] != intEnemySign) { wei3 = true; }

                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            if (templink == null) { Console.WriteLine("templink为空"); }
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (lastspacestart != -1 &&
                        ((templink[templinkNUM - 1][0] + 1 <= 18 && templink[templinkNUM - 1][1] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0]+1, templink[templinkNUM - 1][1] + 1] == intMeSign) ||
                        (templink[templinkNUM - 1][0] + 2 <= 18 && templink[templinkNUM - 1][1] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0]+2, templink[templinkNUM - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    link++;
                    lastspacestart = -1;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;

                }
            }
        }

        private void IsLink44(int[][] linklist, int linkNUM)
        {
            bool go = true;
            int link = 0;
            int[][] templink = new int[5][];
            int templinkNUM = 0;
            int space = 0;
            int lastspacestart = -1;

            for (int i = 0; i < linkNUM; i++)
            {
                if (i > 0)
                {
                    if (link == 5) { go = false; }
                    else
                    {
                        if (linklist[i][1] - linklist[i - 1][1] == 2)
                        {
                            if (gamearray[linklist[i][0]+1, linklist[i][1] - 1] != intEnemySign)
                            {
                                space++;
                                if (space == 1) { lastspacestart = i; }
                                if (space == 2)
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                go = false;
                            }
                        }
                        else if (linklist[i][1] - linklist[i - 1][1] >= 3)
                        {
                            go = false;
                        }
                    }
                }

                if (go == true)
                {
                    link++;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;
                    if (i == linkNUM - 1) { go = false; }
                }
                if (go == false)
                {
                    if (link >= 2)
                    {
                        int canlink = link;
                        bool havespace = false;
                        bool _0_ = false;
                        bool tou1 = false;
                        bool tou2 = false;
                        bool tou3 = false;
                        bool wei1 = false;
                        bool wei2 = false;
                        bool wei3 = false;

                        if (templink[0][0] + 1 <= 18 && templink[0][1] - 1 >= 0 &&
                            gamearray[templink[0][0] + 1, templink[0][1] - 1] != intEnemySign) { tou1 = true; }
                        if (tou1 == true && templink[0][0] + 2 <= 18 && templink[0][1] - 2 >= 0 &&
                            gamearray[templink[0][0] + 2, templink[0][1] - 2] != intEnemySign) { tou2 = true; }
                        if (tou2 == true && templink[0][0] + 3 <= 18 && templink[0][1] - 3 >= 0 &&
                            gamearray[templink[0][0] + 3, templink[0][1] - 3] != intEnemySign) { tou3 = true; }


                        if (templink[templinkNUM - 1][0] - 1 >= 0 && templink[templinkNUM - 1][1] + 1 <= 18 &&
                            gamearray[templink[templinkNUM - 1][0] - 1, templink[templinkNUM - 1][1] + 1] != intEnemySign) { wei1 = true; }
                        if (wei1 == true && templink[templinkNUM - 1][0] - 2 >= 0 && templink[templinkNUM - 1][1] + 2 <= 18 &&
                            gamearray[templink[templinkNUM - 1][0] - 2, templink[templinkNUM - 1][1] + 2] != intEnemySign) { wei2 = true; }
                        if (wei2 == true && templink[templinkNUM - 1][0] - 3 >= 0 && templink[templinkNUM - 1][1] + 3 <= 18 &&
                            gamearray[templink[templinkNUM - 1][0] - 3, templink[templinkNUM - 1][1] + 3] != intEnemySign) { wei3 = true; }

                        if (space != 0) { havespace = true; }
                        if (tou1 == true && wei1 == true) { _0_ = true; }
                        if (havespace == true) { canlink++; }
                        if (tou1 == true) { canlink++; }
                        if (wei1 == true) { canlink++; }
                        if (tou2 == true) { canlink++; }
                        if (wei2 == true) { canlink++; }
                        if (tou3 == true) { canlink++; }
                        if (wei3 == true) { canlink++; }
                        if (canlink >= 5)
                        {
                            if (templink == null) { Console.WriteLine("templink为空"); }
                            JoinLinkArray(link, havespace, _0_, templink);
                        }
                    }
                    //重新开始判断

                    if (lastspacestart != -1 &&
                        ((templink[templinkNUM - 1][0] - 1 >= 0 && templink[templinkNUM - 1][1] + 1 <= 18 && gamearray[templink[templinkNUM - 1][0] - 1, templink[templinkNUM - 1][1] + 1] == intMeSign) ||
                        (templink[templinkNUM - 1][0] - 2 >= 0 && templink[templinkNUM - 1][1] + 2 <= 18 && gamearray[templink[templinkNUM - 1][0] - 2, templink[templinkNUM - 1][1] + 2] == intMeSign)))
                    {
                        i = lastspacestart;
                    }

                    go = true;
                    link = 0;
                    space = 0;
                    templink = new int[5][];
                    templinkNUM = 0;
                    link++;
                    lastspacestart = -1;
                    templink[templinkNUM] = new int[] { linklist[i][0], linklist[i][1] };
                    templinkNUM++;

                }
            }
        }

        private void Initialization()
        {
            linkarray = new int[14][][][];
            linkarray[0] = new int[20][][];
            linkarray[1] = new int[20][][];
            linkarray[2] = new int[20][][];
            linkarray[3] = new int[20][][];
            linkarray[4] = new int[20][][];
            linkarray[5] = new int[20][][];
            linkarray[6] = new int[20][][];
            linkarray[7] = new int[20][][];
            linkarray[8] = new int[20][][];
            linkarray[9] = new int[20][][];
            linkarray[10] = new int[20][][];
            linkarray[11] = new int[20][][];
            linkarray[12] = new int[20][][];
            linkarray[13] = new int[20][][];

            numberlink210_0_ = 0;
            numberlink2100_ = 0;
            numberlink2_0_0_ = 0;
            numberlink2_00_ = 0;
            numberlink3100_0_ = 0;
            numberlink31000_ = 0;
            numberlink3_00_0_ = 0;
            numberlink3_000_ = 0;
            numberlink41000_0_ = 0;
            numberlink410000_ = 0;
            numberlink4_000_0_ = 0;
            numberlink4_0000_ = 0;
            numberlink50000_0 = 0;
            numberlink500000 = 0;
            linkNUMarray=new int[14];

        }

        private void JoinLinkArray(int link, bool havespace, bool _0_, int[][] templink)
        {
            switch (link)
            {
                case 2:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK210_0_][numberlink210_0_] = templink;
                            numberlink210_0_++;
                            linkNUMarray[LINK210_0_] = numberlink210_0_;
                        }
                        else
                        {
                            linkarray[LINK2100_][numberlink2100_] = templink;
                            numberlink2100_++;
                            linkNUMarray[LINK2100_] = numberlink2100_;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK2_0_0_][numberlink2_0_0_] = templink;
                            numberlink2_0_0_++;
                            linkNUMarray[LINK2_0_0_] = numberlink2_0_0_;
                        }
                        else
                        {
                            linkarray[LINK2_00_][numberlink2_00_] = templink;
                            numberlink2_00_++;
                            linkNUMarray[LINK2_00_] = numberlink2_00_;
                        }
                    }
                    break;
                case 3:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK3100_0_][numberlink3100_0_] = templink;
                            numberlink3100_0_++;
                            linkNUMarray[LINK3100_0_] = numberlink3100_0_;
                        }
                        else
                        {
                            linkarray[LINK31000_][numberlink31000_] = templink;
                            numberlink31000_++;
                            linkNUMarray[LINK31000_] = numberlink31000_;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK3_00_0_][numberlink3_00_0_] = templink;
                            numberlink3_00_0_++;
                            linkNUMarray[LINK3_00_0_] = numberlink3_00_0_;
                        }
                        else
                        {
                            linkarray[LINK3_000_][numberlink3_000_] = templink;
                            numberlink3_000_++;
                            linkNUMarray[LINK3_000_] = numberlink3_000_;
                        }
                    }
                    break;
                case 4:
                    if (_0_ == false)
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK41000_0_][numberlink41000_0_] = templink;
                            numberlink41000_0_++;
                            linkNUMarray[LINK41000_0_] = numberlink41000_0_;
                        }
                        else
                        {
                            linkarray[LINK410000_][numberlink410000_] = templink;
                            numberlink410000_++;
                            linkNUMarray[LINK410000_] = numberlink410000_;
                        }
                    }
                    else
                    {
                        if (havespace == true)
                        {
                            linkarray[LINK4_000_0_][numberlink4_000_0_] = templink;
                            numberlink4_000_0_++;
                            linkNUMarray[LINK4_000_0_] = numberlink4_000_0_;
                        }
                        else
                        {
                            linkarray[LINK4_0000_][numberlink4_0000_] = templink;
                            numberlink4_0000_++;
                            linkNUMarray[LINK4_0000_] = numberlink4_0000_;
                        }
                    }
                    break;
                case 5:
                    if (havespace == true)
                    {
                        linkarray[LINK50000_0][numberlink50000_0] = templink;
                        numberlink50000_0++;
                        linkNUMarray[LINK50000_0] = numberlink50000_0;
                    }
                    else
                    {
                        linkarray[LINK500000][numberlink500000] = templink;
                        numberlink500000++;
                        linkNUMarray[LINK500000] = numberlink500000;
                    }
                    break;
            }
        }
        
    }
}

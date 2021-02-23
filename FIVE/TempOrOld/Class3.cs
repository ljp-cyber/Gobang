using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Class3
    {
        private int[,] gamearray;
        private int meSign;
        private int enemySign;
        private int[] border;


        private int[][][][] linkarray = new int[14][][][]; 
        private int[] linkNUMarray = new int[14];
        private int[][][][] melinkarray;
        private int[] melinkNUMarray;
        private int[][][][] enemylinkarray;
        private int[] enemylinkNUMarray;

        private static int LINK210_0_ = 0;
        private static int LINK2100_ = 1;
        private static int LINK2_0_0_ = 2;
        private static int LINK2_00_ = 3;
        private static int LINK3100_0_ = 4;
        private static int LINK31000_ = 5;
        private static int LINK3_00_0_ = 6;
        private static int LINK3_000_ = 7;
        private static int LINK41000_0_ = 8;
        private static int LINK410000_ = 9;
        private static int LINK4_000_0_ = 10;
        private static int LINK4_0000_ = 11;
        private static int LINK500000 = 12;
        private static int LINK50000_0 = 13;

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


        public Class3(int[,] gamearray, int meSign)
        {
            this.gamearray = gamearray;
            this.meSign = meSign;
            if (this.meSign == 1) { this.enemySign = 2; }
            else { this.enemySign = 1; }

            Initialization();
            lipian1();
            lipian2();
            lipian3();
            lipian4(); 
            melinkarray = linkarray;
            melinkNUMarray = linkNUMarray;

            if (this.meSign == 1) { this.meSign = 2; this.enemySign = 1; }
            else { this.meSign = 1; this.enemySign = 2; }
            Initialization();
            lipian1();
            lipian2();
            lipian3();
            lipian4();
            enemylinkarray = linkarray;
            enemylinkNUMarray = linkNUMarray;
            if (this.meSign == 1) { this.meSign = 2; this.enemySign = 1; }
            else { this.meSign = 1; this.enemySign = 2; }
            //MessageBox.Show("2:" + numberlink210_0_ + ", 2:" + numberlink2100_
            //    + ", 2:" + numberlink2_0_0_ + ", 2:" + numberlink2_00_
            //     + ", 3:" + numberlink3100_0_ + ", 3:" + numberlink31000_
            //      + ", 3:" + numberlink3_00_0_ + ", 3:" + numberlink3_000_
            //       + ", 4:" + numberlink41000_0_ + ", 4:" + numberlink410000_
            //        + ", 4:" + numberlink4_000_0_ + ", 4:" + numberlink4_0000_);
        }

        public int[][][][] GetEnemyLinkArray()
        {
            return enemylinkarray;
        }

        public int[] GetEnemyLinkNUMArray()
        {
            return enemylinkNUMarray;
        }

        public int[][][][] GetMeLinkArray()
        {
            return melinkarray;
        }

        public int[] GetMeLinkNUMArray()
        {
            return melinkNUMarray;
        }

        private void Initialization()
        {
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
            linkNUMarray = new int[14];
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

        private void lipian1()
        {
            for (int i = 0; i < 19; i++)
            {
                int repeat = -1;
                int lastrepeat = -1;

                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgo=-1;
                bool tou=false;
                bool wei=false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int j = 0; j < 19; j++)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i, j - 1] == meSign) { wei = true; }
                            else if (gamearray[i, j - 1] == 0) 
                            { 
                                wei2 = true;
                                if (j + 1 <= 18 && gamearray[i, j + 1] == 0) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i, j - 1] == meSign) { wei = false; }
                            else if (gamearray[i, j - 1] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (j - 1 >= 0 && gamearray[i, j - 1] !=enemySign) { tou = true; }
                            if (j - 2 >= 0 && gamearray[i, j - 2] != enemySign && tou == true) { tou2 = true; }
                            if (j - 3 >= 0 && gamearray[i, j - 3] != enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace !=0)
                        {
                            havespace = true;
                            if (nextgo == -1) { nextgo = j - 1; repeat = 0; };
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (j == 18) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat==true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgo != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    j = nextgo;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        } 
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgo=-1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;
                        
                    }
                }
            }
        }
        private void lipian2()
        {
            for (int j = 0; j < 19; j++)
            {
                int repeat = -1;
                int lastrepeat = -1;
                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgo = -1;
                bool tou = false;
                bool wei = false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int i = 0; i < 19; i++)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i-1, j ] == meSign) { wei = true; }
                            else if (gamearray[i-1, j ] == 0)
                            {
                                wei2 = true;
                                if (i + 1 <= 18 && gamearray[i+1, j ] !=enemySign ) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i-1, j ] == meSign) { wei = false; }
                            else if (gamearray[i-1, j ] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (i - 1 >= 0 && gamearray[i - 1, j] != enemySign) { tou = true; }
                            if (i - 2 >= 0 && gamearray[i - 2, j] != enemySign && tou == true) { tou2 = true; }
                            if (i - 3 >= 0 && gamearray[i - 3, j] != enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace != 0)
                        {
                            havespace = true;
                            if (nextgo == -1) { nextgo = i - 1; repeat = 0; }
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (i == 18) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat == true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgo != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    i = nextgo;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        }
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgo = -1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;

                    }
                }
            }
        }
        private void lipian3()
        {
            for (int k = 0; k < 19; k++)
            {
                int repeat = -1;
                int lastrepeat = -1;
                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgox = -1;
                int nextgoy = -1;
                bool tou = false;
                bool wei = false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int j = 0, i = k; j < 19 && i < 19; j++, i++)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i-1, j - 1] == meSign) { wei = true; }
                            else if (gamearray[i-1, j - 1] == 0)
                            {
                                wei2 = true;
                                if (i + 1 <= 18 && j + 1 <= 18 && gamearray[i+1, j + 1] !=enemySign) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i-1, j - 1] == meSign) { wei = false; }
                            else if (gamearray[i-1, j - 1] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (i - 1 >= 0 && j - 1 >= 0 && gamearray[i-1, j - 1] !=enemySign) { tou = true; }
                            if (i - 2 >= 0 && j - 2 >= 0 && gamearray[i-2, j - 2] !=enemySign && tou == true) { tou2 = true; }
                            if (i - 3 >= 0 && j - 3 >= 0 && gamearray[i-3, j - 3] !=enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace != 0)
                        {
                            havespace = true;
                            if (nextgox == -1)
                            {
                                nextgox = i-1;
                                nextgoy = j-1;
                                repeat = 0;
                            }
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (j == 18||i==18) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat == true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgox != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    j = nextgoy; i = nextgox;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        }
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgox = -1;
                        nextgoy = -1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;

                    }
                }
            }
            for (int k = 1; k < 19; k++)
            {
                int repeat = -1;
                int lastrepeat = -1;
                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgox = -1;
                int nextgoy = -1;
                bool tou = false;
                bool wei = false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int i = 0, j = k; j < 19 && i < 19; j++, i++)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i - 1, j - 1] == meSign) { wei = true; }
                            else if (gamearray[i - 1, j - 1] == 0)
                            {
                                wei2 = true;
                                if (i + 1 <= 18 && j + 1 <= 18 && gamearray[i + 1, j + 1] != enemySign) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i - 1, j - 1] == meSign) { wei = false; }
                            else if (gamearray[i - 1, j - 1] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (i - 1 >= 0 && j - 1 >= 0 && gamearray[i - 1, j - 1] != enemySign) { tou = true; }
                            if (i - 2 >= 0 && j - 2 >= 0 && gamearray[i - 2, j - 2] != enemySign && tou == true) { tou2 = true; }
                            if (i - 3 >= 0 && j - 3 >= 0 && gamearray[i - 3, j - 3] != enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace != 0)
                        {
                            havespace = true;
                            if (nextgox == -1)
                            {
                                nextgox = i-1;
                                nextgoy = j-1;
                                repeat = 0;
                            }
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (j == 18 || i == 18) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat == true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgox != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    j = nextgoy; i = nextgox;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        }
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgox = -1;
                        nextgoy = -1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;

                    }
                }
            }
        }
        private void lipian4()
        {
            for (int k = 0; k < 19; k++)
            {
                int repeat = -1;
                int lastrepeat = -1;
                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgox = -1;
                int nextgoy = -1;
                bool tou = false;
                bool wei = false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int j = 0, i = k; j < 19 && i >= 0; j++, i--)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i + 1, j - 1] == meSign) { wei = true; }
                            else if (gamearray[i + 1, j - 1] == 0)
                            {
                                wei2 = true;
                                if (i - 1 >= 0 && j + 1 <= 18 && gamearray[i - 1, j + 1] != enemySign) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i + 1, j - 1] == meSign) { wei = false; }
                            else if (gamearray[i + 1, j - 1] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (i + 1 <= 18 && j - 1 >= 0 && gamearray[i + 1, j - 1] != enemySign) { tou = true; }
                            if (i + 2 <= 18 && j - 2 >= 0 && gamearray[i + 2, j - 2] != enemySign && tou == true) { tou2 = true; }
                            if (i + 3 <= 18 && j - 3 >= 0 && gamearray[i + 3, j - 3] != enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace != 0)
                        {
                            havespace = true;
                            if (nextgox == -1)
                            {
                                nextgox = i+1;
                                nextgoy = j-1;
                                repeat = 0;
                            }
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (j == 18 || i == 0) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat == true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgox != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    j = nextgoy; i = nextgox;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        }
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgox = -1;
                        nextgoy = -1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;

                    }
                }
            }
            for (int k = 1; k < 19; k++)
            {
                int repeat = -1;
                int lastrepeat = -1;
                int link = 0;
                bool go = false;
                int continuityspace = 0;
                bool havespace = false;
                //bool haveenemy = false;
                int[][] templink = new int[10][];
                int templink_number = 0;
                int nextgox = -1;
                int nextgoy = -1;
                bool tou = false;
                bool wei = false;
                bool tou2 = false;
                bool wei2 = false;
                bool tou3 = false;
                bool wei3 = false;
                for (int i = 18, j = k; j < 19 && i >= 0; j++, i--)
                {
                    if (go == true)
                    {
                        if (gamearray[i, j] == 0)
                        {
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            continuityspace++;
                            if (gamearray[i + 1, j - 1] == meSign) { wei = true; }
                            else if (gamearray[i + 1, j - 1] == 0)
                            {
                                wei2 = true;
                                if (i - 1 >= 0 && j + 1 <= 18 && gamearray[i - 1, j + 1] != enemySign) { wei3 = true; }
                            }
                            if (continuityspace == 2)
                            {
                                go = false;
                            }
                        }
                        if (gamearray[i, j] == enemySign)
                        {
                            //continuityspace = 0;
                            if (gamearray[i + 1, j - 1] == meSign) { wei = false; }
                            else if (gamearray[i + 1, j - 1] == 0) { wei2 = false; }
                            //haveenemy = true;
                            templink[templink_number] = new int[] { i, j };
                            templink_number++;
                            go = false;
                        }
                    }
                    if (gamearray[i, j] == meSign)
                    {
                        //continuityspace = 0;
                        if (go == false)
                        {
                            go = true;
                            if (i + 1 <= 18 && j - 1 >= 0 && gamearray[i + 1, j - 1] != enemySign) { tou = true; }
                            if (i + 2 <= 18 && j - 2 >= 0 && gamearray[i + 2, j - 2] != enemySign && tou == true) { tou2 = true; }
                            if (i + 3 <= 18 && j - 3 >= 0 && gamearray[i + 3, j - 3] != enemySign && tou2 == true) { tou3 = true; }
                        }
                        if (continuityspace != 0)
                        {
                            havespace = true;
                            if (nextgox == -1)
                            {
                                nextgox = i+1;
                                nextgoy = j-1;
                                repeat = 0;
                            }
                            repeat++;
                        }
                        templink[templink_number] = new int[] { i, j };
                        templink_number++;
                        link++;
                        if (link == 5)
                        {
                            go = false;
                        }
                    }
                    if (j == 18 || i == 0) { go = false; }
                    if (go == false)
                    {
                        bool norepeat = true;
                        if (lastrepeat != -1)
                        {
                            if (lastrepeat - link == 0) { norepeat = false; }
                            lastrepeat = -1;
                        }
                        if (link >= 2 && norepeat == true)
                        {
                            int canlinkNUM = link;
                            if (havespace == true) { canlinkNUM++; }
                            if (tou == true) { canlinkNUM++; }
                            if (wei == true) { canlinkNUM++; }
                            if (tou2 == true) { canlinkNUM++; }
                            if (wei2 == true) { canlinkNUM++; }
                            if (tou3 == true) { canlinkNUM++; }
                            if (wei3 == true) { canlinkNUM++; }
                            if (canlinkNUM >= 5)
                            {
                                bool _0_ = false;
                                if (tou && wei) { _0_ = true; }
                                JoinLinkArray(link, havespace, _0_, templink);
                            }
                            if (nextgox != -1)
                            {
                                if (continuityspace == 2 || link == 5)
                                {
                                    j = nextgoy; i = nextgox;
                                    if (repeat != -1)
                                    {
                                        lastrepeat = repeat;
                                        repeat = -1;
                                    }
                                }
                                else { repeat = -1; }
                            }
                        }
                        link = 0;
                        go = false;
                        continuityspace = 0;
                        havespace = false;
                        templink = new int[10][];
                        templink_number = 0;
                        nextgox = -1;
                        nextgoy = -1;
                        tou = false;
                        wei = false;
                        tou2 = false;
                        wei2 = false;
                        tou3 = false;
                        wei3 = false;

                    }
                }
            }
        }
    }
}

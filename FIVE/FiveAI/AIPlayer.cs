using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    
    class AIPlayer
    {
        private struct VCT_P
        {
            public bool blnVCT;
            public int intDeep;
            public List<int[]> listProcess;
        }
        private struct VCF_P
        {
            public bool blnVCF;
            public int intDeep;
            public List<int[]> listProcess;
        }

        private int[,] arrGameArray;
        private int intMeSign;
        private int intNext;
        private List<int[]> listAllPlayer;

        PointsAndScore PAS;
        Random ran = new Random();

        //MAXMIN测试数据
        private int intTotal = 0;
        private int intABCut = 0;
        private int intWinCut = 0;
        private int tallestPoint = 0;
        private int tallT = 0;
        private int shortT = 0;
        //VCF测试数据
        private int intVCFTotal = 0;
        private int intVCFABCut = 0;
        private int intVCFWinCut = 0;
        private int intVCFtallestPoint = 0;
        private int intVCFtallT = 0;
        private int intVCFshortT = 0;
        //VCT测试数据
        private int intVCTTotal = 0;
        private int intVCTABCut = 0;
        private int intVCTWinCut = 0;
        private int intVCTtallestPoint = 0;
        private int intVCTtallT = 0;
        private int intVCTshortT = 0;
        //private int intEnemySign;
        //private int[] arrMeLinkArrayCount;
        //private int[] arrEnemyLinkArrayCount;
        //private int[][][][] arrMeLinkArray;
        //private int[][][][] arrEnemyLinkArray;
        //private int[][] arrMeArray;
        //private int[][] arrEnemyArray;
        //private int intMeArraySum;
        //private int intEnemyArraySum;


        private const int MMIN = -10000000;
        private const int MMAX = 10000000;


        public AIPlayer(int[,] arrGameArray, List<int[]> listAllPlayer,int intMeSIgn, int intNext)
        {
            this.arrGameArray = arrGameArray;
            this.listAllPlayer = listAllPlayer;
            this.intMeSign = intNext;
            this.intNext = intNext;
            PAS = new PointsAndScore(arrGameArray, intMeSign, listAllPlayer, intNext);
        }


        public int[] GetTarget()
        {
            int[] temp = MAXMIN(4);
            //MessageBox.Show("intTotal:" + intTotal + ",intABCut:" + intABCut + ",intWinCut:" + intWinCut+
                //":tallestPoint:" + tallestPoint + ",tallT:" + tallT + ",shortT:" + shortT);
            return temp;
        }


        public int[] GetVCF()
        {
            int[] temp = VCF();
            //MessageBox.Show("intTotal:" + intTotal + ",intABCut:" + intABCut + ",intWinCut:" + intWinCut +
            //    ":tallestPoint:" + tallestPoint + ",tallT:" + tallT + ",shortT:" + shortT);
            return temp;
        }


        public int[] GetVCT()
        {
            int[] temp = VCT();
            return temp;
        }


        private int[] MAXMIN(int deep)
        {
            PAS.SetNewData(intNext);
            int[][] arrBestPoints = new int[80][];
            int intBestPointsSum = 0;

            int best = MMIN;
            //int[][] arrPoints = GetPoints();
            int[][] arrPoints = PAS.GetAllPoints();
            int intPointsSum = arrPoints[arrPoints.Length-1][0];

            //测试内容
            intTotal++;
            if (tallestPoint < intPointsSum) { tallestPoint = intPointsSum; }
            if (intPointsSum > 40) { tallT++; }
            if (intPointsSum <= 10) { shortT++; } 
            else 
            { 
                int[] vcf=VCF();
                if (vcf == null)
                {
                    Console.WriteLine("不能VCF");
                }
                else
                {
                    Console.WriteLine("VCF");
                    return vcf;
                }
                int[] vct = VCT();
                if (vct == null)
                {
                    Console.WriteLine("不能VCT");
                }
                else
                {
                    Console.WriteLine("VCT");
                    return vct;
                }
            }
            if (intPointsSum <= 0) { shortT += 1000000; MessageBox.Show("!"); }
            //
            for (int i = 0; i < intPointsSum; i++)
            {
                //走一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                //arrMeArray[intMeArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                //intMeArraySum++;
                listAllPlayer.Add(new int[]{arrPoints[i][0], arrPoints[i][1], intNext});
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                //分数
                int intThisScore = MIN(deep - 1, MMAX, best);
                //回头一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                //arrMeArray[intMeArraySum - 1] = null;
                //intMeArraySum--;
                listAllPlayer.RemoveAt(listAllPlayer.Count-1);
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                //找最好
                if (best == intThisScore)
                {
                    arrBestPoints[intBestPointsSum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                    intBestPointsSum++;
                }
                if (intThisScore > best)
                {
                    best = intThisScore;
                    arrBestPoints = new int[80][];
                    intBestPointsSum = 0;
                    arrBestPoints[intBestPointsSum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                    intBestPointsSum++;
                }
                if (best > 600000) { intWinCut++; break; }
            }
            //MessageBox.Show("分数："+best);
            int[] arrTarget = arrBestPoints[ran.Next(0, intBestPointsSum - 1)];
            return arrTarget;
        }


        private int MIN(int deep,int alpha,int beta)
        {
            //测试内容
            intTotal++;
            //
            PAS.SetNewData(intNext);
            //GetTypeArray();
            //int intScore = GetSituationScore();
            int intScore = PAS.GetSituationScore();
            if (deep <= 0 || intScore > 600000)
            {
                return intScore;
            }
            int best = MMAX;
            //int[][] arrPoints = GetPoints();
            int[][] arrPoints = PAS.GetAllPoints();
            int intPointsSum = arrPoints[arrPoints.Length-1][0];
            //测试内容
            if (tallestPoint < intPointsSum) { tallestPoint = intPointsSum; }
            if (intPointsSum > 40) { tallT++; }
            if (intPointsSum < 10) { shortT++; } 
            if (intPointsSum <= 0) 
            { 
                shortT += 1000000; 
                MessageBox.Show("!"); 
            }
            //
            for (int i = 0; i < intPointsSum; i++)
            {
                //走一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                //arrEnemyArray[intEnemyArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                //intEnemyArraySum++;
                listAllPlayer.Add(new int[] { arrPoints[i][0], arrPoints[i][1], intNext });
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                //分数
                int intThisScore = MAX(deep - 1, best < alpha ? best : alpha, beta);
                //回头一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                //arrEnemyArray[intEnemyArraySum - 1] = null;
                //intEnemyArraySum--;
                listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                if (intNext == 2) { intNext = 1; } else { intNext = 2; }
                //找最好分数
                if (intThisScore < best) { best = intThisScore; }
                if (intThisScore < beta) { intABCut++; break; }
                if (intThisScore < -600000) { best = intThisScore; intWinCut++; break; }
            }

            return best;
        }


        private int MAX(int deep, int alpha, int beta)
        {
            //测试内容
            intTotal++;
            //
            PAS.SetNewData(intNext);
            int intScore = PAS.GetSituationScore();
            //GetTypeArray();
            //int intScore = GetSituationScore();
            if (deep <= 0 || intScore < -600000)
            {
                return intScore;
            }
            int best = MMIN;
            //int[][] arrPoints = GetPoints();
            int[][] arrPoints = PAS.GetAllPoints();
            int intPointsSum = arrPoints[arrPoints.Length - 1][0];
            //测试内容
            if (tallestPoint < intPointsSum) { tallestPoint = intPointsSum; }
            if (intPointsSum > 40) { tallT++; }
            if (intPointsSum < 10) { shortT++; } 
            if (intPointsSum <= 0) 
            {
                shortT += 1000000; 
                MessageBox.Show("!"); 
            }
            //
            for (int i = 0; i < intPointsSum; i++)
            {
                //走一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = intNext;
                //arrMeArray[intMeArraySum] = new int[] { arrPoints[i][0], arrPoints[i][1] };
                //intMeArraySum++;
                listAllPlayer.Add(new int[] { arrPoints[i][0], arrPoints[i][1], intNext });
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                //分数
                int intThisScore = MIN(deep - 1, alpha, best > beta ? best : beta);
                //回头一步
                arrGameArray[arrPoints[i][0], arrPoints[i][1]] = 0;
                //arrMeArray[intMeArraySum - 1] = null;
                //intMeArraySum--;
                listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                if (intNext == 2) { intNext = 1; } else { intNext = 2; }
                //找最好分数
                if (intThisScore > best) { best = intThisScore; }
                if (intThisScore > alpha) { intABCut++; break; }
                if (intThisScore > 600000) { best = intThisScore; intWinCut++; break; }
            }

            return best;
        }


        private int[] VCF()
        {
            //搜索层数
            int intMAXDeep = ConstFive.VCF_MAX_DEEP;
            int intMINDeep = 1;
            //测试内容
            intTotal++;
            int intFirstDeepSum=0;
            int intSuccessSum=0;
            Console.WriteLine("VCF开始");
            //所有的最好的VCF点和过程
            int intVCTPointsSum = 0;
            List<int[]> lstBestVCFPoints = new List<int[]>();
            List<List<int[]>> lstAllBestProcess = new List<List<int[]>>();
            //结构体VCF
            VCF_P VP = new VCF_P();
            //VCT的过程
            bool VCF = false;
            int intBestDeep = intMAXDeep + 1;
            int[] arrBest = new int[3];
            List<int[]> lstBestProcess = new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //我方成五点
            int[][] arrMeWill5 = PAS.GetSomePoints(ConstFive.FIVE, true);
            int intMeWill5Sum = arrMeWill5[arrMeWill5.Length - 1][0];
            //如果我方有成五点VCF成功
            if (intMeWill5Sum > 0)
            {
                VCF = true;
                intBestDeep = intMINDeep;
                for (int i = 0; i < intMeWill5Sum; i++)
                {
                    arrBest[0]=arrMeWill5[i][0];
                    arrBest[1]=arrMeWill5[i][1];
                    arrBest[2]=intNext;
                    lstBestVCFPoints.Add(new int[] { arrMeWill5[i][0], arrMeWill5[i][1] });
                    lstBestProcess.Add(arrBest);
                    lstAllBestProcess.Add(lstBestProcess);
                }
            }
            else
            {
                //敌方成五点
                int[][] arrEnemyWill5 = PAS.GetSomePoints(ConstFive.FIVE, false);
                int intEnemyWill5Sum = arrEnemyWill5[arrEnemyWill5.Length - 1][0];
                //我方成VCF点
                int[][] arrMeWillVCF = PAS.GetSomePoints(ConstFive.VCF, true);
                int intMeWillVCFSum = arrMeWillVCF[arrMeWillVCF.Length - 1][0];
                //测试neir-------------------------------------------
                if (intMeWillVCFSum > intVCFtallestPoint)
                {
                    intVCFtallestPoint = intMeWillVCFSum;
                }
                if (intMeWillVCFSum > 4)
                {
                    intVCFtallT++;
                }
                else
                {
                    intVCFshortT++;
                }
                //如果敌方成五点两个以上，VCF失败
                if (intEnemyWill5Sum > 1)
                {
                    VCF = false;
                }
                //如果敌方成五点一个我方防守
                else if (intEnemyWill5Sum == 1)
                {
                    for (int i = 0; i < intMeWillVCFSum; i++)
                    {
                        //判断我方VCF点和敌方成五点有没有相同的
                        if (arrEnemyWill5[0][0] == arrMeWillVCF[i][0] && arrEnemyWill5[0][1] == arrMeWillVCF[i][1])
                        {
                            //测试内容
                            intFirstDeepSum++;
                            arrGameArray[arrEnemyWill5[0][0], arrEnemyWill5[0][1]] = intNext;
                            listAllPlayer.Add(new int[] { arrEnemyWill5[0][0], arrEnemyWill5[0][1], intNext });
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            VP = VCF_MIN(intMINDeep, intMAXDeep);
                            arrGameArray[arrEnemyWill5[0][0], arrEnemyWill5[0][1]] = 0;
                            listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            if (VP.blnVCF == true)
                            {
                                //测试内容
                                intSuccessSum++;
                                if (VP.intDeep < intBestDeep)
                                {
                                    //先清空在加入结果列表
                                    lstBestVCFPoints.Clear();
                                    lstBestVCFPoints.Add(new int[] { arrEnemyWill5[0][0], arrEnemyWill5[0][1] });
                                    arrBest[0] = arrEnemyWill5[0][0];
                                    arrBest[1] = arrEnemyWill5[0][1];
                                    arrBest[2] = intNext;
                                    VCF = true;
                                    intBestDeep = VP.intDeep;
                                    //把这步棋加入过程列表
                                    lstBestProcess = VP.listProcess;
                                    lstBestProcess.Add(arrBest);
                                    //加入所有相同搜索层数的数组
                                    lstAllBestProcess.Clear();
                                    lstAllBestProcess.Add(lstBestProcess);
                                }
                            }
                        }
                    }
                }
                //敌方没有成五点我方进攻
                else
                {
                    for (int i = 0; i < intMeWillVCFSum; i++)
                    {
                        //测试内容
                        intFirstDeepSum++;

                        arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = intNext;
                        listAllPlayer.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1], intNext });
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        VP = VCF_MIN(intMINDeep, intMAXDeep);
                        arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = 0;
                        listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        //打印VCF进度
                        Console.WriteLine("VCF:" + (i + 1) + "/" + intMeWillVCFSum);
                        if (VP.blnVCF == true)
                        {
                            //测试内容
                            intSuccessSum++;
                            if (VP.intDeep == intBestDeep)
                            {
                                //加入结果列表
                                lstBestVCFPoints.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1] });
                                arrBest = new int[3] { arrMeWillVCF[i][0], arrMeWillVCF[i][1], intNext };
                                //结构体三要素
                                VCF = true;
                                intBestDeep = VP.intDeep;
                                //把这步棋加入过程列表
                                lstBestProcess = VP.listProcess;
                                lstBestProcess.Add(arrBest);
                                //加入所有相同搜索层数的数组
                                lstAllBestProcess.Add(lstBestProcess);
                            }
                            else if (VP.intDeep < intBestDeep)
                            {
                                //先清空再加入结果列表
                                lstBestVCFPoints.Clear();
                                lstBestVCFPoints.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1] });
                                arrBest[0] = arrMeWillVCF[i][0];
                                arrBest[1] = arrMeWillVCF[i][1];
                                arrBest[2] = intNext;
                                VCF = true;
                                intBestDeep = VP.intDeep;
                                //把这步棋加入过程列表
                                lstBestProcess = VP.listProcess;
                                lstBestProcess.Add(arrBest);
                                //加入所有相同搜索层数的数组
                                lstAllBestProcess.Clear();
                                lstAllBestProcess.Add(lstBestProcess);
                                if (intBestDeep < intMAXDeep)
                                {
                                    intMAXDeep = intBestDeep;
                                }
                            }
                        }
                    }
                }
            }
            int[] Result = null;
            Console.WriteLine("本次第一层搜索点数："+intFirstDeepSum+"个,成功VCF个数："
                +intSuccessSum);
            if (VCF == true)
            {
                intVCTPointsSum = lstBestVCFPoints.Count;
                Console.WriteLine("最佳VCF点有");
                for (int i = 0; i < intVCTPointsSum; i++)
                {
                    Console.WriteLine("第"+i+"个：x:" + lstBestVCFPoints[i][0] + ",y:" + lstBestVCFPoints[i][1]);
                }
                int intRandom = ran.Next(0, intVCTPointsSum - 1);
                //打印过程
                Console.WriteLine("最佳VCF点个数" + intVCTPointsSum);
                Console.WriteLine("最佳VCF过程个数" + lstAllBestProcess.Count);
                Console.WriteLine("最佳VCF层数" + intBestDeep);
                List<int[]> lstResultProcess = lstAllBestProcess[intRandom];
                Console.WriteLine("VCF过程：");
                for (int i = lstResultProcess.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine("第" + i + "个：x:" + lstResultProcess[i][0] + ",y:" + lstResultProcess[i][1]
                    + ",SIGN:" + lstResultProcess[i][2]);
                } 
                Result = lstBestVCFPoints[intRandom];
            }
            Console.WriteLine("本次搜索总次数："+intTotal+",AB剪枝数："+intVCFABCut
                +",最高点数："+intVCFtallestPoint+",较高次数："+intVCFtallT+"，较低次数："+intVCFshortT);
            return Result;
        }


        private VCF_P VCF_MIN(int deep,int MAXDeep)
        {
            //测试内容
            intTotal++;
            Console.WriteLine(deep);
            //结构体VCF
            VCF_P VP = new VCF_P();
            //VCT的过程
            bool VCF = false;
            int intBestDeep = -1;
            int[] arrBest = new int[3];
            List<int[]> listBestProcess = new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //敌方成五点
            int[][] arrEnemyWillFIVE = PAS.GetSomePoints(ConstFive.FIVE, false);
            int intEnemyWillFIVESum = arrEnemyWillFIVE[arrEnemyWillFIVE.Length - 1][0];
            //敌方成五点没有VCF失败
            if (intEnemyWillFIVESum == 0)
            {
                VCF = false;
            }
            //敌方成五点有两个以上VCF成功
            else if (intEnemyWillFIVESum > 1)
            {
                /*----------------这里是直接判断----------------*/
                arrBest[0] = arrEnemyWillFIVE[0][0];
                arrBest[1] = arrEnemyWillFIVE[0][1];
                arrBest[2] = intNext;
                intBestDeep = deep;
                VCF = true;
            }
            //敌方成五点只有一个进行防守
            else
            {
                if (deep >= MAXDeep)
                {
                    intVCFABCut++;
                    VP.blnVCF = false;
                    return VP;
                }
                arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = intNext;
                listAllPlayer.Add(new int[] { arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1], intNext });
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                VP = VCF_MAX(deep + 1,MAXDeep);
                arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = 0;
                listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                if (VP.blnVCF == true)
                {
                    if (VP.intDeep > intBestDeep)
                    {
                        arrBest[0] = arrEnemyWillFIVE[0][0];
                        arrBest[1] = arrEnemyWillFIVE[0][1];
                        arrBest[2] = intNext;
                        intBestDeep = VP.intDeep;
                        VCF = VP.blnVCF;
                        listBestProcess = VP.listProcess;
                    }
                }
            }
            if (VCF == true)
            {
                VP.blnVCF = VCF;
                VP.intDeep = intBestDeep;
                listBestProcess.Add(arrBest);
                VP.listProcess = listBestProcess;
            }
            else
            {
                VP.blnVCF = VCF;
            }
            return VP;

        }


        private VCF_P VCF_MAX(int deep, int MAXDeep)
        {
            Console.WriteLine(deep);
            //结构体VCF
            VCF_P VP = new VCF_P(); 
            if (deep >= MAXDeep)
            {
                intVCFABCut++;
                VP.blnVCF = false;
                return VP;
            }
            //VCT的过程
            bool VCF = false;
            int intBestDeep = ConstFive.VCF_MAX_DEEP;
            int[] arrBest = new int[3];
            List<int[]> listBestProcess = new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //敌方成五点
            int[][] arrEnemyWillFIVE = PAS.GetSomePoints(ConstFive.FIVE, false);
            int intEnemyWillFIVESum = arrEnemyWillFIVE[arrEnemyWillFIVE.Length - 1][0];
            //如果敌方成五点多余一个VCF失败
            if (intEnemyWillFIVESum > 1)
            {
                VCF = false;
            }
            else
            {
                //我方可能VCF的点
                int[][] arrMeWillVCF = PAS.GetSomePoints(ConstFive.VCF, true);
                int intMeWillVCFSum = arrMeWillVCF[arrMeWillVCF.Length - 1][0];
                //测试neir-------------------------------------------
                if (intMeWillVCFSum > intVCFtallestPoint)
                {
                    intVCFtallestPoint = intMeWillVCFSum;
                }
                if (intMeWillVCFSum > 4)
                {
                    intVCFtallT++;
                }
                else
                {
                    intVCFshortT++;
                }
                //如果我方vcf点没有VCF失败
                if (intMeWillVCFSum == 0)
                {
                    VCF = false;
                }
                else
                {
                    //如果敌方成五点只有一个，看有没有和我方成四点相同的
                    if (intEnemyWillFIVESum == 1)
                    {
                        for (int i = 0; i < intMeWillVCFSum; i++)
                        {
                            if (arrEnemyWillFIVE[0][0] == arrMeWillVCF[i][0] && arrEnemyWillFIVE[0][1] == arrMeWillVCF[i][1])
                            {
                                arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = intNext;
                                listAllPlayer.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1], intNext });
                                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                                VP = VCF_MIN(deep + 1, MAXDeep);
                                arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = 0;
                                listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                                if (VP.blnVCF == true) 
                                {
                                    arrBest[0] = arrMeWillVCF[i][0];
                                    arrBest[1] = arrMeWillVCF[i][1];
                                    arrBest[3] = intNext;
                                    VCF = VP.blnVCF;
                                    intBestDeep = VP.intDeep;
                                    listBestProcess = VP.listProcess;
                                }
                            }
                        }
                    }
                    else
                    {
                        //敌方没有成五点，我方攻杀
                        for (int i = 0; i < intMeWillVCFSum; i++)
                        {
                            arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = intNext;
                            listAllPlayer.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1], intNext });
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            VP = VCF_MIN(deep + 1, MAXDeep);
                            arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = 0;
                            listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            if (VP.blnVCF == true) 
                            {
                                if (VP.intDeep < intBestDeep)
                                {
                                    arrBest[0] = arrMeWillVCF[i][0];
                                    arrBest[1] = arrMeWillVCF[i][1];
                                    arrBest[2] = intNext;
                                    VCF = VP.blnVCF;
                                    intBestDeep = VP.intDeep;
                                    listBestProcess = VP.listProcess;
                                    if (intBestDeep < MAXDeep)
                                    {
                                        MAXDeep = intBestDeep;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (VCF == true)
            {
                listBestProcess.Add(arrBest);
                VP.blnVCF = VCF;
                VP.intDeep = intBestDeep;
                VP.listProcess = listBestProcess;
            }
            else
            {
                VP.blnVCF = VCF;
            }
            return VP;
        }


        private int[] VCT()
        {
            int intMAXDeep = 12;
            int intMINDeep = 1;
            //测试内容
            intVCTTotal++;
            Console.WriteLine("VCT开始");

            //返回的VCT点
            int[] VCTPoint = null;
            //结构体VCT_P
            VCT_P VP = new VCT_P();
            //VCT的最佳路径
            bool VCT = false;
            int intBestDeep = ConstFive.VCT_MAX_DEEP;
            int[] arrBest=new int[3];
            List<int[]> listVCTProcess = new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //我方可能VCT的点
            int[][] arrMeWillVCT = PAS.GetSomePoints(ConstFive.VCT, true);
            int intMeWillVCTSum = arrMeWillVCT[arrMeWillVCT.Length - 1][0];
            //测试VCT
            for (int i = 0; i < intMeWillVCTSum; i++)
            {
                arrGameArray[arrMeWillVCT[i][0], arrMeWillVCT[i][1]] = intNext;
                listAllPlayer.Add(new int[] { arrMeWillVCT[i][0], arrMeWillVCT[i][1], intNext });
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                VP = VCT_MIN(intMINDeep, intBestDeep, intMINDeep, intMAXDeep);
                arrGameArray[arrMeWillVCT[i][0], arrMeWillVCT[i][1]] = 0;
                listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                //打印VCT进度
                Console.WriteLine("VCT:" + (i + 1) + "/" + intMeWillVCTSum);
                //VCT成功
                if (VP.blnVCT == true)
                {
                    if (VP.intDeep < intBestDeep)
                    {
                        arrBest[0] = arrMeWillVCT[i][0];
                        arrBest[1] = arrMeWillVCT[i][1];
                        arrBest[2] = intNext;
                        intBestDeep = VP.intDeep;
                        VCT = VP.blnVCT;
                        listVCTProcess = VP.listProcess;
                    }
                    if (intBestDeep < intMAXDeep)
                    {
                        intMAXDeep = intBestDeep;
                    }
                    //break;
                }
            }
            if (VCT == true)
            {
                VCTPoint = new int[] { arrBest[0], arrBest[1] };
                listVCTProcess.Add(arrBest);
                //打印过程
                for (int j = listVCTProcess.Count - 1; j >= 0; j--)
                {
                    Console.WriteLine("第" + j + "个：" + "x:" + listVCTProcess[j][0] + ",y:" + listVCTProcess[j][1]
                        + ",SIGN:" + listVCTProcess[j][2]);
                }
            }
            Console.WriteLine("本次搜索总次数：" + intVCTTotal + "，AB剪枝数：" + intVCTABCut + ",胜利剪枝数：" + intVCTWinCut
                +"，最高点个数，"+intVCTtallestPoint+"，较高次数:"+intVCTtallT+"，较低次数："+intVCTshortT);
            return VCTPoint;
        }


        private VCT_P VCT_MIN(int deep,int bestDeep,int betterDeep, int MAXDeep)
        {
            //测试内容
            intVCTTotal++;
            //打印层数
            Console.WriteLine(deep);
            //结构体VCT_P
            VCT_P VP = new VCT_P();
            //VCT的最佳路径
            bool VCT = false;
            int intBestDeep = -1;
            int[] arrBest = new int[3];
            List<int[]> listBestProcess=new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //我方成五点
            int[][] arrMeWillFIVE=PAS.GetSomePoints(ConstFive.FIVE,true);
            //我方可以成五，VCT失败
            if (arrMeWillFIVE[arrMeWillFIVE.Length - 1][0] > 0)
            {
                VCT = false;
            }
            else
            {
                //敌方成五点
                int[][] arrEnemyWillFIVE = PAS.GetSomePoints(ConstFive.FIVE, false);
                int intEnemyWillFIVESum = arrEnemyWillFIVE[arrEnemyWillFIVE.Length - 1][0];
                //如果敌方成五点2个以上VCT成功
                /*-------------------这个是直接判断---------------------*/
                if (intEnemyWillFIVESum > 1)
                {
                    arrBest[0] = arrEnemyWillFIVE[0][0];
                    arrBest[1] = arrEnemyWillFIVE[0][1];
                    arrBest[2] = intNext;
                    VCT = true;
                    intBestDeep = deep;
                }
                //如果敌方成五点一个我方防守
                else if (intEnemyWillFIVESum == 1)
                {
                    if (deep >= MAXDeep)
                    {
                        if (MAXDeep < 12)
                        {
                            intVCTWinCut++;
                        }
                        VP.blnVCT = false;
                        return VP;
                    }
                    arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = intNext;
                    listAllPlayer.Add(new int[] { arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1], intNext });
                    if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                    VP = VCT_MAX(deep + 1, bestDeep, betterDeep,MAXDeep);
                    arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = 0;
                    listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                    if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                    if (VP.blnVCT == true)
                    {
                        arrBest[0] = arrEnemyWillFIVE[0][0];
                        arrBest[1] = arrEnemyWillFIVE[0][1];
                        arrBest[2] = intNext;
                        intBestDeep = VP.intDeep;
                        VCT = VP.blnVCT;
                        listBestProcess = VP.listProcess;
                    }
                }
                //敌方没有成五点
                else
                {
                    if (deep >= MAXDeep)
                    {
                        if (MAXDeep < 12)
                        {
                            intVCTWinCut++;
                        }
                        VP.blnVCT = false;
                        return VP;
                    }
                    //测试内容
                    int intThisCount = 0;
                    //我方可能VCF点
                    int[][] arrMeWillVCF = PAS.GetSomePoints(ConstFive.VCF, true);
                    int intMeWillVCFSum = arrMeWillVCF[arrMeWillVCF.Length - 1][0];
                    //测试我方VCF点
                    for (int i = 0; i < intMeWillVCFSum; i++)
                    {
                        //测试内容
                        intThisCount++;
                        arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = intNext;
                        listAllPlayer.Add(new int[] { arrMeWillVCF[i][0], arrMeWillVCF[i][1], intNext });
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        //我方冲四不算层数
                        VP = VCT_MAX(deep + 1, bestDeep, betterDeep,MAXDeep);
                        arrGameArray[arrMeWillVCF[i][0], arrMeWillVCF[i][1]] = 0;
                        listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        /*if (arrMeWillVCF[i][0] == 11 && arrMeWillVCF[i][1] == 6 && VP.blnVCT==true)
                        {

                        }*/
                        //如果我方有一个守住VCT失败,跳出循环
                        if (VP.blnVCT == false)
                        {
                            VCT = false;
                            break;
                        }
                        else
                        {
                            if (VP.intDeep > intBestDeep)
                            {
                                arrBest[0] = arrMeWillVCF[i][0];
                                arrBest[1] = arrMeWillVCF[i][1];
                                arrBest[2] = intNext;
                                intBestDeep = VP.intDeep;
                                VCT = VP.blnVCT;
                                listBestProcess = VP.listProcess;
                            }
                            //类似AB剪枝
                            if (intBestDeep > betterDeep)
                            {
                                betterDeep = intBestDeep;
                            }
                            if (intBestDeep > bestDeep)
                            {
                                intVCTABCut++;
                                break;
                            }
                        }
                    }
                    //敌方VCF点,这里应该VCT==true才进行的
                    if (VCT == true || intMeWillVCFSum == 0)
                    {
                        int[][] arrEnenyWillFOUR = PAS.GetSomePoints(ConstFive.FOUR, false);
                        int intEnemyWillFOURSum = arrEnenyWillFOUR[arrEnenyWillFOUR.Length - 1][0];
                        //测试敌方VCF点
                        for (int i = 0; i < intEnemyWillFOURSum; i++)
                        {
                            //测试内容
                            intThisCount++;
                            arrGameArray[arrEnenyWillFOUR[i][0], arrEnenyWillFOUR[i][1]] = intNext;
                            listAllPlayer.Add(new int[] { arrEnenyWillFOUR[i][0], arrEnenyWillFOUR[i][1], intNext });
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            VP = VCT_MAX(deep + 1, bestDeep, betterDeep,MAXDeep);
                            arrGameArray[arrEnenyWillFOUR[i][0], arrEnenyWillFOUR[i][1]] = 0;
                            listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                            if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                            //我有一个点方守住，VCT失败，跳出循环
                            if (VP.blnVCT == false)
                            {
                                VCT = false;
                                break;
                            }
                            else
                            {
                                if (VP.intDeep > intBestDeep)
                                {
                                    arrBest[0] = arrEnenyWillFOUR[i][0];
                                    arrBest[1] = arrEnenyWillFOUR[i][1];
                                    arrBest[2] = intNext;
                                    intBestDeep = VP.intDeep;
                                    VCT = VP.blnVCT;
                                    listBestProcess = VP.listProcess;
                                }
                                //类似AB剪枝
                                if (intBestDeep > betterDeep)
                                {
                                    betterDeep = intBestDeep;
                                }
                                if (intBestDeep > bestDeep)
                                {
                                    intVCTABCut++;
                                    break;
                                }
                            }
                        }
                    }
                    //测试内容
                    if (intThisCount > intVCTtallestPoint)
                    {
                        intVCTtallestPoint = intThisCount;
                    }
                    if (intThisCount > 4)
                    {
                        intVCTtallT++;
                    }
                    else
                    {
                        intVCTshortT++;
                    }
                }
            }
            if (VCT == true)
            {
                listBestProcess.Add(arrBest);
                VP.blnVCT = VCT;
                VP.intDeep = intBestDeep;
                VP.listProcess = listBestProcess;
            }
            else
            {
                VP.blnVCT = VCT;
            }
            return VP;
        }


        private VCT_P VCT_MAX(int deep, int bestDeep, int betterDeep,int MAXDeep)
        {
            //测试内容
            intVCTTotal++;
            //打印层数
            Console.WriteLine(deep);
            //结构体VCT_P
            VCT_P VP = new VCT_P();
            //VCT最佳路径
            bool VCT = false;
            int intBestDeep = ConstFive.VCT_MAX_DEEP;
            int[] arrBest = new int[3];
            List<int[]> listBestProcess = new List<int[]>();
            //分析局面找出棋型
            PAS.SetNewData(intNext);
            //我方成五点
            int[][] arrMeWillFIVE = PAS.GetSomePoints(ConstFive.FIVE, true);
            //如果我方有成五点VCT成功
            /*-------------------这个是直接判断---------------------*/
            if (arrMeWillFIVE[arrMeWillFIVE.Length - 1][0] > 0)
            {
                arrBest[0] = arrMeWillFIVE[0][0];
                arrBest[1] = arrMeWillFIVE[0][1];
                arrBest[2] = intNext;
                intBestDeep = deep;
                VCT = true;
            }
            else
            {
                //层数大于12跳出VCT，VCT失败
                if (deep >= MAXDeep)
                {
                    if (MAXDeep < 12)
                    {
                        intVCTWinCut++;
                    }
                    VP.blnVCT = false;
                    return VP;
                }
                //敌方成五点
                int[][] arrEnemyWillFIVE = PAS.GetSomePoints(ConstFive.FIVE, false);
                int intEnemyWillFIVESum = arrEnemyWillFIVE[arrEnemyWillFIVE.Length - 1][0];
                //如果敌方成五点大于两个VCT失败
                if (intEnemyWillFIVESum > 1)
                {
                    VCT = false;
                }
                //如果敌方成五点一个我方防守
                else if (intEnemyWillFIVESum == 1)
                {
                    arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = intNext;
                    listAllPlayer.Add(new int[] { arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1], intNext });
                    if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                    //守敌成五的不算层数
                    VP = VCT_MIN(deep+1,bestDeep,betterDeep,MAXDeep);
                    arrGameArray[arrEnemyWillFIVE[0][0], arrEnemyWillFIVE[0][1]] = 0;
                    listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                    if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                    if (VP.blnVCT == true)
                    {
                        arrBest[0] = arrEnemyWillFIVE[0][0];
                        arrBest[1] = arrEnemyWillFIVE[0][1];
                        arrBest[2] = intNext;
                        listBestProcess = VP.listProcess;
                        intBestDeep = VP.intDeep;
                        VCT = true;
                    }
                }
                //敌方没有成五点
                else
                {
                    //我方VCT点
                    int[][] arrMeWillVCT = PAS.GetSomePoints(ConstFive.VCT, true);
                    int arrMeWillVCTSum = arrMeWillVCT[arrMeWillVCT.Length - 1][0];
                    //测试内容
                    if (arrMeWillVCTSum > intVCTtallestPoint)
                    {
                        intVCTtallestPoint = arrMeWillVCTSum;
                    }
                    if (arrMeWillVCTSum > 4)
                    {
                        intVCTtallT++;
                    }
                    else
                    {
                        intVCTshortT++;
                    }
                    //测试我方VCT点
                    for (int i = 0; i < arrMeWillVCTSum; i++)
                    {
                        arrGameArray[arrMeWillVCT[i][0], arrMeWillVCT[i][1]] = intNext;
                        listAllPlayer.Add(new int[] { arrMeWillVCT[i][0], arrMeWillVCT[i][1], intNext });
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        VP = VCT_MIN(deep + 1,bestDeep,betterDeep,MAXDeep);
                        arrGameArray[arrMeWillVCT[i][0], arrMeWillVCT[i][1]] = 0;
                        listAllPlayer.RemoveAt(listAllPlayer.Count - 1);
                        if (intNext == 1) { intNext = 2; } else { intNext = 1; }
                        //有一个VCT则VCT成功，跳出循环,这里是直接跳出，可以做成最短路径不跳出
                        if (VP.blnVCT == true)
                        {
                            if (VP.intDeep < intBestDeep)
                            {
                                arrBest[0] = arrMeWillVCT[i][0];
                                arrBest[1] = arrMeWillVCT[i][1];
                                arrBest[2] = intNext;
                                listBestProcess = VP.listProcess;
                                intBestDeep = VP.intDeep;
                                VCT = true;
                                if (intBestDeep < MAXDeep)
                                {
                                    MAXDeep = intBestDeep;
                                }
                                //类似AB剪枝
                                if (intBestDeep < bestDeep)
                                {
                                    bestDeep = intBestDeep;
                                }
                                if (intBestDeep < betterDeep)
                                {
                                    intVCTABCut++;
                                    break;
                                }
                            }
                            //intVCFWinCut++;
                            //break;
                        }
                    }
                }
            }
            if (VCT == true)
            {
                listBestProcess.Add(arrBest);
                VP.blnVCT = VCT;
                VP.intDeep = intBestDeep;
                VP.listProcess = listBestProcess;
            }
            else
            {
                VP.blnVCT = VCT;
            }
            return VP;
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
    }
}

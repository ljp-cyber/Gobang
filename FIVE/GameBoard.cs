using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 单例的五子棋模板类,游戏数组的操作
    /// </summary>
    class GameBoard
    {
        //单例
        private static GameBoard gameBoard;
        private readonly int[,] gameArr;
        private int pieceType;
        private int[] focalArr;
        private int whilePieceCount;
        private int blackPieceCount;

        /// <summary>
        /// 获取单例的五子棋模板
        /// </summary>
        /// <returns></returns>
        public static GameBoard GetGameBoard()
        {
            if (gameBoard == null)
            {
                gameBoard = new GameBoard();
            }
            return gameBoard;
        }

        /// <summary>
        /// 获取棋盘数组
        /// </summary>
        /// <returns></returns>
        public int[,] GetGameArr()
        {
            return gameArr;
        }

        /// <summary>
        /// 获取焦点数组
        /// </summary>
        /// <returns></returns>
        public int[] GetFocalArr()
        {
            return focalArr;
        }

        //封闭的默认构造函数
        private GameBoard()
        {
            gameArr = new int[ConstFive.BL, ConstFive.BL];
            Clear();
            gameBoard = this;
        }

        /// <summary>
        /// 清空棋盘
        /// </summary>
        public void Clear()
        {
            blackPieceCount = ConstFive.B_BLACK_COUNT;
            whilePieceCount = ConstFive.B_WHILE_COUNT;
            pieceType = ConstFive.BLACK_SIGN;
            focalArr = new int[] { ConstFive.B_MAX_XY / 2, ConstFive.B_MAX_XY / 2 };
            for(int i = 0; i < ConstFive.BL; i++)
            {
                for(int j = 0; j < ConstFive.BL; j++)
                {
                    gameArr[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 载入棋盘，检查大小是否正确，棋子颜色是否正确
        /// </summary>
        /// <param name="gameArr"></param>
        /// <returns></returns>
        public bool LoadGameArr(int[,] gameArr)
        {
            if (gameArr.Length != ConstFive.BL* ConstFive.BL)
            {
                return false;
            }
            Clear();
            for (int i=0;i< ConstFive.BL; i++)
            {
                for(int j=0;j< ConstFive.BL; j++)
                {
                    if (gameArr[i, j] == ConstFive.BLACK_SIGN) blackPieceCount--;
                    else if (gameArr[i, j] == ConstFive.WHITE_SIGN) whilePieceCount--;
                    else if (gameArr[i, j] == ConstFive.SPACE_SIGN) ;
                    else
                    {
                        Clear();
                        return false;
                    }
                    this.gameArr[i, j] = gameArr[i, j];
                }
            }
            return true;
        }

        /// <summary>
        /// 复制一份数组
        /// </summary>
        /// <returns></returns>
        public int[,] CopyGameArr()
        {
            int[,] newGameArr=new int[ConstFive.BL,ConstFive.BL];
            for (int i = 0; i < newGameArr.Length; i++)
            {
                for (int j = 0; j < ConstFive.BL; j++)
                {
                    newGameArr[i,j] = gameArr[i,j];
                }
            }
            return newGameArr;
        }

        /// <summary>
        /// 设置要走的棋子颜色、类型
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool SetPieceType(int type)
        {
            if (type != ConstFive.BLACK_SIGN || type != ConstFive.WHITE_SIGN)
                return false;
            pieceType = type;
            return true;
        }

        /// <summary>
        /// 在坐标上落子，棋盘焦点获得
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool PalyChess(int x,int y)
        {
            if(x< ConstFive.B_MIN_XY || y< ConstFive.B_MIN_XY || x > ConstFive.B_MAX_XY || y > ConstFive.B_MAX_XY)
            {
                return false;
            }
            focalArr[0] = x;
            focalArr[1] = y;
            if (gameArr[x, y] == 0)
            {
                gameArr[x, y] = pieceType;
                if (gameArr[x, y] == ConstFive.BLACK_SIGN) blackPieceCount--;
                else if (gameArr[x, y] == ConstFive.WHITE_SIGN)
                {
                    whilePieceCount--;
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 拿起一个棋子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool PickUpPiece(int x,int y)
        {
            if (x < ConstFive.B_MIN_XY || y < ConstFive.B_MIN_XY || x > ConstFive.B_MAX_XY || y > ConstFive.B_MAX_XY)
            {
                return false;
            }
            if (gameArr[x, y] != 0)
            {
                if (gameArr[x, y] == ConstFive.BLACK_SIGN) blackPieceCount++;
                else if (gameArr[x, y] == ConstFive.WHITE_SIGN) whilePieceCount++;
                gameArr[x, y] = ConstFive.SPACE_SIGN;
                focalArr[0] = x;
                focalArr[1] = y;
                return true;
            }
            else
                return false;
        }
    }
}

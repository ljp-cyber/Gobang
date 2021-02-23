using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    static class ConstFive
    {
        //棋盘常量
        public const int BL = 19;
        public const int B_MIN_X = 0;
        public const int B_MIN_Y = 0;
        public const int B_MAX_X = 18;
        public const int B_MAX_Y = 18;
        public const int B_MIN_XY = 0;
        public const int B_MAX_XY = 18;
        //敌我标识
        public const int BLACK_SIGN = 1;
        public const int WHITE_SIGN = 2;
        public const int SPACE_SIGN = 0;
        public const int NONE_SIGN = -1;
        //棋型标识
        public const int FIVE = 0;
        public const int FOUR = 1;
        public const int SFOUR = 2;
        public const int THREE = 3;
        public const int STHREE = 4;
        public const int TWO = 5;
        public const int STWO = 6;
        public const int ONE = 7;
        public const int SONE = 8;
        public const int VCF = 9;
        public const int VCT = 10;
        public const int FOURFOUR = 11;
        public const int THREETHREE = 12;
        public const int FOURTHREE = 13;
        //搜索深度
        public const int VCT_MAX_DEEP = 100;
        public const int VCF_MAX_DEEP = 100;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {

        private int intCB_FrameLenght;
        private int intCB_Top;
        private int intCB_left;
        private DrawGame drawGame;
        private Game game;//游戏逻辑类
        private bool go = false;//游戏开始标识

        public FormMain()
        {
            InitializeComponent();
            Initialization();
        }

        /// <summary>
        /// 游戏的初始化
        /// </summary>
        private void Initialization()
        {
            intCB_Top = ConstView.CB_Top;
            intCB_left = ConstView.CB_Left;
            intCB_FrameLenght = ConstView.CB_FrameLenght;
            game = new Game();
            //设置棋盘的背景图
            Bitmap backBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(backBitmap);
            DrawChessBoard grawChessBoard = new DrawChessBoard(graphics);
            grawChessBoard.Draw();
            pictureBox1.BackgroundImage = backBitmap;
            graphics.Dispose();
            //Bitmap bitmap; = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            //g = Graphics.FromImage(bitmap);
            //g = this.CreateGraphics();//从当前窗口创建
            //g = e.Graphics;//这样写不循环
        }

        private void GameStart(int people,bool first)
        {
            drawGame = new DrawGame(game);
            game.GameStart(people, first);
            go = true;
        }

        private void 分析局面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(go)
            game.LookChess();
        }

        private void vCF测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (go)
            game.VCF();
        }

        private void 双人游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart(2, true);
        }

        private void 我先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart(1, true);
        }

        private void 电脑先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart(1, false);
        }

        private void 电脑自个玩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart(0, true);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (go)
            game.UnDo();
        }

        private void vCT测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (go)
            game.VCT();
        }

        //int i = 0;
        /// <summary>
        /// 画面不刷新就会停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine(i++);
            pictureBox1.Image=null;
            if (go)
            {
                drawGame.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// 点击屏幕下棋
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (go)
            {
                int[] pos = ConstView.GetPos(e.X, e.Y);
                game.PalyA(pos[0], pos[1]);
            }
        }

        /// <summary>
        /// 鼠标移动显示坐标，监听picturebox鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (go)
            {
                label2.Text = "e.X:" + e.X + ",e.Y:" + e.Y;
                int[] pos=ConstView.GetPos(e.X, e.Y);
                label1.Text = "x:" + pos[0] + ",y:" + pos[1];
            }
        }
    }
}

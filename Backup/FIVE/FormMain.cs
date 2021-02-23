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
        private Game game;
        private bool go = false;

        public FormMain()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            intCB_Top = ConstView.CB_Top;
            intCB_left = ConstView.CB_Left;
            intCB_FrameLenght = ConstView.CB_FrameLenght;
            game = new Game();
            //设置棋盘的背景图
            Bitmap bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            DrawChessBoard drawChessBoard = new DrawChessBoard(graphics);
            drawChessBoard.Draw();
            pictureBox1.BackgroundImage = bitmap;
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Pens.Red
            //g = this.CreateGraphics();//从当前窗口创建
            //Graphics g1 = e.Graphics;//这样写不循环
            Bitmap bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            if (go)
            {
                drawGame.Draw(g);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (go)
            {
                int x = (int)(e.X - (intCB_Top - intCB_FrameLenght / 2)) / intCB_FrameLenght;
                int y = (int)(e.Y - (intCB_left - intCB_FrameLenght / 2)) / intCB_FrameLenght;
                if (x < 0) { x = 0; }
                if (y < 0) { y = 0; }
                if (x > ConstFive.B_MAX_XY) { x = ConstFive.B_MAX_XY; }
                if (y > ConstFive.B_MAX_XY) { y = ConstFive.B_MAX_XY; }
                game.PalyA(x, y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (go)
            {
                int x = (int)(e.X - (intCB_Top - intCB_FrameLenght / 2)) / intCB_FrameLenght;
                int y = (int)(e.Y - (intCB_left - intCB_FrameLenght / 2)) / intCB_FrameLenght;
                if (x < 0) { x = 0; }
                if (y < 0) { y = 0; }
                if (x > ConstFive.B_MAX_XY) { x = ConstFive.B_MAX_XY; }
                if (y > ConstFive.B_MAX_XY) { y = ConstFive.B_MAX_XY; }
                label1.Text = "x:" + x + ",y:" + y;
            }
        }
    }
}

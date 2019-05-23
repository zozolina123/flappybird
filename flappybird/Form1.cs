using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace flappybird
{
    public partial class Form1 : Form
    {
        Point bird;
        Point[] pillars = new Point[20];
        Graphics desen;
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush  pillar_culoare= new SolidBrush(Color.White);
        SolidBrush sterge = new SolidBrush(Color.Black);
        Random rnd = new Random();
        int gravity,dist,m;
        public Form1()
        {
            InitializeComponent();
            desen = this.CreateGraphics();
            bird.Y = this.Height / 2 -30;
            bird.X = 10;
            gravity = 1;
            dist = 350;
            m = this.Width / dist;
            for (int i = 1; i <= m;i++ )
            {
                pillars[i].X = i * dist;
                pillars[i].Y = rnd.Next(10, this.Height-100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            desen.FillRectangle(sterge, bird.X, bird.Y - gravity, 20, 20);
            bird.Y += gravity;
            desen.FillRectangle(red, bird.X, bird.Y, 20, 20);
            if (bird.Y + gravity + 55 > this.Height)
                timer1.Enabled = false;
            if (gravity < 10)
            {
                gravity += 1;
            }
            desen.FillRectangle(sterge, -100, -100, 100, 100);

            for (int i = 1; i <= m; i++)
            {
                desen.FillRectangle(sterge, pillars[i].X+1, 0, 20, pillars[i].Y);
                desen.FillRectangle(sterge, pillars[i].X+1, pillars[i].Y + 100, 20, this.Height);
                pillars[i].X -= 20;
            }
            for (int i = 1; i <= m; i++) {
                desen.FillRectangle(pillar_culoare, pillars[i].X, 0, 20, pillars[i].Y);
                desen.FillRectangle(pillar_culoare, pillars[i].X, pillars[i].Y+100, 20, this.Height);
                pillars[i].X -= 1;
                if (pillars[i].X < -10) {
                    pillars[i].X = this.Width;
                    pillars[i].Y = rnd.Next(10, this.Height-100);
                }
                else if((bird.Y<= pillars[i].Y || bird.Y>= pillars[i].Y+100) && (pillars[i].X>10 && pillars[i].X<30)){
                    timer1.Enabled = false;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            desen.FillRectangle(sterge, bird.X, bird.Y - gravity, 20, 20);
            gravity -= 15;
        }
    }
}

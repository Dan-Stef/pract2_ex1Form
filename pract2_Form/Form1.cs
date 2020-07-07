using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract2_Form
{
    public partial class Form1 : Form
    {
        private const int PIX_IN_ONE = 15;
        private const int RADIUS = 12 * PIX_IN_ONE;
        private const int Ox = 22 * PIX_IN_ONE;
        private const int Oy = 14 * PIX_IN_ONE; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textBox1.Text != "" && isValid(textBox1.Text) && textBox2.Text != "" && isValid(textBox2.Text))
                draw(textBox1.Text, textBox2.Text);
        }
        private bool isValid(String str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (!(chArr[i] >= '0' && chArr[i] <= '9') && chArr[i] != '-')
                {
                    return false;
                }
            }
            return true;
        }
        private void draw(string text1, string text2)
        {
            Bitmap btm = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(btm);
            Pen p = new Pen(Brushes.Black);
            Pen p2 = new Pen(Brushes.DarkGray);

            int v = 0;
            while (v < pictureBox.Width)
            {
                graphics.DrawLine(p2, v, 0, v, pictureBox.Height);
                v += PIX_IN_ONE / 2;
            }
         
            int g = 0;
            while (g < pictureBox.Height)
            {
                graphics.DrawLine(p2, 0, g, pictureBox.Width, g);
                g += PIX_IN_ONE / 2;
            }

          

     
            graphics.DrawLine(p, 22 * PIX_IN_ONE, 0, 22 * PIX_IN_ONE, pictureBox.Height);

        
            graphics.DrawLine(p, 0, 14 * PIX_IN_ONE, pictureBox.Width, 14 * PIX_IN_ONE);

         
            graphics.DrawEllipse(p, 14 * PIX_IN_ONE + PIX_IN_ONE, 8 * PIX_IN_ONE - PIX_IN_ONE, RADIUS + PIX_IN_ONE + PIX_IN_ONE / 2, RADIUS + PIX_IN_ONE + PIX_IN_ONE / 2);

   
            graphics.DrawLine(p, Ox, Oy, 30 * PIX_IN_ONE, 6 * PIX_IN_ONE);
            graphics.DrawLine(p, Ox, Oy, 14 * PIX_IN_ONE, 6 * PIX_IN_ONE);

            int x1 = Ox, y1 = Oy;
            double x11 = 0, y11 = 0;
            int x2 = Ox, y2 = Oy;
            double x22 = 0, y22 = 0;
            while (x11 * x11 + y11 * y11 < 49)
            {
                while (x22 * x22 + y22 * y22 < 49)
                {
                    x2 -= PIX_IN_ONE / 3;
                    y2 -= PIX_IN_ONE / 3;
                    x22 -= 0.3333;
                    y22 -= 0.3333;

                }
                graphics.DrawLine(p, x1, y1, x2, y2);
                x1 += PIX_IN_ONE / 2;
                y1 -= PIX_IN_ONE / 2;
                x11 += 0.5;
                y11 -= 0.5;

                x2 = x1;
                y2 = y1;
                x22 = x11;
                y22 = y11;

            }


            graphics.FillEllipse(Brushes.Red, Ox + (Convert.ToInt32(text1) * (PIX_IN_ONE / 2)) - 5, Oy - (Convert.ToInt32(text2) * (PIX_IN_ONE / 2 )) - 5, 10, 10);
            textBox3.Text = Check(float.Parse(text1), float.Parse(text2));

            pictureBox.Image = btm;
        }
        private String Check(float x, float y)
        {
            if (x * x + y * y < 15 * 15 && y > Math.Abs(x))
                return "Да";
            else if (x * x + y * y <= 15 * 15 && y == Math.Abs(x) || x * x + y * y == 15 * 15 && y > Math.Abs(x))
                return "На границе";
            else return "Нет";

        }
    }
}

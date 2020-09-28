using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy
{
    public partial class Form1 : Form
    {

 
        Random rnd = new Random();

        int contor = 0;
        bool jumping = false;      
        Pen pen = new Pen(Color.Green, 5);
        SolidBrush sb = new SolidBrush(Color.Green);

        List<Rectangle> RectTop = new List<Rectangle>();
        List<Rectangle> RectBot = new List<Rectangle>();
        List<int> X = new List<int>();





        int speed = 2;
        bool alive;

        
        ReteaNeuronala retea;
        /*
        ReteaNeuronala a = new ReteaNeuronala(2, 2, 2);
        ReteaNeuronala b = new ReteaNeuronala(2, 2, 2);
        DNA dna = new DNA(5);
        */
        ReteaNeuronala a;
        ReteaNeuronala b;
        public Form1()
        {
           
            InitializeComponent();
            DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;         
            Ini();

        }


        private void Ini()
        {
            RectTop = new List<Rectangle>();
            RectBot = new List<Rectangle>();
            X = new List<int>();
            retea = new ReteaNeuronala(6,3,4);

            Rectangle aT = new Rectangle(400, 0, 30, rnd.Next(100, 280));
            Rectangle bT = new Rectangle(700, 0, 30, rnd.Next(100, 280));
            Rectangle cT = new Rectangle(1000, 0, 30, rnd.Next(100, 280));
            Rectangle dT = new Rectangle(1300, 0, 30, rnd.Next(100, 280));

            List<int> aux = new List<int>();
            aux.Add(430 - aT.Height);
            aux.Add(430 - bT.Height);
            aux.Add(430 - cT.Height);
            aux.Add(430 - dT.Height);

            Rectangle aB = new Rectangle(400, 600 - aux[0], 30, aux[0]);
            Rectangle bB = new Rectangle(700, 600 - aux[1], 30, aux[1]);
            Rectangle cB = new Rectangle(1000, 600 - aux[2], 30, aux[2]);
            Rectangle dB = new Rectangle(1300, 600 - aux[3], 30, aux[3]);


            RectTop.Add(aT);
            RectTop.Add(bT);
            RectTop.Add(cT);
            RectTop.Add(dT);
            RectBot.Add(aB);
            RectBot.Add(bB);
            RectBot.Add(cB);
            RectBot.Add(dB);


            X.Add(400);
            X.Add(700);
            X.Add(1000);
            X.Add(1300);


            flappyBird.Location = new Point(55, 144);
            this.MaximumSize = new Size(1044, 639);
            alive = true;

        }



        private void Tick(object sender, EventArgs e)
        {


            List<double> intrari = new List<double>();
            int index = Apropiate();
            
            intrari.Add(flappyBird.Location.X);
            intrari.Add(flappyBird.Location.Y);
            intrari.Add(RectBot[index].X);
            intrari.Add(RectBot[index].Y);
            intrari.Add(RectTop[index].X);
            intrari.Add(RectTop[index].Y);

            verificare(retea.Calculare(intrari));
           

            if (jumping){
                
                contor++;
                flappyBird.Top -= 5;
                
            }
            
            else
            {
                if(flappyBird.Top < 530)
                {
                    flappyBird.Top += 2;
                }
            }
            if(contor == 10)
            {
                contor = 0;
                jumping = false;
            }
            

            UpDate();
            Die();

            this.Invalidate();

        }

       
        private void Die()
        {
            Rectangle a = new Rectangle(flappyBird.Location.X,flappyBird.Location.Y,flappyBird.Width,flappyBird.Height);
            int index = Apropiate();

            Rectangle b = new Rectangle(RectTop[index].X, RectTop[index].Y, RectTop[index].Width, RectTop[index].Height);
            Rectangle c = new Rectangle(RectBot[index].X, RectBot[index].Y,  RectBot[index].Width, RectBot[index].Height);

            if (a.IntersectsWith(b) || a.IntersectsWith(c)) alive = false;
        }


        private void Die2()
        {
            int index = Apropiate();

            Rectangle a = new Rectangle(RectTop[index].X, RectTop[index].Y, RectTop[index].Width, RectTop[index].Height);
            Rectangle b = new Rectangle(RectBot[index].X, RectBot[index].Y, RectBot[index].Width, RectBot[index].Height);

            /*
            for(int i = 0; i<birds.Count; i++)
            {
                birds[i].getRectangle(a, b);
            }
            */
            
  
        }

        private int Apropiate()
        {
            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                if (RectTop[i].X < RectTop[a].X)
                {
                    a = i;
                } 
            }

            return a;
        }
        

        void UpDate()
        {

            if (alive)
            {
                int lungimeA;
                int lungimeB;
                Rectangle a;
                Rectangle b;
                List<Rectangle> aux = new List<Rectangle>();
                List<Rectangle> aux1 = new List<Rectangle>();


                for (int i = 0; i < 4; i++)
                {
                    lungimeA = RectTop[i].Height;
                    lungimeB = RectBot[i].Height;

                    X[i] = X[i] - speed;

                    if (X[i] < -30)
                    {
                        a = new Rectangle(1300, 0, 30, rnd.Next(100, 280));
                        int r = 430 - a.Height;
                        b = new Rectangle(1300, 600 - r, 30, r);
                        X[i] = 1300;
                    }
                    else
                    {
                        a = new Rectangle(X[i], 0, 30, lungimeA);
                        b = new Rectangle(X[i], 600 - lungimeB, 30, lungimeB);
                    }

                    aux.Add(a);
                    aux1.Add(b);
                }
                RectTop = aux;
                RectBot = aux1;
            }
            else
            {
                Ini();
            }
                     
        }
       


        private void Press(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar == (char)Keys.Space)
            {
                 if(flappyBird.Top > 50)
                 {
                     jumping = true;
                 }

            }
            */
        }

        private void P(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for(int i = 0; i < 4; i++)
            {
                g.FillRectangle(sb, RectTop[i]);
                g.DrawRectangle(pen, RectTop[i]);
                g.FillRectangle(sb, RectBot[i]);
                g.DrawRectangle(pen, RectBot[i]);
            }

        }

        private void verificare(double aux)
        {
           if(aux > 0.5)
            {
                if (flappyBird.Top > 50)
                {
                    jumping = true;
                }
            }
        }
   
    }

}

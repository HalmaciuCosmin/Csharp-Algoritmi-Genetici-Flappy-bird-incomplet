using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Flappy
{
    class Bird
    {

        Rectangle rec;
        bool jumping = false;
        public bool alive = true;
        int contor = 0;
        double scor = 0;

        Rectangle a;
        Rectangle b;


        public Bird()
        {
            rec = new Rectangle(55, 144, 83, 64);
        }

        public void Tick()
        {
            if (alive == true)
            {
                if (jumping == true)
                {                    
                    rec = new Rectangle(rec.X, rec.Y - 5, rec.Width, rec.Height);
                    contor++;
                    Die();

                    if (contor == 10)
                    {
                        contor = 0;
                        jumping = false;
                    }
                }
                else
                {
                    if (rec.Y < 530)
                    {
                        rec = new Rectangle(rec.X, rec.Y + 2, rec.Width, rec.Height);
                    }
                }
                scor++;
            }
            Die();
        }

        public void jump()
        {
            if(rec.Y > 50)
            {
                jumping = true;
            }
        }

        public void Die()    
        {
            if(alive)
            {
                if (rec.IntersectsWith(b) || rec.IntersectsWith(b)) alive = false;
            }
        }

        public void getRectangle(Rectangle x , Rectangle y)
        {
            a = x;
            b = y;
        }

        

        public Point getPoint()
        {
            Point a = rec.Location;
            return a;
        }

        public void reset()
        {
            scor = 0;
            alive = true;
            rec = new Rectangle(55, 144, 83, 64);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flappy
{
    class DNA
    {


        int mutatie;
        List<double> parinte1 = new List<double>();
        List<double> parinte2 = new List<double>();        


        public DNA(int mut)
        {
            mutatie = mut;
        }

        public List<double> Incrucisare()
        {
            List<double> copil = new List<double>(new double[parinte1.Count]);      
            for(int i = 0; i < parinte1.Count; i++)
            {

                if(RND.Int(1,100) < mutatie)
                {
 //                 Thread.Sleep(15);
                    copil[i] = RND.Double(-1, 1);
                }
                else
                {
                    if (RND.Int(1, 100) < 50)
                    {
                        copil[i] = parinte1[i];
                    }
                    else
                    {
                        copil[i] = parinte2[i];
                    }
                }
            }

            return copil;
        }

        public void setParinte(int aux,List<double> list)
        {
            if(aux == 1)
            {
                parinte1 = list;
            }
            
            if(aux == 2)
            {
                parinte2 = list;
            }
        }
    }
}

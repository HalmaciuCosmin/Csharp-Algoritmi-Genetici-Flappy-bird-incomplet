using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flappy
{
    class Neuron
    {
        int g;
        int p;
        double gid;
        double output;       
        List<double> Legaturi = new List<double>();
        List<double> Intrari = new List<double>();

 
       public Neuron(int nr)
        {
            p = 0;
            g = 1;
  
            for(int i = 0;  i < nr; i++)
            {
             //   Thread.Sleep(15);
                Legaturi.Add(RND.Double(-1,1));
            }
        }
        

        


        private double Suma(List<double> lista)
        {
            double S = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                S += lista[i];
            }
            return S;
        }

        private double Functia_Sigmoidala(double gid)  // 0-1
        {
            double prag = (double)p;
            double G = (double)g;

            double aux = -G * (gid - prag);
            return (double)(1 / (1 + Math.Pow(Math.E, aux)));
        }


        public  void  Calculare()
        {
            List<double> aux = new List<double>();
            for(int i = 0; i<Legaturi.Count; i++)
            {
                aux.Add(Legaturi[i] * Intrari[i]);
            }

            gid = Suma(aux);
            output = Functia_Sigmoidala(gid);
        }

        public void setIntrari(List<double> List) {
            Intrari = List;
        }

        public double getoutput()
        {
            return output;
        }

        public List<double> getLegaturi()
        {
            return Legaturi;
        }
        
        public void reset()
        {
            Legaturi = new List<double>();
        }

        public void setLegaturi(double nr)
        {
            Legaturi.Add(nr);
        }
    }
}



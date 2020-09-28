using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy
{
    class ReteaNeuronala
    {

        List<List<Neuron>> Ascunsi = new List<List<Neuron>>();
        Neuron iesire;
        int Intrare;
        int Straturi;
        int NrStrat;


        public ReteaNeuronala(int nrIntrare , int nrStraturi , int nrNeuronipeStrat)
        {
            Intrare = nrIntrare;
            Straturi = nrStraturi;
            NrStrat = nrNeuronipeStrat;


            for (int i = 0; i < nrStraturi; i++)
            {
                List<Neuron> aux = new List<Neuron>();
                if(i==0)
                {
                    for(int j = 0; j<nrNeuronipeStrat;j++)
                    {
                        Neuron a = new Neuron(nrIntrare);
                        aux.Add(a);
                    }
                }
                else
                {
                    for (int j = 0; j < nrNeuronipeStrat; j++)
                    {
                        Neuron a = new Neuron(nrNeuronipeStrat);
                        aux.Add(a);
                    }
                }
                Ascunsi.Add(aux);                                  
            }
            iesire = new Neuron(nrNeuronipeStrat);
        }

        public double Calculare(List<double> aux)
        {

            List<double> rezultate1 = new List<double>();
            List<double> rezultate2 = new List<double>();

            for (int i = 0; i < Ascunsi.Count();i++)
            {
                List<Neuron>  n = new List<Neuron>();
                n = Ascunsi[i];

                for(int j = 0; j < n.Count; j++)
                {

                    if (i == 0)
                    {
                       
                        n[j].setIntrari(aux);
                        n[j].Calculare();                      
                        rezultate1.Add(n[j].getoutput());
                    }
                    else
                    {
                        if(i%2 == 1)
                        {
                            n[j].setIntrari(rezultate1);
                            n[j].Calculare();
                            rezultate2.Add(n[j].getoutput());
                            if (j + 1 == n.Count)
                            {
                                rezultate1 = new List<double>();
                            }
                        }
                        else
                        {
                            n[j].setIntrari(rezultate2);
                            n[j].Calculare();
                            rezultate1.Add(n[j].getoutput());
                            if (j + 1 == n.Count)
                            {
                                rezultate2 = new List<double>();
                            }
                        }
                      
                    }
                }                        
            }

            List<double> rez = new List<double>();
            List<Neuron> ne = new List<Neuron>();
            ne = Ascunsi[Ascunsi.Count - 1];
            for(int i = 0; i<ne.Count;i++)
            {
                rez.Add(ne[i].getoutput());
            }

            iesire.setIntrari(rez);
            iesire.Calculare();

            return iesire.getoutput();

        }
       
        
        public List<double> getLegaturi()
        {
            List<double> legaturi = new List<double>();

            for(int i = 0; i < Straturi; i++)
            {
                List<Neuron> aux;
                aux = Ascunsi[i];

                for(int j = 0; j<NrStrat; j++)
                {
                    legaturi.AddRange(aux[j].getLegaturi());
                }
            }

            legaturi.AddRange(iesire.getLegaturi());
            return legaturi;
        }


        public void Mutatie(List<double> Lista)
        {
            int k = 0;
            int z = 0;
            for (int i = 0; i < Straturi;i++)
            {
                List<Neuron> aux = Ascunsi[i];

                for(int j = 0; j<NrStrat; j++)
                {
                    if(i == 0)
                    {
                        aux[j].reset();
                        while(k < Intrare * j)
                        {
                            aux[j].setLegaturi(Lista[k]);
                            k++;
                        }

                    }
                    else
                    {
                        while(z < NrStrat)
                        {
                            k = k + 1;
                            aux[j].setLegaturi(Lista[k]);
                            z++;
                        }
                        z = 0;
                    }
                }
            }

            for(int i = 0; i < NrStrat; i++)
            {
                iesire.setLegaturi(Lista[k]);
                k++;
            }
        }


        public int CountNeuroni()
        {
            int aux = 0;
            for(int i = 0; i < Straturi; i++)
            {
                for(int j = 0; j < NrStrat; j++)
                {
                    aux++;
                }
            }
            aux += Intrare + 1;
            return aux;          
        }


    }
}

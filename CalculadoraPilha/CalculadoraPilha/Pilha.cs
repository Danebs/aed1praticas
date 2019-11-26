using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilha
{
    class Pilha
    {
        private int[] vetP;
        private int topo = 0;

        // Construtor da Pilha:
        public Pilha(int tam)
        {
            this.vetP = new int[tam];
            
            
        }

        // Verificar se a pilha está cheia:
        public bool Cheia()
        {
            return (topo == vetP.Length);
        }

        // Verificar se pilha está vazia:
        public bool Vazia()
        {
            return (topo == 0);
        }


        // Verificar Pilha:
        public bool Verificar(string v)
        {
            int n;

            bool teste = Int32.TryParse(v, out n);
            

            return teste;
        }

        public void Empilhar(string valor)
        {
            bool alg = Verificar(valor);
            

            if (alg)
            {
                if (Cheia() == false)
                {
                    vetP[topo] = Convert.ToInt32(valor);
                    topo++;
                    Console.WriteLine("topo: {0}", vetP[topo]);

                }
                else
                {
                    Console.WriteLine("Sua pilha está cheia !!!");
                }
            }
            else
            {
                if (topo == 0)
                {
                    Console.WriteLine("Impossível realizar a operação, você não tem números suficientes na pilha !!");

                }
                else
                {

                    switch (valor)
                    {
                        case "-":
                            topo--;
                            int n1 = vetP[topo];
                            topo--;
                            int n2 = vetP[topo]; 
                            int result = n2 - n1;
                            vetP[topo] = result;
                            Console.WriteLine("topo: {0}", vetP[topo]);
                            topo++;
                            break;

                        case "+":
                            topo--;
                            n1 = vetP[topo];
                            topo--;
                            n2 = vetP[topo];
                            result = n2 + n1;
                            vetP[topo] = result;
                            Console.WriteLine("topo: {0}", vetP[topo]);
                            topo++;
                            break;
                        case "/":
                            topo--;
                            n1 = vetP[topo];
                            topo--;
                            n2 = vetP[topo];
                            result = n2 / n1 ;
                            vetP[topo] = result;
                            Console.WriteLine("topo: {0}", vetP[topo]);
                            topo++;
                            break;
                        case "*":
                            topo--;
                            n1 = vetP[topo];
                            topo--;
                            n2 = vetP[topo];
                            result = n2 * n1;
                            vetP[topo] = result;
                            Console.WriteLine("topo: {0}", vetP[topo]);
                            topo++;
                            break;

                    }
                }
            }
            
            


        }

        public int Desempilhar()
        {
            topo--;
            return vetP[topo];

        }

        
    }
}

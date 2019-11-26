using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilha
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha p1 = new Pilha(100);
            string s = "";
            string n = "";
            
            while(n != "n")
            {
                
                Console.WriteLine("Entre com um valor: ");
                n = Console.ReadLine();
                p1.Empilhar(n);

               // Console.WriteLine("Deseja continuar ?");
                //s = Console.ReadLine();

                


            }
            Console.ReadKey();
        }

        
        
    }
    
}

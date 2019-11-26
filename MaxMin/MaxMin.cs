using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class MaxMin
    {

        // Operação relevante: TESTES (if)
        // T(n) = 2n - 2
        public int MaxMin1(int[] vet, int c)
        {
           
            int i;
            int maior, menor;
            maior = menor = vet[0];

            for (i = 1; i < vet.Length; i++)
            {
                c++;
                if (vet[i] < menor)
                    menor = vet[i];
                
                if (vet[i] > maior)
                    maior = vet[i];
            }

            return c;
        }

        // Melhor caso: T(n) = n - 1
        // Pior caso: T(n) = 2n - 2
        // Caso médio: T(n) = 3n/2 - 3/2
        public int maxMin2(int[] vet, int c)
        {
            int maior, menor, cont = 0;
            int i;
            maior = menor = vet[0];
            for (i = 1; i < vet.Length; i++)
            {
                c++;
                if (vet[i] < menor)
                {
                    menor = vet[i];
                }
                else
                {
                    c++;
                    if (vet[i] > maior)
                        maior = vet[i];
                }
                
            }
            return c;
        }

        // T(n) = 3n/2 - 2
        public int maxMin3(int[] vet, int c )
        {
            int maior, menor;
            int i;
            c++;
            if (vet[0] < vet[1])
            {
                menor = vet[0];
                maior = vet[1];
            }
            else
            {
                menor = vet[1];
                maior = vet[0];
            }
            for (i = 2; i < vet.Length; i += 2)
            {
                c++;
                if (vet[i] < vet[i + 1])
                {
                    c++;
                    if (vet[i] < menor)
                        menor = vet[i];
                    c++;
                    if (vet[i + 1] > maior)
                        maior = vet[i + 1];
                }
                else
                {
                    c++;
                    if (vet[i + 1] < menor)
                        menor = vet[i + 1];
                    c++;
                    if (vet[i] > maior)
                        maior = vet[i];
                }
            }
            return c;
        }
    }
}

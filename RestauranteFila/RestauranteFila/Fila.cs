using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteFila
{
    class Fila
    {
        private int[] vet;
        private int inicio;
        private int fim;

        public Fila(int tam)
        {
            vet = new int[tam];
            inicio = fim = 0;
        }

        public void Inserir(int cl)
        {
            vet[fim] = cl;
            fim = (fim + 1) % vet.Length;
        }

        public  int desenfileirar()
        {
            int item;
            item = vet[inicio];
            inicio = (inicio + 1) % vet.Length;
            return item;
        }

        public bool vazia()
        {
            return inicio == fim;
        }

        public bool cheia()
        {
            return (fim + 1 ) % vet.Length == inicio;
        }
    }
}

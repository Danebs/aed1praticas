using System.Threading;
using System.Windows.Forms;

namespace Pratica5 {
    class OrdenacaoGrafica {

        // Metódo Bubble Sort O(n²)
        #region BubbleSort
        public static void BubbleSort(int[] vet, Panel p) {
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++) {
                for (j = vet.Length - 1; j > i; j--) {
                    if (vet[j] < vet[j - 1]) {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                    }
                }
                p.Invalidate();
                Thread.Sleep(150);
            }
        }
        #endregion

        // Metódo Selection Sort O(n²)
        #region SelectionSort
        public static void SelectionSort(int[] vet, Panel p)
        {
            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                p.Invalidate();
                Thread.Sleep(150);
            }
        }
        #endregion

        // Método Insertion Sort O(n²)
        #region Insercao
        public static void InsertionSort(int[] vet, Panel p)
        {
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                while (j >= 0 && temp < vet[j])
                {
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = temp;
                p.Invalidate();
                Thread.Sleep(150);
            }
        }
        #endregion

        // Método Shell Sort (n log n)
        #region ShellSort
        public static void ShellSort(int[] vet, Panel p)
        {
            int i, j, x, n;
            int h = 1;
            n = vet.Length;
            do
            {
                h = h * 3 + 1;
            } while (h <= n);
            do
            {
                h /= 3;
                for (i = h; i < n; i++)
                {
                    x = vet[i];
                    j = i;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        vet[j] = vet[j - h];
                        j -= h;
                    }
                    vet[j] = x;
                    p.Invalidate();
                    Thread.Sleep(150); 
                }
                
            } while (h != 1);
        }
        #endregion

        // Método Quick Sort O(n log n)
        #region QuickSort
        public static void QuickSort(int[] vet, int esq, int dir, Panel p)
        {
            int i, j, pivo, temp;

            pivo = vet[(esq + dir) / 2];
            i = esq;
            j = dir;

            do
            {
                while (pivo > vet[i]) i++;
                while (pivo < vet[j]) j--;
                if (i <= j) // O valor da esquerda é maior que o valor da direita (troca)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                }
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(150); // espera 15 milisegundos
            } while (i <= j);

            if (esq < j)
                QuickSort(vet, esq, j, p);

            if (i < dir)
                QuickSort(vet, i, dir, p);
        }
        #endregion

        // Método Heap Sort O (n log n)

        #region HeapSort
        public static void HeapSort(int[] v, Panel p)
        {
            MontaMaxHeap(v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--) // Para cara
            {
                RealizaTroca(v, i, 0);
                ReorganizarHeap(v, 0, --n);
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(150); // espera 15 milisegundos
            }
        }

        // Divide o vetor pela metade -1 e verifica valores
        private static void MontaMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                ReorganizarHeap(v, i, v.Length);

        }

        private static void ReorganizarHeap(int[] vetor, int pos, int tamanhoDoVetor)
        {
            int max = 2 * pos + 1, right = max + 1;
            if (max < tamanhoDoVetor)
            {

                if (right < tamanhoDoVetor && vetor[max] < vetor[right])
                    max = right;

                if (vetor[max] > vetor[pos])
                {
                    RealizaTroca(vetor, max, pos);
                    ReorganizarHeap(vetor, max, tamanhoDoVetor);
                }
            }
        }
        public static void RealizaTroca(int[] v, int j, int aposJ)
        {
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
        }
        #endregion

        // Método Merge Sort O(n log n)

        #region MergeSort
      
        public static void MergeSort(int[] v, int i, int j, Panel p)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                MergeSort(v, i, m,p);
                MergeSort(v, m + 1, j,p);
                Merge(v, i, m, j); // intercala v[i..m] e v[m+1..j] em v[i..j] 

                p.Invalidate(); // redesenha o painel
                Thread.Sleep(150); // espera 15 milisegundos
            }
        }

        // Divisor do Vetor
        private static void Merge(int[] v, int i, int m, int j)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
                temp[k - i] = v[k];
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                if (temp[esq] <= v[dir])
                    v[i++] = temp[esq++];
                else
                    v[i++] = v[dir++];
            }
            while (esq < k)
                v[i++] = temp[esq++];
        }

        #endregion

    }
}

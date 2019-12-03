namespace Pratica5
{
    class OrdenacaoEstatistica
    {
        public static int contTest = 0; // Declarar demais métodos de ordenação
        public static int contTrocas = 0; // Contador de comparações e trocas
        #region Bolha
        public static void BubbleSort(int[] vet)
        {
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                for (j = vet.Length - 1; j > i; j--)
                {
                    contTest++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        contTrocas++;
                    }
                }
            }
        }

        #endregion

        #region Selecao
        public static void SeletionSort(int[] vet)
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
                        contTrocas++;
                    }
                    contTest++;
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                contTrocas++;
            }
        }
        #endregion

        #region Insercao
        public static void InsertionSort(int[] vet)
        {
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                contTest++;
                while (j >= 0 && temp < vet[j])
                {
                    vet[j + 1] = vet[j];
                    j--;
                    contTrocas++;
                }
                vet[j + 1] = temp;
            }
        }
        #endregion

        #region ShellSort
        public static void ShellSort(int[] vet)
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
                    contTest++;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        vet[j] = vet[j - h];
                        contTrocas++;
                        j -= h;
                    }
                    vet[j] = x;
                    
                }

            } while (h != 1);
        }
        #endregion

        #region Quicksort
        public static void QuickSort(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i])
                {
                    i++;
                    contTest++;
                }
                while (x < vet[j])
                {
                    j--;
                    contTest++;
                }                
                if (i <= j)
                {
                    //Contei apenas uma troca, não considerei temp uma troca
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    contTrocas++;

                    i++;
                    j--;
                   
                }
            } while (i <= j);
            if (esq < j)
                QuickSort(vet, esq, j);
            if (i < dir)
                QuickSort(vet, i, dir);
        }

        #endregion

        // Método Heap Sort O (n log n)
        #region HeapSort
        public static void HeapSort(int[] v)
        {
            MontaMaxHeap(v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {
                RealizaTroca(v, i, 0);
                contTrocas++;
                ReorganizarHeap(v, 0, --n);
                contTest++;
                
            }
            
        }

        // Divide o vetor pela metade -1 e verifica valores
        private static void MontaMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                ReorganizarHeap(v, i, v.Length);

        }

        // Método Merge Sort O(n log n)
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
            contTrocas++;
        }
        #endregion

        #region MergeSort
        private static void Merge(int[] v, int i, int m, int j)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
            {
                temp[k - i] = v[k];
                contTest++;
            }             

            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                if (temp[esq] <= v[dir])
                {
                    v[i++] = temp[esq++];
                    contTest++;
                }
                
                else
                {
                    v[i++] = v[dir++];
                    contTest++;
                }
                contTest++;

            }
            while (esq < k)
                v[i++] = temp[esq++];
        }
        public static void MergeSort(int[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int m = (esq + dir) / 2;
                MergeSort(vet, esq, m);
                MergeSort(vet, m + 1, dir);
                Merge(vet, esq, m, dir);
            }
        }
        #endregion
    }
}

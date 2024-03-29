﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class ExercicioMaxMin
    {
        static void Main(string[] args)
        {
            int cont = 0;

            int[] vetRand = new int[1000];
            int[] vetCre = new int[1000];
            int[] vetDec = new int[1000];
            MaxMin m = new MaxMin();

            Console.Title = "==== Exercicio MaxMin - Prática 4 ====";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            
            PreencheAleatorio(ref vetRand);
            PreencheDecrescente(ref vetDec);
            PreencheCrescente(ref vetCre);

            Console.WriteLine("\n\n=== Quantidade de Testes MaxMin 1 ===");
            Console.WriteLine("| Teste 1 Vet Crescente: {0}", m.MaxMin1(vetCre, cont));
            Console.WriteLine("| Teste 1 Vet Decrescente: {0}", m.MaxMin1(vetDec, cont));
            Console.WriteLine("| Teste 1 Vet Aleatório: {0}", m.MaxMin1(vetRand, cont));

            Console.WriteLine("\n\n=== Teste MaxMin 2 ===");
            Console.WriteLine("| Teste 2 Vet Crescente: {0}", m.MaxMin2(vetCre, cont));
            Console.WriteLine("| Teste 2 Vet Decrescente: {0}", m.MaxMin2(vetDec, cont));
            Console.WriteLine("| Teste 2 Vet Aleatório: {0}", m.MaxMin2(vetRand, cont));

            Console.WriteLine("\n\n===Teste MaxMin 3");
            Console.WriteLine("| Teste 3 Vet Crescente: {0}", m.MaxMin3(vetCre, cont));
            Console.WriteLine("| Teste 3 Vet Decrescente: {0}", m.MaxMin3(vetDec, cont));
            Console.WriteLine("| Teste 3 Vet Aleatório: {0}", m.MaxMin3(vetRand, cont));

            Console.ReadKey();
        }

        static int[] PreencheAleatorio(ref int[] array)
        {
            Random r = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(0, 1001);

            return array;
        }
        static int[] PreencheDecrescente(ref int[] array)
        {
            int cont = 0;

            for (int i = array.Length; i > 0; i--)
                array[cont++] = i;

            return array;
        }
        static int[] PreencheCrescente(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = i;

            return array;
        }
    }
}

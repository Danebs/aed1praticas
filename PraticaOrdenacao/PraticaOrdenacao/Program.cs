﻿using System;
using System.Windows.Forms;

namespace Pratica5 {
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo. Thread em execução
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormOrdenacao()); // Inicializa classe de Form
        }
    }
}

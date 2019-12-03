using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5 {
    public partial class FormOrdenacao : Form {
        int[] vet = new int[500]; // vetor interno para a animação
        int esq, dir;

        public FormOrdenacao() {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < vet.Length; i++) {
                e.Graphics.DrawLine(Pens.Chocolate, i, 299, i, 299 - vet[i]);
            }
        }

       

        // TODO: animação e estatísticas dos demais métodos de ordenação

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(this, 
                "Métodos de Ordenação - 2019/2\n\nDesenvolvido por:\n71900772 - Daniel Batista da Silva\n\nAlgoritmos e Estruturas de Dados\nFaculdade COTEMIG\nSomente para fins didáticos.", 
                "Sobre o trabalho...", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void IniciarAnimacao(Action a) {
            if (bgw.IsBusy != true) {
                if (radioAsc.Checked) {
                    Preenchimento.Crescente(vet, 299);
                    bgw.RunWorkerAsync(a);
                }  else if (radioDec.Checked) {
                    Preenchimento.Decrescente(vet, 299);
                    bgw.RunWorkerAsync(a);
                } else {
                    Preenchimento.Aleatorio(vet, 299);
                    bgw.RunWorkerAsync(a);
                }
            }
            else {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Métodos de Ordenação - 2019/2",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        // Metoodos de Renderização 
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            MessageBox.Show(this,
               "Animação concluída!",
               "Métodos de Ordenação - 2019/2",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.BubbleSort(vet, panel));
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.MergeSort(vet, 0, vet.Length - 1, panel));
        }

        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.QuickSort(vet, 0, vet.Length - 1, panel));
        }

        private void heapSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel));
        }

        private void shellSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel));
        }

        private void insercaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.InsertionSort(vet, panel));
        }

        private void selecaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarAnimacao(() => OrdenacaoGrafica.SelectionSort(vet, panel));
        }

        private static void ExibePainelResultado(object sender, EventArgs e)
        {

        }

        //METODOS ESTATISTICOS
        #region Bolha
        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];

            if (radioAsc.Checked)
            {
                Preenchimento.Crescente(vet, tamanho);
                preenchimento = "Crescente";
            }
            else if (radioDec.Checked)
            {
                Preenchimento.Decrescente(vet, tamanho);
                preenchimento = "Decrescente";
            }
            else if (radioAleatorio.Checked)
            {
                Preenchimento.Aleatorio(vet, tamanho);
                preenchimento = "Aleatório";
            }


            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.BubbleSort(vet);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido


            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação Inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método Bolha",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

            OrdenacaoEstatistica.contTest = 0; //ao final do método eu zero os contadores
            OrdenacaoEstatistica.contTrocas = 0;
        }
        #endregion

        #region Seleção
        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
        
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);

            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            IniciarAnimacao(() => OrdenacaoEstatistica.SeletionSort(vet));
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento + 
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método Seleção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;
        }
        #endregion

        #region Inserção
        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);
            
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            IniciarAnimacao(() => OrdenacaoEstatistica.InsertionSort(vet));
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método Inserção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;
        }
        #endregion

        #region ShellSort

        private void shellsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);
           
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            IniciarAnimacao(() => OrdenacaoEstatistica.ShellSort(vet));
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método ShellSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;
        }
        #endregion

        #region HeapSort
        private void heapsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);
            
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            IniciarAnimacao(() => OrdenacaoEstatistica.HeapSort(vet));
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método HeapSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;
        }
        #endregion

        #region QuickSort
        private void quicksortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);
            
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro

            esq = 0;
            dir = vet.Length - 1;
            IniciarAnimacao(() => OrdenacaoEstatistica.QuickSort(vet, esq, dir));

            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método QuickSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;

        }
        #endregion

        #region MergeSort
        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string preenchimento = "";
            vet = new int[Convert.ToInt32(comboBox1.SelectedValue)];
            Preenchimento.Aleatorio(vet, vet.Length);
            
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro

            int i, j;
            i = 0;
            j = vet.Length - 1;
            IniciarAnimacao(() => OrdenacaoEstatistica.MergeSort(vet, i, j));

            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + vet.Length +
                  "\nOrdenação inicial: " + preenchimento +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.contTest +
                  "\nNº de trocas: " + OrdenacaoEstatistica.contTrocas,
                  "Estatísticas do Método MergeSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            OrdenacaoEstatistica.contTest = 0;
            OrdenacaoEstatistica.contTrocas = 0;

        }
        #endregion
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void FormOrdenacao_Load(object sender, EventArgs e)
        {

        }
    }
       

        
    
}

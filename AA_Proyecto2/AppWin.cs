using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AA_Proyecto2
{
    public partial class AppWin : Form
    {

        public AppWin()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_load_Click(object sender, EventArgs e)
        {

        }

        //UI Usability
        private void sldr_size_ValueChanged(object sender, EventArgs e)
        {
            lbl_sizeNum.Text = sldr_size.Value.ToString();
        }

        private void sldr_thread_ValueChanged(object sender, EventArgs e)
        {
            lbl_threadNum.Text = sldr_thread.Value.ToString();
        }

        private void btn_useThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_useThreads.Checked)
                lbl_threadNum.Text = sldr_thread.Value.ToString();
            else
                lbl_threadNum.Text = "";
            sldr_thread.Enabled = btn_useThreads.Checked;
            lbl_threadNum.Enabled = btn_useThreads.Checked;
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            String info = "IC-3002 - Análisis de Algoritmos, GR 1\n" +
                          "Profesor: José Carranza Rojas\n" +
                          "\n" +
                          "Proyecto 2: Killer Sudoku\n" +
                          "Elaborado por:\n" +
                          "  >  2017146886 = Carlos Roberto Esquivel Morales\n" +
                          "  >  2017100950 = José Fabio Hidalgo Rodríguez\n" +
                          "\n" +
                          "Semestre 2, 2018";
            MessageBox.Show(info, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecnica_Feyman
{
    public partial class Form1 : Form
    {
        int assuntos = 1, i = 0;
        static int j = -1;
        int indice = -1;
        List<Assuntos> meusAssuntos = new List<Assuntos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Process pStart = new Process();
            string link = "https://www.google.com.br/?gws_rd=cr&ei=sWo0WfmrJoKWwATqmbqQBg#q=" + txt1.Text;
            pStart.StartInfo = new ProcessStartInfo(@link);
            pStart.Start();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(indice != -1)
            {
                if (txt1.Text != "")
                {
                    Assuntos assunto = new Assuntos(txt1.Text, txt2.Text, salvarPontos());
                    meusAssuntos[indice] = assunto;
                    limparCampos();
                    indice = -1;
                }
            }
            if(txt1.Text != "")
            {
                Assuntos assunto = new Assuntos(txt1.Text, txt2.Text, salvarPontos());
                dataGridView1.Rows.Insert(i, assuntos++, assunto.assunto, assunto.sobre);
                i++;
                meusAssuntos.Add(assunto);
                limparCampos();
            }
        }

        private List<Pontos> salvarPontos()
        {
            List<Pontos> listaPonto = new List<Pontos>();
            if(textBox1.Text != "")
            {
                listaPonto.Add(new Pontos(textBox1.Text, checkBox1.Checked));
            }
            if (textBox2.Text != "")
            {
                listaPonto.Add(new Pontos(textBox2.Text, checkBox2.Checked));
            }
            if (textBox3.Text != "")
            {
                listaPonto.Add(new Pontos(textBox3.Text, checkBox3.Checked));
            }
            if (textBox4.Text != "")
            {
                listaPonto.Add(new Pontos(textBox4.Text, checkBox4.Checked));
            }
            if (textBox5.Text != "")
            {
                listaPonto.Add(new Pontos(textBox5.Text, checkBox5.Checked));
            }

            return listaPonto;
        }

        private void meusAssuntusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EsconderComponentes();
            dataGridView1.Visible = true;
        }

        private void EsconderComponentes()
        {
            foreach(Control c in Controls)
            {
                c.Visible = false;
            }
            menuStrip1.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novoAssuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirComponentes();
        }

        private void ExibirComponentes()
        {
            foreach(Control c in Controls)
            {
                c.Visible = true;
            }
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int j = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) -1;
            indice = j;
            txt1.Text = meusAssuntos[j].assunto;
            txt2.Text = meusAssuntos[j].sobre;
            try
            {
                for(int z = 0; z <meusAssuntos[j].listaPontos.Count; z++)
                {
                    switch (z)
                    {
                        case 0:
                            textBox1.Text = meusAssuntos[j].listaPontos[0].ponto;
                            checkBox1.Checked = meusAssuntos[j].listaPontos[0].dominado;
                            break;
                        case 1:
                            textBox2.Text = meusAssuntos[j].listaPontos[1].ponto;
                            checkBox2.Checked = meusAssuntos[j].listaPontos[1].dominado;
                            break;
                        case 2:
                            textBox3.Text = meusAssuntos[j].listaPontos[2].ponto;
                            checkBox3.Checked = meusAssuntos[j].listaPontos[2].dominado;
                            break;
                        case 3:
                            textBox4.Text = meusAssuntos[j].listaPontos[3].ponto;
                            checkBox4.Checked = meusAssuntos[j].listaPontos[3].dominado;
                            break;
                        case 4:
                            textBox5.Text = meusAssuntos[j].listaPontos[4].ponto;
                            checkBox5.Checked = meusAssuntos[j].listaPontos[4].dominado;
                            break;
                    }
                }
                ExibirComponentes();
            }
            catch (Exception)
            {
                throw;
            }
            ExibirComponentes();
            
        }

        private void limparCampos()
        {
            txt1.Text = "";
            txt2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

        }
    }

    class Assuntos
    {
        public Assuntos(string assunto, string sobre, List<Pontos> listaPontos)
        {
            this.assunto = assunto;
            this.sobre = sobre;
            this.listaPontos = listaPontos;
        }
        public string assunto;
        public string sobre;
        public List<Pontos> listaPontos = new List<Pontos>();
    }

    class Pontos
    {
        public Pontos(string ponto, bool dominado)
        {
            this.ponto = ponto;
            this.dominado = dominado;
        }

        public string ponto;
        public bool dominado;
    }
}

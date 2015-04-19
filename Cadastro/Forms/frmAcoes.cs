using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class frmAcoes : Form
    {
        public User user;
        public seriePanel[] painel = new seriePanel[4];
        public int last = 0,qSeries = 0;
        public frmAcoes(User usuario)
        {
            InitializeComponent();
            this.user = usuario;
        }

        private void frmAcoes_Load(object sender, EventArgs e)
        {
            InicializaPaineis();
            qSeries = this.user.series.cont;
            btnClicks();
            CarregaSeries();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbClass dbc = new dbClass();
            User back = dbc.verificaUsuario(this.user.login, this.user.senha);
            this.user = back;
            qSeries = back.series.cont; 
            last = 0;
            limpaPaineis();
            CarregaSeries();
        }
        private void CarregaSeries()
        {
            if (this.user.series.cont > 0)
            {
                List<Serie> series = this.user.series.series;
                for (int i = 0; i < 4; i++)
                {
                    if (qSeries <= i) break;
                    Serie j = series.ElementAt((i + last)%qSeries);
                    painel[i].lblEp.Text ="Episódio: "+ j.serieEp;
                    painel[i].lblNome.Text ="Nome: "+ j.serieNome;
                    painel[i].lblTemporada.Text ="Temporada: "+ j.serieTemporada;
                    try
                    {
                        painel[i].img.Image = Image.FromFile(j.serieImgSrc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao abrir imagem, " + ex);
                    }
                    painel[i].serie = j;
                }
                last = (last + 4) % qSeries ;
            }
            timer1.Enabled = true;
        }
        private void atualizaPaineis()
        {
            
            for (int i = 0; i < 4; i++)
            {
                if (qSeries <= i) break;
                painel[i].lblEp.Text = "Episódio: " + painel[i].serie.serieEp;
                painel[i].lblTemporada.Text = "Temporada: " + painel[i].serie.serieTemporada;
            }
        }
        private void btnClicks()
        {
            painel[0].btnNextEp.Click += new System.EventHandler(painel[0].btnNextEpClick);
            painel[1].btnNextEp.Click += new System.EventHandler(painel[1].btnNextEpClick);
            painel[2].btnNextEp.Click += new System.EventHandler(painel[2].btnNextEpClick);
            painel[3].btnNextEp.Click += new System.EventHandler(painel[3].btnNextEpClick);

            painel[0].btnPrevEp.Click += new System.EventHandler(painel[0].btnPrevEpClick);
            painel[1].btnPrevEp.Click += new System.EventHandler(painel[1].btnPrevEpClick);
            painel[2].btnPrevEp.Click += new System.EventHandler(painel[2].btnPrevEpClick);
            painel[3].btnPrevEp.Click += new System.EventHandler(painel[3].btnPrevEpClick);

            painel[0].btnNextSerie.Click += new System.EventHandler(painel[0].btnNextSerieClick);
            painel[1].btnNextSerie.Click += new System.EventHandler(painel[1].btnNextSerieClick);
            painel[2].btnNextSerie.Click += new System.EventHandler(painel[2].btnNextSerieClick);
            painel[3].btnNextSerie.Click += new System.EventHandler(painel[3].btnNextSerieClick);

            painel[0].btnPrevSerie.Click += new System.EventHandler(painel[0].btnPrevSerieClick);
            painel[1].btnPrevSerie.Click += new System.EventHandler(painel[1].btnPrevSerieClick);
            painel[2].btnPrevSerie.Click += new System.EventHandler(painel[2].btnPrevSerieClick);
            painel[3].btnPrevSerie.Click += new System.EventHandler(painel[3].btnPrevSerieClick); 
        }
        private void InicializaPaineis()
        {
            //1
            painel[0] = new seriePanel(panel1);
            painel[0].img = img1;
            painel[0].lblEp = lblEp;
            painel[0].lblNome = lblNome;
            painel[0].lblTemporada = lblTemp;

            painel[0].btnNextEp = button2;
            painel[0].btnPrevEp = button3;
            painel[0].btnNextSerie = button4;
            painel[0].btnPrevSerie = button5;
            //2
            painel[1] = new seriePanel(panel2);
            painel[1].img = img2;
            painel[1].lblEp = label2;
            painel[1].lblNome = label3;
            painel[1].lblTemporada = label1;

            painel[1].btnNextEp = button9;
            painel[1].btnPrevEp = button8;
            painel[1].btnNextSerie = button7;
            painel[1].btnPrevSerie = button6;
            //3
            painel[2] = new seriePanel(panel3);
            painel[2].img = img3;
            painel[2].lblEp = label5;
            painel[2].lblNome = label6;
            painel[2].lblTemporada = label4;

            painel[2].btnNextEp = button13;
            painel[2].btnPrevEp = button12;
            painel[2].btnNextSerie = button11;
            painel[2].btnPrevSerie = button10;
            //4
            painel[3] = new seriePanel(panel4);
            painel[3].img = img4;
            painel[3].lblEp = label8;
            painel[3].lblNome = label9;
            painel[3].lblTemporada = label7;

            painel[3].btnNextEp = button17;
            painel[3].btnPrevEp = button16;
            painel[3].btnNextSerie = button15;
            painel[3].btnPrevSerie = button14;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CarregaSeries();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            frmCadSeries cad = new frmCadSeries(this.user);
            cad.Show();
        }

        private void frmAcoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualizaPaineis();
        }

        private void btnExcluirSerie_Click(object sender, EventArgs e)
        {
            frmExcluiSerie ex = new frmExcluiSerie(this.user);
            ex.Show();
        }
        private void limpaPaineis()
        {
            foreach (seriePanel i in painel)
            {
                i.img.Image = null;
                i.lblEp.Text = "Episodio: ";
                i.lblNome.Text = "Nome: ";
                i.lblTemporada.Text = "Temporada: ";
            }
        }
    }
}

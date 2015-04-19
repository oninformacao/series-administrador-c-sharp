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
    public partial class frmCadSeries : Form
    {
        public User user;
        public Serie serie;
        public frmCadSeries(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.serie = new Serie(this.user.id, txtNome.Text, txtEp.Text, txtTemporada.Text, txtCategoria.Text, txtImgSrc.Text);
            dbClass dbc = new dbClass();
            if (dbc.cadastraSerie(this.serie))
            {
                MessageBox.Show("Série cadastrada!","Séries Manager",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            Form frmAcoes = Application.OpenForms["frmAcoes"];
            Button btnRecarregar = (Button) frmAcoes.Controls["btnRecarregar"];
            btnRecarregar.PerformClick();
            this.Close();
        }

        private void frmCadSeries_Load(object sender, EventArgs e)
        {
            txtUser.Text = this.user.login;
        }

        private void txtImgSrc_Click(object sender, EventArgs e)
        {
            open.ShowDialog();
            txtImgSrc.Text = open.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

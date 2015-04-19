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
    public partial class frmExcluiSerie : Form
    {
        public User user;
        public frmExcluiSerie(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void frmExcluiSerie_Load(object sender, EventArgs e)
        {
            foreach (Serie i in this.user.series.series)
            {
                cmbSeries.Items.Add("Nome: - "+i.serieNome+" - "+i.serieEp+" - "+i.serieTemporada+" -");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Serie name = this.user.series.series.ElementAt(cmbSeries.Items.IndexOf(cmbSeries.Text));
            dbClass dbc = new dbClass();
            if (dbc.excluiSerie(name))
            {
                MessageBox.Show("Série excluida!");
            }
            Form frmAcoes = Application.OpenForms["frmAcoes"];
            Button btn = (Button) frmAcoes.Controls["btnRecarregar"];
            btn.PerformClick();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

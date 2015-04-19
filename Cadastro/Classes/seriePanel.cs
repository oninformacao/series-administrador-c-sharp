using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public class seriePanel : Panel
    {
        public PictureBox img;
        public Label lblNome;
        public Label lblTemporada;
        public Label lblEp;

        public Button btnNextSerie;
        public Button btnPrevSerie;

        public Button btnNextEp;
        public Button btnPrevEp;

        private Panel panel;
        private Serie _serie;

        public seriePanel(Panel panel)
        {
            this.panel = panel;
        }
        
        public void enable()
        {
            this.panel.Enabled = true;
        }
        public void disable()
        {
            this.panel.Enabled = false;
        }

        public void btnNextSerieClick(object obj, EventArgs eva)
        {
            //proxima série //temporada
            int temp;
            try
            {
                temp = Convert.ToInt32(this._serie.serieTemporada);
                temp++;
                this._serie.serieTemporada = temp.ToString();
                atualizaSerie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
        }
        public void btnPrevSerieClick(object obj, EventArgs eva)
        {
            //série anterio //temporada
            int temp;
            try
            {
                temp = Convert.ToInt32(this._serie.serieTemporada);
                temp--;
                this._serie.serieTemporada = temp.ToString();
                atualizaSerie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
        }
        public void btnNextEpClick(object obj, EventArgs eva)
        {
            int ep;
            try
            {
                ep = Convert.ToInt32(this._serie.serieEp);
                ep++;
                this._serie.serieEp = ep.ToString();
                atualizaSerie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
        }
        public void btnPrevEpClick(object obj, EventArgs eva)
        {
            //ep anterior
            int ep;
            try
            {
                ep = Convert.ToInt32(this._serie.serieEp);
                ep--;
                this._serie.serieEp = ep.ToString();
                atualizaSerie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
        }
        public void atualizaSerie()
        {
            dbClass dbc = new dbClass();
            dbc.atualizaSerie(this._serie);
        }
        public Serie serie { get { return _serie; } set { _serie = value; } }
    }
}

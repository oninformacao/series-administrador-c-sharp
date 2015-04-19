using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Cadastro
{
    public partial class testForm : Form
    {
        dbClass dbc = new dbClass();
        public testForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void testForm_Load(object sender, EventArgs e)
        {
            

            textBox1.Text += dbc.verificaUsuario("teste", "teste");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.usuariosCS);
            OleDbCommand cmd = new OleDbCommand(textBox1.Text, con);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                textBox1.Text += i.ToString();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
        }
    }
}

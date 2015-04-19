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
    public partial class frmCadUser : Form
    {
        User user = null;
        public frmCadUser()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
        }
        public frmCadUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void frmCadUser_Load(object sender, EventArgs e)
        {
            
        }

        private void frmCadUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmLogin = Application.OpenForms["frmLogin"];
            frmLogin.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User(-1,txtNome.Text,txtLogin.Text,txtSenha.Text,txtEmail.Text,comboBox1.Text,new Series());
            dbClass dbc = new dbClass();
            if (dbc.cadastraUsuario(newUser))
            {
                MessageBox.Show("Usuário cadastrado!");
                this.Close();
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if (txtLogin.TextLength < 8)
            {
                error.SetError(txtLogin, "O login deve ter no mínimo 8 carácteres!");
            }
            else
            {
                error.Dispose();
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.TextLength < 8)
            {
                error.SetError(txtSenha, "A senha deve ter no mínimo 8 carácteres e no máximo 16!");
            }
            else
            {
                error.Dispose();
            }
        }
    }
}

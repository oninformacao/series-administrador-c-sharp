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
    public partial class frmLogin : Form
    {
        dbClass dbc = new dbClass();
        public frmLogin()
        {
            InitializeComponent();
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtSenha.Text = Properties.Settings.Default.lastPass;
            txtLogin.Text = Properties.Settings.Default.lastUser;
            cbAutoLogin.Checked = Properties.Settings.Default.autoLogin;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            User user = dbc.verificaUsuario(txtLogin.Text, txtSenha.Text);
            if (user != null)
            {
                frmAcoes ac = new frmAcoes(user);
                this.Hide();
                ac.Show();
            }
            if (cbAutoLogin.Checked == true)
            {
                Properties.Settings.Default.lastUser = txtLogin.Text;
                Properties.Settings.Default.lastPass = txtSenha.Text;
                Properties.Settings.Default.autoLogin = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.lastUser = "";
                Properties.Settings.Default.lastPass = "";
                Properties.Settings.Default.autoLogin = false;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadUser ac = new frmCadUser();
            ac.Show();
            this.Hide();
        }

        
    }
}

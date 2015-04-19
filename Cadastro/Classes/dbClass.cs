using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cadastro
{
    class dbClass
    {
        OleDbConnection con;
        public dbClass()
        {
            con = new OleDbConnection(Properties.Settings.Default.usuariosCS);
        }
        public User verificaUsuario(string login,string senha)
        {
            User usuario = null;
            Series series = new Series();
            try
            {
                con.Open();
                //dados das series
                
              
                string userCmd = "SELECT * FROM `tblUsers` WHERE `login`='" + login + "' and `senha`='" + senha + "'";
                OleDbCommand cmd = new OleDbCommand(userCmd, con);
                OleDbDataReader userReader = cmd.ExecuteReader();

                userReader.Read();
                int id = Convert.ToInt32(userReader.GetValue(0).ToString());
                string sqlSerie = "SELECT * FROM `tblSerie` WHERE `id`="+userReader.GetValue(0).ToString();
                OleDbCommand serieCmd = new OleDbCommand(sqlSerie, con);
                OleDbDataReader serieReader = serieCmd.ExecuteReader();

                while (serieReader.Read())
                {
                    string[] lst = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        lst[i] = serieReader.GetValue(i + 1).ToString();
                    }
                    Serie serie = new Serie(Convert.ToInt32(userReader.GetValue(0).ToString()),lst[0],lst[1],lst[2],lst[3],lst[4]);
                    series.addSerie(serie);
                }

                usuario = new User(Convert.ToInt32(userReader.GetValue(0).ToString()), userReader.GetValue(1).ToString(), userReader.GetValue(2).ToString(), userReader.GetValue(3).ToString(), userReader.GetValue(4).ToString(), userReader.GetValue(5).ToString(), series);
                //fim
                con.Close();
                cmd.Dispose();
                serieCmd.Dispose();
                serieReader.Close();
                userReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao abrir o banco de dados,"+ex);
            }
            con.Close();
            return usuario;
        }
        public Boolean cadastraSerie(Serie serie)
        {
            string sqlTeste =       "INSERT INTO tblSerie (id, serieNome, serieEpisodio, serieTemporada, serieCategoria, serieImgSrc) VALUES (" + serie.id + ",'" + serie.serieNome + "','" + serie.serieEp + "','" + serie.serieTemporada + "','" + serie.serieCategoria + "','" + serie.serieImgSrc + "')";
            string sqlCadastro =    "INSERT INTO tblSerie(`id`,`serieNome`,`serieEpisodio`,`serieTemporada`,`serieCategoria`,`serieImgSrc`) VALUES (" + serie.id + ",'" + serie.serieNome + "','" + serie.serieEp + "','" + serie.serieTemporada + "','" + serie.serieCategoria + "','" + serie.serieImgSrc + "')";
            OleDbCommand cmd = new OleDbCommand(sqlCadastro, con);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar, " + ex);
            }
            con.Close();
            return false;
        }
        public Boolean atualizaSerie(Serie serie)
        {

            string sqlUpdate = "UPDATE tblSerie SET serieEpisodio='" + serie.serieEp + "',serieTemporada='" + serie.serieTemporada + "' WHERE serieNome='"+serie.serieNome+"'";
            OleDbCommand cmd = new OleDbCommand(sqlUpdate, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
            return false;
        }
        public Boolean cadastraUsuario(User user)
        {
            string sqlCadastra = "INSERT INTO tblUsers(nome,login,senha,email,tipo) VALUES ('"+user.nome+
                "','"+user.login+"','"+user.senha+"','"+user.email+"','"+user.tipo+"')";
            OleDbCommand cmd = new OleDbCommand(sqlCadastra, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }

            return false;
        }
        public Boolean excluiSerie(Serie serie)
        {
            string sqlDelete = "DELETE FROM tblSerie WHERE serieNome='" + serie.serieNome + "' AND id="+serie.id;
            OleDbCommand cmd = new OleDbCommand(sqlDelete, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, " + ex);
            }
            return false;
        }
    }
}

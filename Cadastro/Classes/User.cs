using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class User
    {
        private int _id;        //0
        private string _nome;   //1
        private string _login;  //2
        private string _senha;  //3
        private string _email;  //4
        private string _tipo;   //5

        private Series _series;

        public int id{get { return _id; } }
        public string nome { get { return _nome; } }
        public string login { get { return _login; } }
        public string senha { get { return _senha; } }
        public string email { get { return _email; } }
        public string tipo { get { return _tipo; } }
        public Series series { get { return _series; } }

        public User(int id,string nome,string login,string senha,string email,string tipo,Series series)
        {
            this._id = id;
            this._nome = nome;
            this._login = login;
            this._senha = senha;
            this._email = email;
            this._tipo = tipo;

            this._series = series;
        }
    }
}

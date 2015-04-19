using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Serie
    {
        private int _id;
        private string _serieNome;
        private string _serieEp;
        private string _serieTemporada;
        private string _serieCategoria;
        private string _serieImgSrc;

        public int id { get { return _id; } }
        public string serieNome { get { return _serieNome; } }
        public string serieEp { get { return _serieEp; } set { _serieEp = value; } }
        public string serieTemporada { get { return _serieTemporada; } set { _serieTemporada = value; } }
        public string serieCategoria { get { return _serieCategoria; } }
        public string serieImgSrc { get { return _serieImgSrc; } }

        public Serie(int id,string serieNome,string serieEp,string serieTemporada,string serieCateroria,string serieImgSrc)
        {
            this._id = id;
            this._serieNome = serieNome;
            this._serieEp = serieEp;
            this._serieTemporada = serieTemporada;
            this._serieCategoria = serieCateroria;
            this._serieImgSrc = serieImgSrc;
        }
    }
}

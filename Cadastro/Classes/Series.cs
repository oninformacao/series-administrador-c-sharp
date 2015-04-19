using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Series
    {
        private List<Serie> _series = new List<Serie>();
        private int _cont;
        public Series()
        {
            _cont = 0;
        }
        public void addSerie(Serie serie)
        {
            this._series.Add(serie);
            this._cont++;
        }
        public List<Serie> series { get { return _series; } }
        public int cont { get { return _cont; } }
    }
}

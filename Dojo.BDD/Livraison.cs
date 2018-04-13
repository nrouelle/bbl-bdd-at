using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.BDD
{
    public class Livraison
    {
        private Dictionary<string, decimal> _prixLivraisons = null;

        public Livraison()
        {
            _prixLivraisons = new Dictionary<string, decimal>();
        }

        public void SetPrix(string pays, decimal prix)
        {
            _prixLivraisons[pays] = prix;
        }

        internal decimal GetPrix(string pays)
        {
            return _prixLivraisons[pays];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        public int PrixPoire { get; set; }
        public int PrixPomme { get; set; }
        public Panier Panier { get; set; }

        public int NbPoireAchetee { get; set; }
        public int NbPoireOfferte { get; set; }

        public CaisseEnregistreuse()
        {
            Panier = new Panier();
        }

        public double CalculerPrixPanier()
        {
            if (NbPoireAchetee != 0)
            {
                decimal d = Panier.NbPoire / NbPoireAchetee;
                Panier.AjouterPoire(-NbPoireOfferte * (int)Math.Floor(d));
            }

            return Panier.NbPoire * PrixPoire + Panier.NbPomme * PrixPomme;
        }

        public void AjouterPromoPoire(int nbPoireAchetee, int nbPoireOfferte)
        {
            NbPoireAchetee = nbPoireAchetee;
            NbPoireOfferte = nbPoireOfferte;
        }
    }
}

using System;

namespace Dojo.BDD
{
    public class Panier
    {
        public int NbPoire { get; private set; }
        public int NbPomme { get; private set; }

        public Panier()
        {
            NbPoire = 0;
            NbPomme = 0;
        }

        public void AjouterPoire(int nbPoire)
        {
            NbPoire += nbPoire;
        }

        public void AjouterPomme(int nbPomme)
        {
            NbPomme += nbPomme;

        }
    }
}
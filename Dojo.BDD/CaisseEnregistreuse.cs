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
        public Panier Panier { get; set; }

        public int NbPoireAchetee { get; set; }
        public int NbPoireOfferte { get; set; }
        public Dictionary<TypeDeFruit, int> PrixFruits { get; set; }

        public CaisseEnregistreuse()
        {
            Panier = new Panier();
            PrixFruits = new Dictionary<TypeDeFruit, int>();

            foreach (var typeDeFruit in Enum.GetValues(typeof(TypeDeFruit)))
            {
                PrixFruits[(TypeDeFruit)typeDeFruit] = 0;
            }
        }

        public void SetPrixFruit(TypeDeFruit typeDeFruit, int prix)
        {
            PrixFruits[typeDeFruit] = prix;
        }

        public double CalculerPrixPanier()
        {
            if (NbPoireAchetee != 0)
            {
                decimal d = Panier.Contenu[TypeDeFruit.Poire] / NbPoireAchetee;
                Panier.AjouterFruits(TypeDeFruit.Poire, -NbPoireOfferte * (int)Math.Floor(d));
            }

            int prixTotal = 0;
            foreach (var fruits in Panier.Contenu)
            {
                prixTotal += fruits.Value * PrixFruits[fruits.Key];
            }

            return prixTotal;
        }

        public void AjouterPromoPoire(int nbPoireAchetee, int nbPoireOfferte)
        {
            NbPoireAchetee = nbPoireAchetee;
            NbPoireOfferte = nbPoireOfferte;
        }
    }
}

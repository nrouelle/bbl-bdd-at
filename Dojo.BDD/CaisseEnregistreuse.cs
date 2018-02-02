using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        public Panier Panier { get; }

        public int PromoNbPoireAchetee { get; set; }
        public int PromoNbPoireOfferte { get; set; }
        public Dictionary<TypeDeFruit, int> PrixFruits { get; }

        public bool EstPromo10Activee { get; set; }

        public bool EstPromoPoireOfferteActivee { get; set; }

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
            var remise = 0;

            var prixTotal = 0;

            if (EstPromo10Activee && Panier.Contenu.Sum(f => f.Value) >= 10)
            {
                var typeFruit = RecupererFruitLePlusCher(Panier.Contenu);
                remise += PrixFruits[typeFruit];
            }
            else if (EstPromoPoireOfferteActivee)
            {
                decimal nombreDeFoisPromoAppliquee = Panier.Contenu[TypeDeFruit.Poire] / PromoNbPoireAchetee;

                var nombrePoireOfferte = PromoNbPoireOfferte * (int)Math.Floor(nombreDeFoisPromoAppliquee);
                remise += PrixFruits[TypeDeFruit.Poire] * nombrePoireOfferte;
            }

            foreach (var fruits in Panier.Contenu)
            {
                prixTotal += fruits.Value * PrixFruits[fruits.Key];
            }
            
            return prixTotal - remise;
        }

        private TypeDeFruit RecupererFruitLePlusCher(Dictionary<TypeDeFruit, int> panierContenu)
        {
            var panierOrdonne = panierContenu.Where(kv => kv.Value > 0).OrderBy(kv => PrixFruits[kv.Key]);

            var fruitLePlusCher = panierOrdonne.Last();

            return fruitLePlusCher.Key;
        }

        public void AjouterPromoPoire(int nbPoireAchetee, int nbPoireOfferte)
        {
            if (nbPoireAchetee <= 0) throw new ArgumentOutOfRangeException(nameof(nbPoireAchetee));

            EstPromoPoireOfferteActivee = true;
            PromoNbPoireAchetee = nbPoireAchetee;
            PromoNbPoireOfferte = nbPoireOfferte;
        }


        internal void ActiverPromo10()
        {
            EstPromo10Activee = true;
        }
    }
}

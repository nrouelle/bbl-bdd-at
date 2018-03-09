using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        public Dictionary<TypeDeFruit, int> PrixFruits { get; }

        private List<IPromotion> ListePromotions;

        public CaisseEnregistreuse()
        {
            ListePromotions = new List<IPromotion>();
            PrixFruits = new Dictionary<TypeDeFruit, int>();

            foreach (var typeDeFruit in Enum.GetValues(typeof(TypeDeFruit)))
            {
                PrixFruits[(TypeDeFruit)typeDeFruit] = 0;
            }
        }

        public void AjouterPromotion(IPromotion promotion)
        {
            this.ListePromotions.Add(promotion);
        }

        public void SetPrixFruit(TypeDeFruit typeDeFruit, int prix)
        {
            PrixFruits[typeDeFruit] = prix;
        }

        public double CalculerPrixPanier(Panier panier)
        {
            var remise = 0;
            var prixTotal = 0;

            foreach (var promotion in ListePromotions)
            {
                remise += promotion.CalculerRemise(panier, PrixFruits);
            }
            
            foreach (var fruits in panier.Contenu)
            {
                prixTotal += fruits.Value * PrixFruits[fruits.Key];
            }
            
            return prixTotal - remise;
        }
    }
}

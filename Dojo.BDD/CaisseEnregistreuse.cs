using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        public Dictionary<TypeDeFruit, decimal> PrixFruits { get; }

        public decimal PrixLivraison { get; private set; }

        private List<IPromotion> ListePromotions;

        private bool doitEtreLivrer;

        public CaisseEnregistreuse()
        {
            ListePromotions = new List<IPromotion>();
            PrixFruits = new Dictionary<TypeDeFruit, decimal>();

            foreach (var typeDeFruit in Enum.GetValues(typeof(TypeDeFruit)))
            {
                PrixFruits[(TypeDeFruit)typeDeFruit] = 0;
            }
        }

        public void AjouterPromotion(IPromotion promotion)
        {
            this.ListePromotions.Add(promotion);
        }

        public void SetPrixFruit(TypeDeFruit typeDeFruit, decimal prix)
        {
            PrixFruits[typeDeFruit] = prix;
        }

        public decimal CalculerPrixPanier(Panier panier)
        {
            decimal remise = 0;
            decimal prixTotal = 0;

            foreach (var promotion in ListePromotions)
            {
                remise += promotion.CalculerRemise(panier, PrixFruits);
            }
            
            foreach (var fruits in panier.Contenu)
            {
                prixTotal += fruits.Value * PrixFruits[fruits.Key];
            }

            if (doitEtreLivrer)
                prixTotal += PrixLivraison;

            return prixTotal - remise;
        }

        public void DefinirTarifLivraison(string paysDeLivraison, decimal prixLivraison)
        {
            this.PrixLivraison = prixLivraison;
        }

        public void DemandeLivraison(string paysDeLivraison)
        {
            this.doitEtreLivrer = true;
        }
    }
}

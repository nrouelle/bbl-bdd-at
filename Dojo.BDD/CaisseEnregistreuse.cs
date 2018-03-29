using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        public Dictionary<TypeDeFruit, decimal> PrixFruits { get; }

        private Dictionary<string, decimal> _prixLivraisons = null;
        public Dictionary<string, decimal> PrixLivraisons
        {
            get
            {
                if(_prixLivraisons == null)
                    _prixLivraisons = new Dictionary<string, decimal>();

                return _prixLivraisons;
            }
        }

        private List<IPromotion> ListePromotions;

        private string paysDeLivraison;

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

            if (!string.IsNullOrEmpty(paysDeLivraison))
                prixTotal += PrixLivraisons[paysDeLivraison];

            return prixTotal - remise;
        }

        public void DefinirTarifLivraison(string paysDeLivraison, decimal prixLivraison)
        {
            this.PrixLivraisons[paysDeLivraison] = prixLivraison;
        }

        public void DemandeLivraison(string paysDeLivraison)
        {
            if (!this.PrixLivraisons.ContainsKey(paysDeLivraison))
                throw new Exception($"La livraison en {paysDeLivraison} est impossible.");
            this.paysDeLivraison = paysDeLivraison;
        }
    }
}

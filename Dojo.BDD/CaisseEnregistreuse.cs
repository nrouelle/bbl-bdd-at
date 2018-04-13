using System;
using System.Collections.Generic;
using System.Linq;
using Dojo.BDD.Exceptions;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        private Dictionary<TypeDeFruit, decimal> PrixFruits { get; }

        private Dictionary<string, decimal> _prixLivraisons = null;

        private readonly List<IPromotion> _listePromotions;

        private string paysDeLivraison;

        public Dictionary<string, decimal> PrixLivraisons
        {
            get
            {
                if(_prixLivraisons == null)
                    _prixLivraisons = new Dictionary<string, decimal>();

                return _prixLivraisons;
            }
        }

        public CaisseEnregistreuse()
        {
            _listePromotions = new List<IPromotion>();
            PrixFruits = new Dictionary<TypeDeFruit, decimal>();

            foreach (var typeDeFruit in Enum.GetValues(typeof(TypeDeFruit)))
            {
                PrixFruits[(TypeDeFruit)typeDeFruit] = 0;
            }
        }

        public void AjouterPromotion(IPromotion promotion)
        {
            this._listePromotions.Add(promotion);
        }

        public void SetPrixFruit(TypeDeFruit typeDeFruit, decimal prix)
        {
            var maxFruit = Enum.GetValues(typeof(TypeDeFruit)).Cast<TypeDeFruit>().Max();

            if ((int) typeDeFruit > (int)maxFruit)
            {
                throw new Exception("Type de fruit non supporté");
            }

            PrixFruits[typeDeFruit] = prix;
        }

        public decimal CalculerPrixPanier(Panier panier)
        {
            if (panier == null)
            {
                throw new PanierNullException();
            }

            decimal remise = 0;
            decimal prixTotal = 0;

            foreach (var promotion in _listePromotions)
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
            if (string.IsNullOrEmpty(paysDeLivraison))
            {
                throw new Exception();
            }
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

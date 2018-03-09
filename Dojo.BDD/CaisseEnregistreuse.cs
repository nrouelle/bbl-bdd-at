using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class CaisseEnregistreuse
    {
        //public panier panier { get; }

        public int PromoNbPoireAchetee { get; set; }
        public int PromoNbPoireOfferte { get; set; }
        public Dictionary<TypeDeFruit, int> PrixFruits { get; }

        public bool EstPromo10Activee { get; set; }

        public bool EstPromoPoireOfferteActivee { get; set; }

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

            if (EstPromo10Activee && panier.Contenu.Sum(f => f.Value) >= 10)
            {
                var typeFruit = RecupererFruitLePlusCher(panier.Contenu);
                remise += PrixFruits[typeFruit];
            }

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
        
        private TypeDeFruit RecupererFruitLePlusCher(Dictionary<TypeDeFruit, int> panierContenu)
        {
            var panierOrdonne = panierContenu.Where(kv => kv.Value > 0).OrderBy(kv => PrixFruits[kv.Key]);

            var fruitLePlusCher = panierOrdonne.Last();

            return fruitLePlusCher.Key;
        }

        public void AjouterPromoPoire(int nbPoireAchetee, int nbPoireOfferte)
        {
            var promoPoire = new PromoPoire(nbPoireAchetee, nbPoireOfferte);
            this.AjouterPromotion(promoPoire);
            EstPromoPoireOfferteActivee = true;
        }


        internal void ActiverPromo10()
        {
            //this.AjouterPromotion();
            EstPromo10Activee = true;
        }
    }
}

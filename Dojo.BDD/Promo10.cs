using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class Promo10 : IPromotion
    {
        private Dictionary<TypeDeFruit, decimal> PrixFruits;
        

        public decimal CalculerRemise(Panier panier, Dictionary<TypeDeFruit, decimal> prixFruits)
        {
            PrixFruits = prixFruits;
            if (panier.Contenu.Sum(f => f.Value) >= 10)
            {
                var typeFruit = RecupererFruitLePlusCher(panier.Contenu);
                return PrixFruits[typeFruit];
            }

            return 0;
        }

        private TypeDeFruit RecupererFruitLePlusCher(Dictionary<TypeDeFruit, int> panierContenu)
        {
            var panierOrdonne = panierContenu.Where(kv => kv.Value > 0).OrderBy(kv => PrixFruits[kv.Key]);

            var fruitLePlusCher = panierOrdonne.Last();

            return fruitLePlusCher.Key;
        }
    }
}
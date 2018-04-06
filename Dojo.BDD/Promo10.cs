using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class Promo10 : IPromotion
    {
        private Dictionary<TypeDeFruit, decimal> _prixFruits;
        

        public decimal CalculerRemise(Panier panier, Dictionary<TypeDeFruit, decimal> prixFruits)
        {
            _prixFruits = prixFruits;
            if (panier.Contenu.Sum(f => f.Value) >= 10)
            {
                var typeFruit = RecupererFruitLePlusCher(panier.Contenu);
                return _prixFruits[typeFruit];
            }

            return 0;
        }

        private TypeDeFruit RecupererFruitLePlusCher(Dictionary<TypeDeFruit, int> panierContenu)
        {
            var panierOrdonne = panierContenu.Where(kv => kv.Value > 0).OrderBy(kv => _prixFruits[kv.Key]);

            var fruitLePlusCher = panierOrdonne.Last();

            return fruitLePlusCher.Key;
        }
    }
}
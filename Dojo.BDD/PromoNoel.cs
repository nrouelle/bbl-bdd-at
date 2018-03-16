using System.Collections.Generic;
using System.Linq;

namespace Dojo.BDD
{
    public class PromoNoel : IPromotion
    {
        private readonly int _nbMandarineMinimum;
        private readonly decimal _pourcentage;

        public PromoNoel(int nbMandarineMinimum, decimal pourcentage)
        {
            _nbMandarineMinimum = nbMandarineMinimum;
            _pourcentage = pourcentage;
        }
        public decimal CalculerRemise(Panier panier, Dictionary<TypeDeFruit, decimal> prixFruits)
        {
            var nbMandarinePanier = panier.Contenu[TypeDeFruit.Mandarine];
            if (nbMandarinePanier > _nbMandarineMinimum)
            {
                return nbMandarinePanier * prixFruits[TypeDeFruit.Mandarine] * _pourcentage;
            }

            return 0;
        }
    }
}
using System.Collections.Generic;

namespace Dojo.BDD
{
    public interface IPromotion
    {
        decimal CalculerRemise(Panier panier, Dictionary<TypeDeFruit, decimal> PrixFruits);
    }
}

using System.Collections.Generic;

namespace Dojo.BDD
{
    public interface IPromotion
    {
        int CalculerRemise(Panier panier, Dictionary<TypeDeFruit, int> PrixFruits);
    }
}

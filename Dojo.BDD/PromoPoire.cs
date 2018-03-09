using System;
using System.Collections.Generic;

namespace Dojo.BDD
{
    public class PromoPoire : IPromotion
    {
        public PromoPoire(int nbPoireAchetee, int nbPoireOfferte)
        {
            if (nbPoireAchetee <= 0) throw new ArgumentOutOfRangeException(nameof(nbPoireAchetee));

            NbPoireAchetee = nbPoireAchetee;
            NbPoireOfferte = nbPoireOfferte;
        }

        public int NbPoireAchetee { get; }
        public int NbPoireOfferte { get; }

        public int CalculerRemise(Panier panier, Dictionary<TypeDeFruit, int> PrixFruits)
        {
            decimal nombreDeFoisPromoAppliquee = panier.Contenu[TypeDeFruit.Poire] / NbPoireAchetee;

            var nombrePoireOfferte = NbPoireOfferte * (int)Math.Floor(nombreDeFoisPromoAppliquee);
            var remise = PrixFruits[TypeDeFruit.Poire] * nombrePoireOfferte;
            return remise;
        }
    }
}
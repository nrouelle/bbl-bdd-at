using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dojo.BDD
{
    public class Panier
    {
        public Dictionary<TypeDeFruit, int> Contenu { get; set; }

        public Panier()
        {
            Contenu = new Dictionary<TypeDeFruit, int>();
        }

        public void AjouterFruits(TypeDeFruit typeDeFruit, int nbFruits)
        {
            if (!Contenu.ContainsKey(typeDeFruit))
            {
                Contenu[typeDeFruit] = 0;
            }

            Contenu[typeDeFruit] += nbFruits;
        }
    }
}
using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Dojo.BDD.Test
{
    [TestFixture]
    public class CaisseEnregistreuseShould
    {
        private readonly CaisseEnregistreuse caisse = new CaisseEnregistreuse();

        [TestFixture]
        public class AjouterPromotionShould : CaisseEnregistreuseShould
        { 
            [Test]
            public void NotThrowWhenAddNewIPromotion()
            {
                var promotionMock = new Mock<IPromotion>();
                caisse.AjouterPromotion(promotionMock.Object);
            }
        }

        [TestFixture]
        public class SetPrixFruitShould : CaisseEnregistreuseShould
        {
            [Test]
            public void NotThrowWhenSetPrixFruit()
            {
                caisse.SetPrixFruit(TypeDeFruit.Banane, 0);
            }

            [Test]
            public void ThrowWhenSetPrixForNonExistingFruit()
            {
                Assert.Throws<Exception>(() =>  caisse.SetPrixFruit((TypeDeFruit)8, 0));
            }
        }

        [TestFixture]
        public class CalculerPrixPanierShould : CaisseEnregistreuseShould
        {
            [Test]
            public void ReturnZeroIfPanierVide()
            {
                var panier = new Panier();
                Assert.AreEqual(0, caisse.CalculerPrixPanier(panier));
            }

            [Test]
            public void ReturnPrixPanier()
            {
                var prixBanane = 3;
                var panier = new Panier();
                caisse.SetPrixFruit(TypeDeFruit.Banane, prixBanane);
                panier.AjouterFruits(TypeDeFruit.Banane, 1);
                Assert.AreEqual(prixBanane, caisse.CalculerPrixPanier(panier));
            }

            [Test]
            public void ReturnPrixPanierAvecPromotion()
            {
                const int prixBanane = 3;
                const int remise = 2;
                var panier = new Panier();
                var promotionMock = new Mock<IPromotion>();

                promotionMock.Setup(x =>
                    x.CalculerRemise(It.IsAny<Panier>(), It.IsAny<Dictionary<TypeDeFruit, decimal>>()))
                .Returns(remise);

                caisse.AjouterPromotion(promotionMock.Object);
                caisse.SetPrixFruit(TypeDeFruit.Banane, prixBanane);
                panier.AjouterFruits(TypeDeFruit.Banane, 1);
                Assert.AreEqual(prixBanane - remise, caisse.CalculerPrixPanier(panier));
            }
        }
    }
}

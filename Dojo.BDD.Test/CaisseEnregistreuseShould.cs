using System;
using System.Collections.Generic;
using Dojo.BDD.Exceptions;
using Moq;
using NUnit.Framework;

namespace Dojo.BDD.Test
{
    [TestFixture]
    public class CaisseEnregistreuseShould
    {
        private CaisseEnregistreuse caisse;

        [SetUp]
        public void Init()
        {
            caisse = new CaisseEnregistreuse();
        }

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
                Assert.Throws<Exception>(() => caisse.SetPrixFruit((TypeDeFruit)8, 0));
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
                var prixPoire = 5;
                var panier = new Panier();
                caisse.SetPrixFruit(TypeDeFruit.Banane, prixBanane);
                caisse.SetPrixFruit(TypeDeFruit.Poire, prixPoire);

                panier.AjouterFruits(TypeDeFruit.Banane, 1);
                panier.AjouterFruits(TypeDeFruit.Poire, 1);

                Assert.AreEqual(prixBanane + prixPoire, caisse.CalculerPrixPanier(panier));
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

            [Test]
            public void ThrowIfPanierNull()
            {
                Panier panier = null;
                Assert.Throws<PanierNullException>(() => caisse.CalculerPrixPanier(panier));
            }
        }

        [TestFixture]
        public class DemandeLivraisonShould : CaisseEnregistreuseShould
        {
            [Test]
            public void NotThrowPaysLivraisonExiste()
            {
                var paysLivraison = "France";
               caisse.DefinirTarifLivraison(paysLivraison, 10);
                caisse.DemandeLivraison(paysLivraison);
            }

            [Test]
            public void ThrowWhenPaysLivraisonInexistant()
            {
                var paysFactice = "Abcdefghijklmnopqrstuvwxyz";
                Assert.Throws<Exception>(() => caisse.DemandeLivraison(paysFactice), $"La livraison en {paysFactice} est impossible.");
            }
        }

        [TestFixture]
        public class DefinirTarifLivraisonShould : CaisseEnregistreuseShould
        {
            [Test]
            public void HaveTarifLivraisonWhenSetPaysLivraison()
            {
                var paysLivraison = "France";
                caisse.DefinirTarifLivraison(paysLivraison, 10);
                Assert.IsTrue(caisse.PrixLivraisons.ContainsKey(paysLivraison));
            }
            [Test]
            public void HaveTarifLivraisonTo10WhenSetPaysLivraison()
            {
                var paysLivraison = "France";
                caisse.DefinirTarifLivraison(paysLivraison, 10);
                Assert.AreEqual(caisse.PrixLivraisons[paysLivraison], 10);
            }
            [Test]
            public void ThrowIfPaysLivraisonEmpty()
            {
                var paysLivraison = "";
                Assert.Throws<Exception>(() => caisse.DefinirTarifLivraison(paysLivraison, 10));
            }
        }
    }
}

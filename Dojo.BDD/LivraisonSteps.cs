using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Dojo.BDD
{
    [Binding]
    [Scope(Feature = "Livraison")]
    public class LivraisonSteps
    {
        public CaisseEnregistreuse Caisse { get; private set; }
        public Panier Panier { get; private set; }

        [Given(@"j'ai un panier de 10 euros")]
        public void GivenJAiUnPanierDe10Euros()
        {
            Panier = new Panier();

            Panier.AjouterFruits(TypeDeFruit.Poire, 1);
            Panier.AjouterFruits(TypeDeFruit.Pomme, 2);
            Panier.AjouterFruits(TypeDeFruit.Banane, 2);
        }

        [Given(@"j'ai un panier de 14 euros")]
        public void GivenJAiUnPanierDe14Euros()
        {
            Panier = new Panier();

            Panier.AjouterFruits(TypeDeFruit.Poire, 3);
            Panier.AjouterFruits(TypeDeFruit.Pomme, 2);
            Panier.AjouterFruits(TypeDeFruit.Banane, 2);
        }


        [BeforeScenario("CaisseEnregistreuseParDefaut", Order = 0)]
        public void CaisseEnregistreuseParDefaut()
        {
            Caisse = new CaisseEnregistreuse();

            Caisse.SetPrixFruit(TypeDeFruit.Pomme, 1);
            Caisse.SetPrixFruit(TypeDeFruit.Poire, 2);
            Caisse.SetPrixFruit(TypeDeFruit.Banane, 3);
        }

        [When(@"Le client se fait livrer en (.*)")]
        public void WhenLeClientSeFaitLivrerEn(string paysLivraison)
        {
            Caisse.DemandeLivraison(paysLivraison);
        }

        [Given(@"la livraison en (.*) vaut (.*)€")]
        public void GivenLaLivraisonEnVaut(string paysLivraison, decimal prixLivraison)
        {
            Caisse.DefinirTarifLivraison(paysLivraison, prixLivraison);
        }

        [When(@"La livraison n'est pas possible en (.*)")]
        public void WhenLeClientSeFaitLivrerDansUnPaysInterditEn(string paysLivraison)
        {
            Caisse.PrixLivraisons.Remove(paysLivraison);
        }

        [Then(@"La livraison est impossible en (.*)")]
        public void ThenLaLivraisonEstImpossible(string paysLivraison)
        {
            Assert.Throws<Exception>(() => Caisse.DemandeLivraison(paysLivraison));
        }

        [Then(@"il doit payer (.*)€")]
        public void ThenIlDoitPayer(decimal montantTotal)
        {
            Assert.AreEqual(montantTotal, Caisse.CalculerPrixPanier(Panier));
        }
    }
}

using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Dojo.BDD
{
    [Binding]
    public class CaisseEnregistreuseSteps
    {
        private int prxPoire;
        private int nombrePoire;

        public CaisseEnregistreuse Caisse { get; private set; }

        [Given(@"j'ai une caisse enregistreuse")]
        public void GivenJAiUneCaisseEnregistreuse()
        {
            Caisse = new CaisseEnregistreuse();
        }


        [Given(@"1 poire vaut (.*)€")]
        public void GivenPoireVaut(int prixPoire)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Poire, prixPoire);

        }

        [Given(@"1 pomme vaut (.*)€")]
        public void GivenPommeVaut(int prixPomme)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Pomme, prixPomme);
        }

        [Given(@"1 banane vaut (.*)€")]
        public void GivenBananeVaut(int prixBanane)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Banane, prixBanane);
        }

        [When(@"Un client achète (.*) poires et (.*) pommes et (.*) bananes")]
        public void WhenUnClientAchetePoiresEtPommesEtBananes(int nbPoire, int nbPomme, int nbBanane)
        {
            Caisse.Panier.AjouterFruits(TypeDeFruit.Poire, nbPoire);
            Caisse.Panier.AjouterFruits(TypeDeFruit.Pomme, nbPomme);
            Caisse.Panier.AjouterFruits(TypeDeFruit.Banane, nbBanane);
        }


        [When(@"Un client achète (.*) poires et (.*) pommes")]
        public void WhenClientAchetePoireEtPommes(int nbPoire, int nbPomme)
        {
            Caisse.Panier.AjouterFruits(TypeDeFruit.Poire, nbPoire);
            Caisse.Panier.AjouterFruits(TypeDeFruit.Pomme, nbPomme);
        }

        [Then(@"il doit payer (.*)€")]
        public void ThenIlDoitPayer(int montantTotal)
        {
            Assert.AreEqual(montantTotal, Caisse.CalculerPrixPanier());
        }

        [Given(@"pour (.*) poires achetées (.*) poire offerte")]
        public void GivenPourPoiresAcheteesPoireOfferte(int nbPoireAchetee, int nbPoireOfferte)
        {
            Caisse.AjouterPromoPoire(nbPoireAchetee, nbPoireOfferte);
        }

        [Given(@"pour 10 produits achetes le plus cher est offert")]
        public void GivenPourProduitsAchetesLePlusCherEstOffert()
        {
            Caisse.ActiverPromo10();
        }

    }
}

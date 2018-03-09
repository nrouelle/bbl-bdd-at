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
        public Panier Panier { get; private set; }

        [Given(@"j'ai une caisse enregistreuse")]
        public void GivenJAiUneCaisseEnregistreuse()
        {
            Caisse = new CaisseEnregistreuse();
            Panier = new Panier();
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
            Panier.AjouterFruits(TypeDeFruit.Poire, nbPoire);
            Panier.AjouterFruits(TypeDeFruit.Pomme, nbPomme);
            Panier.AjouterFruits(TypeDeFruit.Banane, nbBanane);
        }


        [When(@"Un client achète (.*) poires et (.*) pommes")]
        public void WhenClientAchetePoireEtPommes(int nbPoire, int nbPomme)
        {
            Panier.AjouterFruits(TypeDeFruit.Poire, nbPoire);
            Panier.AjouterFruits(TypeDeFruit.Pomme, nbPomme);
        }

        [Then(@"il doit payer (.*)€")]
        public void ThenIlDoitPayer(int montantTotal)
        {
            Assert.AreEqual(montantTotal, Caisse.CalculerPrixPanier(Panier));
        }

        [Given(@"pour (.*) poires achetées (.*) poire offerte")]
        public void GivenPourPoiresAcheteesPoireOfferte(int nbPoireAchetee, int nbPoireOfferte)
        {
            var promoPoire = new PromoPoire(nbPoireAchetee, nbPoireOfferte);
            Caisse.AjouterPromotion(promoPoire);
        }

        [Given(@"pour 10 produits achetes le plus cher est offert")]
        public void GivenPourProduitsAchetesLePlusCherEstOffert()
        {
            var promo10 = new Promo10();
            Caisse.AjouterPromotion(promo10);
        }

    }
}

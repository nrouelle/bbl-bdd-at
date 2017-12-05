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
            Caisse.PrixPoire = prixPoire;
            
        }
        
        [Given(@"1 pomme vaut (.*)€")]
        public void GivenPommeVaut(int prixPomme)
        {
            Caisse.PrixPomme = prixPomme;
        }
        
        [When(@"Un client achète (.*) poires et (.*) pommes")]
        public void WhenClientAchetePoireEtPommes(int nbPoire, int nbPomme)
        {
            Caisse.Panier.AjouterPoire(nbPoire);
            Caisse.Panier.AjouterPomme(nbPomme);
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

    }
}

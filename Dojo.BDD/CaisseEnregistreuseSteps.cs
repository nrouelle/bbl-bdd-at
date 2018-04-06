using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Dojo.BDD
{
    [Binding]
    [Scope(Feature = "CaisseEnregistreuse")]
    public class CaisseEnregistreuseSteps
    {
        [BeforeScenario("Panier10euros", Order = 1)]
        public void Panier10Euros()
        {
            Panier = new Panier();

            Panier.AjouterFruits(TypeDeFruit.Poire, 1);
            Panier.AjouterFruits(TypeDeFruit.Pomme, 2);
            Panier.AjouterFruits(TypeDeFruit.Banane, 2);
        }

        [BeforeScenario("Panier14euros", Order = 1)]
        public void Panier14Euros()
        {
            Panier = new Panier();

            Panier.AjouterFruits(TypeDeFruit.Poire, 3);
            Panier.AjouterFruits(TypeDeFruit.Pomme, 2);
            Panier.AjouterFruits(TypeDeFruit.Banane, 2);
        }

        [BeforeScenario("CaisseEnregistreuseParDefaut", Order=0)]
        public void CaisseEnregistreuseParDefaut()
        {
            Caisse = new CaisseEnregistreuse();

            Caisse.SetPrixFruit(TypeDeFruit.Pomme, 1);
            Caisse.SetPrixFruit(TypeDeFruit.Poire, 2);
            Caisse.SetPrixFruit(TypeDeFruit.Banane, 3);
        }

        public CaisseEnregistreuse Caisse { get; private set; }
        public Panier Panier { get; private set; }

        [Given(@"j'ai une caisse enregistreuse")]
        public void GivenJAiUneCaisseEnregistreuse()
        {
            Caisse = new CaisseEnregistreuse();
            Panier = new Panier();
        }


        [Given(@"1 poire vaut (.*)€")]
        public void GivenPoireVaut(decimal prixPoire)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Poire, prixPoire);

        }

        [Given(@"1 pomme vaut (.*)€")]
        public void GivenPommeVaut(decimal prixPomme)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Pomme, prixPomme);
        }

        [Given(@"1 banane vaut (.*)€")]
        public void GivenBananeVaut(decimal prixBanane)
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
        public void ThenIlDoitPayer(decimal montantTotal)
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
        [Given(@"1 mandarine vaut (.*)€")]
        public void GivenMandarineVaut(decimal prixMandarine)
        {
            Caisse.SetPrixFruit(TypeDeFruit.Mandarine, prixMandarine);
        }

        [Given(@"a partir de (.*) mandarines achetées une remise de (.*)% est consentie sur les mandarines")]
        public void GivenAPartirDeMandarinesAcheteesUneRemiseDeEstConsentieSurLesMandarines(int nbMandarinesMinimumAchetees, int pourcentageRemise)
        {
            var promoDeNoel = new PromoNoel(nbMandarinesMinimumAchetees, (decimal)pourcentageRemise/100);
            Caisse.AjouterPromotion(promoDeNoel);
        }

        [When(@"Un client achète (.*) mandarines")]
        public void WhenUnClientAcheteMandarines(int nbMandarine)
        {
            Panier.AjouterFruits(TypeDeFruit.Mandarine, nbMandarine);
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

        [StepArgumentTransformation(@"(\d*\.?\d*)€")]
        public decimal PriceToDecimalTransform(string price)
        {
            return decimal.Parse(price);
        }
    }
}

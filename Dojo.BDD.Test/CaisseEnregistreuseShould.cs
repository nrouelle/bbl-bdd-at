using System;
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
    }
}

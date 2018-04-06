using Moq;
using NUnit.Framework;

namespace Dojo.BDD.Test
{
    [TestFixture]
    public class CaisseEnregistreuseShould
    {
        [Test]
        public void NotThrowWhenAddNewIPromotion()
        {
            var caisse = new CaisseEnregistreuse();
            var promotionMock = new Mock<IPromotion>();
            caisse.AjouterPromotion(promotionMock.Object);
        }
    }
}

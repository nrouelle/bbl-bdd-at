using NUnit.Framework;

namespace Dojo.BDD.Test
{
    [TestFixture]
    public class LivraisonShould
    {
        [TestFixture]
        public class SetPrixShould : LivraisonShould
        {
            [Test]
            public void DoesNotThrowWhenSetPrixLivraisonPourUnPays()
            {
                var livraison = new Livraison();
                Assert.DoesNotThrow(() => livraison.SetPrix("France", 10));
            }

            [Test]
            public void SetPrixLivraisonPourUnPays()
            {
                var livraison = new Livraison();
                Assert.DoesNotThrow(() => livraison.SetPrix("France", 10));
            }
        }
    }
}

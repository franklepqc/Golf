using Golf.Biz.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Golf.Biz.Tests
{
    [TestClass]
    public class CalculScoreFinalTests
    {
        /// <summary>
        /// Service de calcul.
        /// </summary>
        private static ICalculScoreFinal _serviceCalculScoreFinal;

        /// <summary>
        /// Détermine à l'avance les pars du parcours neuf trous.
        /// </summary>
        private static byte[] PARS_PARCOURS_9;

        /// <summary>
        /// Initialise les pars des parcours.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void InitialiserParsParcoursEtService(TestContext testContext)
        {
            // Service.
            _serviceCalculScoreFinal = new CalculScoreFinal();

            // 9 trous.
            PARS_PARCOURS_9 = new byte[]
            {
                3,
                4,
                3,
                5,
                3,
                3,
                4,
                5,
                3
            };
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void PartieParNeufTrous_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                3,
                4,
                3,
                5,
                3,
                3,
                4,
                5,
                3
            };  // Tous les coups sont identiques.

            // Attendu.
            sbyte attendu = 0;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(PARS_PARCOURS_9, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void PartieNormaleUnNeufTrous_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                3,
                4,
                3,
                5,
                3,
                3,
                4,
                5,
                4       // Au 9ième trou, j'ai manqué un coup !
            };

            // Attendu.
            sbyte attendu = 1;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(PARS_PARCOURS_9, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void PartieNormaleMoinsUnNeufTrous_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                3,
                4,
                3,
                5,
                3,
                3,
                4,
                5,
                2       // Au 9ième trou, j'ai réussi un oiselet (birdie) !
            };

            // Attendu.
            sbyte attendu = -1;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(PARS_PARCOURS_9, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void PartieAleatoire1NeufTrous_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                5,
                3,
                3,
                6,
                5,
                4,
                3,
                4,
                3
            };

            // Attendu.
            sbyte attendu = 3;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(PARS_PARCOURS_9, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void AucunCoupsJoueur_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[0];

            // Attendu.
            sbyte attendu = 0;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(PARS_PARCOURS_9, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void AucunPars_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                5,
                3,
                3,
                6,
                4,
                4,
                2,
                4,
                2
            };

            // Attendu.
            sbyte attendu = 0;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(new byte[0], coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void PartieAleatoire1HuitTrous_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                5,
                3,
                3,
                6,
                4,
                4,
                2,
                5
            };
            byte[] pars = new byte[]
            {
                5,
                3,
                3,
                6,
                4,
                4,
                2,
                4
            };

            // Attendu.
            sbyte attendu = 0;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(pars, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }

        /// <summary>
        /// Parcours neuf trou parfait. Tous les coups sont sur la normale.
        /// </summary>
        [TestCategory("Service de calcul du score final")]
        [TestMethod]
        public void NullPars_Succes()
        {
            // Variables de travail.
            byte[] coupsJoueur = new byte[]
            {
                5,
                3,
                3,
                6,
                4,
                4,
                2,
                4,
                2
            };

            // Attendu.
            sbyte attendu = 0;

            // Actuel.
            var actuel = _serviceCalculScoreFinal.Calculer(null, coupsJoueur);

            // Assert.
            Assert.AreEqual(attendu, actuel);
        }
    }
}

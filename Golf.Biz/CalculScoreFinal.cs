using Golf.Biz.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;

namespace Golf.Biz
{
    /// <summary>
    /// Classe pour implémenter le calcul du score final d'une partie
    /// d'un joueur donné.
    /// </summary>
    public class CalculScoreFinal : Interfaces.ICalculScoreFinal
    {
        /// <summary>
        /// Calcul.
        /// </summary>
        /// <param name="pars">Pars pour le parcours au complet.</param>
        /// <param name="coupsJoueur">Coups (essais) du joueur par trous.</param>
        /// <param name="typePartie">Type de partie (9 ou 18 trous). 9 par défaut.</param>
        /// <returns>Score normal.</returns>
        public sbyte? Calculer(byte[] pars, byte[] coupsJoueur, TypePartieEnum typePartie = TypePartieEnum.Default)
        {
            // Variables de travail.
            var nombreTrous = (int)typePartie;

            // Vérifications.
            if (pars?.Length != nombreTrous ||
                coupsJoueur?.Length != nombreTrous)
            {
                Debug.WriteLine("Informations manquantes.");
                return null;
            }

            // Calcul avec Linq.
            return Convert.ToSByte((new byte[nombreTrous])
                .Select((nombre, index) => coupsJoueur[index] - pars[index])
                .Sum());
        }
    }
}

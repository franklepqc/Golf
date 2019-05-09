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
        /// <returns>Score normal.</returns>
        public sbyte? Calculer(byte[] pars, byte[] coupsJoueur)
        {
            // Vérifications.
            if (pars?.Length != 9 ||
                coupsJoueur?.Length != 9)
            {
                Debug.WriteLine("Informations manquantes.");
                return null;
            }

            // Calcul avec Linq.
            return Convert.ToSByte((new byte[9])
                .Select((nombre, index) => coupsJoueur[index] - pars[index])
                .Sum());
        }
    }
}

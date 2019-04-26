using System;

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
        public sbyte Calculer(byte[] pars, byte[] coupsJoueur)
        {
            return 0;
        }
    }
}

using Golf.Biz.Interfaces;
using Golf.Biz.Persistance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Golf.Biz
{
    /// <summary>
    /// Repository des parties. Sert à la persistance de l'information.
    /// </summary>
    public class RepoParties : IRepoParties
    {
        /// <summary>
        /// Contexte du golf (bd).
        /// </summary>
        private ContexteGolf _contexteGolf;

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="contexteGolf">Contexte pour la BD.</param>
        public RepoParties(ContexteGolf contexteGolf)
        {
            _contexteGolf = contexteGolf;
        }

        /// <summary>
        /// Persiste les informations dans la BD.
        /// </summary>
        /// <param name="coupsJoueur">Coups des joueurs.</param>
        /// <param name="pars">Pars.</param>
        /// <param name="resultat">Score final.</param>
        public Task SauvegarderAsync(IEnumerable<byte> coupsJoueur, IEnumerable<byte> pars, sbyte resultat) =>
            Task.Run(() =>
            {
                var partie = new Partie();
                partie.Score = resultat;
                _contexteGolf.Partie.Add(partie);

                try
                {
                    _contexteGolf.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            });
    }
}

using Golf.Biz.Interfaces;
using System;
using System.Collections.Generic;

namespace Golf.Biz
{
    /// <summary>
    /// Repository des parties. Sert à la persistance de l'information.
    /// </summary>
    public class RepoParties : IRepoParties
    {
        public void Sauvegarder(IEnumerable<byte> coupsJoueur, IEnumerable<byte> pars, sbyte resultat)
        {
            
        }
    }
}

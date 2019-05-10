using System.Collections.Generic;

namespace Golf.Biz.Interfaces
{
    public interface IRepoParties
    {
        void Sauvegarder(IEnumerable<byte> coupsJoueur, IEnumerable<byte> pars, sbyte resultat);
    }
}

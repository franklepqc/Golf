using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golf.Biz.Interfaces
{
    public interface IRepoParties
    {
        Task SauvegarderAsync(IEnumerable<byte> coupsJoueur, IEnumerable<byte> pars, sbyte resultat);
    }
}

using Golf.Biz.Interfaces;
using Golf.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Golf.UI.ViewModels
{
    public class MainWindowViewModel
    {
        #region Fields

        /// <summary>
        /// Service de calcul.
        /// </summary>
        private readonly ICalculScoreFinal _serviceCalcul;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="serviceCalcul">Service de calcul.</param>
        public MainWindowViewModel(ICalculScoreFinal serviceCalcul)
        {
            // Injection.
            _serviceCalcul = serviceCalcul;

            // Initialisation des pars.
            Pars = new byte[9];

            // Initialisation des essais.
            EssaisJoueur = new List<Coup>(new Coup[9]);

            // Initialisation de la commande.
            //CommandeCalculer = new DelegateCommand(() => Calculer);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Essais du joueur.
        /// </summary>
        public IEnumerable<Coup> EssaisJoueur { get; }

        /// <summary>
        /// Le par de la partie.
        /// À initialiser au début.
        /// </summary>
        public IEnumerable<byte> Pars { get; }

        /// <summary>
        /// Résultat de la partie.
        /// </summary>
        public sbyte? Resultat { get; private set; }

        /// <summary>
        /// Commande pour le calcul.
        /// </summary>
        public ICommand CommandeCalculer { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Effectue le calcul.
        /// </summary>
        private void Calculer()
        {
            Resultat = _serviceCalcul.Calculer(
                Pars.ToArray(),
                EssaisJoueur.Where(p => p.Valeur.HasValue).Select(p => p.Valeur.Value).ToArray());
        }

        #endregion Methods
    }
}
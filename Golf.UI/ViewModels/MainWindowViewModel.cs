using Golf.Biz.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            EssaisJoueur = new ObservableCollection<byte>(new byte[9]);

            // Attribution du changement.
            EssaisJoueur.CollectionChanged += SurChangementEssaisJoueur;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Essais du joueur.
        /// </summary>
        public ObservableCollection<byte> EssaisJoueur { get; }

        /// <summary>
        /// Le par de la partie.
        /// À initialiser au début.
        /// </summary>
        public IEnumerable<byte> Pars { get; }

        /// <summary>
        /// Résultat de la partie.
        /// </summary>
        public sbyte? Resultat { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Effectue le calcul.
        /// </summary>
        private void Calculer()
        {
            Resultat = _serviceCalcul.Calculer(
                Pars.ToArray(),
                EssaisJoueur.ToArray());
        }

        /// <summary>
        /// Sur changement d'un essai du joueur.
        /// </summary>
        /// <param name="sender">Objet applant la méthode.</param>
        /// <param name="e">Argument.</param>
        private void SurChangementEssaisJoueur(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Calculer();
        }

        #endregion Methods
    }
}
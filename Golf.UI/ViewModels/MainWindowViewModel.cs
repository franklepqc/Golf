using Golf.Biz.Interfaces;
using Golf.UI.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Golf.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Service de calcul.
        /// </summary>
        private readonly ICalculScoreFinal _serviceCalcul;

        /// <summary>
        /// Conteneurs.
        /// </summary>
        private sbyte? _resultat;

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

            // Initialisation des essais.
            var hasard = new Random();
            Trous = (new Trou[9])
                .Select((coup, index) => new Trou(Convert.ToByte(index + 1), Convert.ToByte(hasard.Next(2, 6))))
                .ToList();

            // Initialisation de la commande.
            CommandeCalculer = new DelegateCommand(Calculer);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Trous.
        /// </summary>
        public IEnumerable<Trou> Trous { get; }

        /// <summary>
        /// Résultat de la partie.
        /// </summary>
        public sbyte? Resultat
        {
            get => _resultat;
            set => SetProperty(ref _resultat, value);
        }

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
                Trous.Select(trou => trou.Par).ToArray(),
                Trous.Where(trou => trou.NombreCoupsJoueur.HasValue).Select(trou => trou.NombreCoupsJoueur.Value).ToArray());
        }

        #endregion Methods
    }
}
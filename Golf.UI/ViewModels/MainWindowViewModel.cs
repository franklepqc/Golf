using Golf.Biz.Interfaces;
using Golf.UI.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private TypePartieEnum _typePartie;
        private bool _typePartie9Trous;
        private bool _typePartie18Trous;

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

            // Initialisation de la commande.
            CommandeCalculer = new DelegateCommand(Calculer);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Trous.
        /// </summary>
        public ICollection<Trou> Trous { get; } = new ObservableCollection<Trou>();

        /// <summary>
        /// Résultat de la partie.
        /// </summary>
        public sbyte? Resultat
        {
            get => _resultat;
            set => SetProperty(ref _resultat, value);
        }

        /// <summary>
        /// Type de la partie.
        /// </summary>
        public TypePartieEnum TypePartie
        {
            get => _typePartie;
            set => SetProperty(ref _typePartie, value, () => GenererTrous());
        }

        /// <summary>
        /// Type de la partie (9 trous).
        /// </summary>
        public bool TypePartie9Trous
        {
            get => _typePartie9Trous;
            set => SetProperty(ref _typePartie9Trous, value, () => {
                _typePartie18Trous = false;
                if (TypePartie9Trous) TypePartie = TypePartieEnum.NeufTrous;
            });
        }

        /// <summary>
        /// Type de la partie (18 trous).
        /// </summary>
        public bool TypePartie18Trous
        {
            get => _typePartie18Trous;
            set => SetProperty(ref _typePartie18Trous, value, () => {
                _typePartie9Trous = false;
                if (TypePartie18Trous) TypePartie = TypePartieEnum.DixHuitTrous;
            });
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
                Trous.Where(trou => trou.NombreCoupsJoueur.HasValue).Select(trou => trou.NombreCoupsJoueur.Value).ToArray(),
                TypePartie);
        }

        /// <summary>
        /// Générer les trous.
        /// </summary>
        private void GenererTrous()
        {
            // Vider la liste précédente.
            Trous.Clear();

            // Initialisation des essais.
            var hasard = new Random();
            (new Trou[(int)TypePartie])
                .Select((coup, index) => new Trou(Convert.ToByte(index + 1), Convert.ToByte(hasard.Next(2, 6))))
                .ToList()
                .ForEach((unTrou) => Trous.Add(unTrou));

        }

        #endregion Methods
    }
}
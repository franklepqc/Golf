using Golf.Biz;
using Golf.Biz.Interfaces;
using Golf.UI.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace Golf.UI
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Récupération de la fenêtre de départ.
        /// </summary>
        /// <returns>Window.</returns>
        protected override Window CreateShell() =>
            Container.Resolve<MainWindow>();

        /// <summary>
        /// Injection.
        /// </summary>
        /// <param name="containerRegistry">Régistraire.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICalculScoreFinal, CalculScoreFinal>();
            containerRegistry.Register<IRepoParties, RepoParties>();
        }
    }
}

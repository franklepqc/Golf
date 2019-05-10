using Golf.Biz;
using Golf.Biz.Interfaces;
using Golf.Biz.Persistance;
using Golf.UI.Views;
using Microsoft.EntityFrameworkCore;
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

            // BD.
            containerRegistry.RegisterInstance(Construire());
        }

        /// <summary>
        /// Construction du contexte de BD.
        /// </summary>
        /// <returns>Contexte de BD.</returns>
        private ContexteGolf Construire()
        {
            var constructeurOptions = new DbContextOptionsBuilder();
            constructeurOptions.UseSqlServer(@"server=(LocalDb)\MSSQLLocalDb;database=Golf;Integrated Security=True");
            return new ContexteGolf(constructeurOptions.Options);
        }
    }
}

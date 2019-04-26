using Golf.Biz;
using Golf.UI.ViewModels;

namespace Golf.UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(
                new CalculScoreFinal());
        }
    }
}

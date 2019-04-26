using System;
using System.Globalization;
using System.Windows.Data;

namespace Golf.UI.Views
{
    /// <summary>
    /// Classe permettant la conversion du score selon la norme du jeu.
    /// -1 : un sous la normale.
    /// 0 : normale.
    /// +1 : un au-dessus de la normale.
    /// </summary>
    public class ScoreStandardGolf : IValueConverter
    {
        /// <summary>
        /// Vers l'interface utilisateur.
        /// </summary>
        /// <param name="value">Valeur.</param>
        /// <param name="targetType">Type de retour.</param>
        /// <param name="parameter">Paramètre.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Chaîne de caractères.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Valeur.
            var score = value as sbyte?;

            if (null != score)
            {
                if (score.Value > (sbyte)0)
                {
                    return $"+{score.Value}";
                }
            }

            return value;
        }

        /// <summary>
        /// IMPORTANT : ne doit pas être pris en charge!
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

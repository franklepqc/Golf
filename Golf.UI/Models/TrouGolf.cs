namespace Golf.UI.Models
{
    /// <summary>
    /// Caractéristiques d'un trou de golf.
    /// </summary>
    public class Trou
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="numero">N° du trou.</param>
        /// <param name="par">Par.</param>
        public Trou(byte numero, byte par)
        {
            Numero = numero;
            Par = par;
        }

        /// <summary>
        /// N°.
        /// </summary>
        public byte Numero { get; set; }

        /// <summary>
        /// Nombre de tentatives effectuées par le joueur.
        /// </summary>
        public byte? NombreCoupsJoueur { get; set; }

        /// <summary>
        /// Par (nombre de tentatives normales).
        /// </summary>
        public byte Par { get; set; }
    }
}

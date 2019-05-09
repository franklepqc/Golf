namespace Golf.Biz.Interfaces
{
    public interface ICalculScoreFinal
    {
        sbyte? Calculer(byte[] pars, byte[] coupsJoueur, TypePartieEnum typePartie = TypePartieEnum.Default);
    }
}

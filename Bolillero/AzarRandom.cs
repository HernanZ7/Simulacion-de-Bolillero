namespace Bolillero;

public class AzarRandom : IBolilleroAzar
{
    private readonly Random random = new(DateTime.Now.Millisecond);
    public int SacarIndice(int maximo) => random.Next(maximo);
}

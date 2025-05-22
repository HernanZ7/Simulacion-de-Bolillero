namespace Bolillero;

public class Bolillero
{
    public List<int> Dentro { get; private set; }
    public List<int> Fuera { get; private set; }
    private IBolilleroAzar _azar;

    public Bolillero(int cantidadBolillas, IBolilleroAzar azar)
    {
        Dentro = Enumerable.Range(0, cantidadBolillas).ToList();
        Fuera = new List<int>();
        _azar = azar;
    }

    public int SacarBolilla()
    {
        int indice = _azar.SacarIndice(Dentro.Count);
        int bolilla = Dentro[indice];
        Dentro.RemoveAt(indice);
        Fuera.Add(bolilla);
        return bolilla;
    }

    public void ReIngresar()
    {
        Dentro.AddRange(Fuera);
        Fuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        foreach (int bolillaEsperada in jugada)
        {
            if (SacarBolilla() != bolillaEsperada)
            {
                return false;
            }
        }
        return true;
    }

    public int JugarNVeces(List<int> jugada, int cantidad)
    {
        int aciertos = 0;
        for (int i = 0; i < cantidad; i++)
        {
            if (Jugar(jugada))
                aciertos++;            
            ReIngresar();
        }
        return aciertos;
    }
}


namespace Bolillero.Test;

public class BolilleroTest
{
    private Bolillero bolillero;

    public BolilleroTest()
    {
        bolillero = new Bolillero(10, new Primero());
    }

    [Fact]
    public void SacarBolilla()
    {
        int bolilla = bolillero.SacarBolilla();
        Assert.Equal(0, bolilla);
        Assert.Equal(9, bolillero.Dentro.Count);
        Assert.Single(bolillero.Fuera);
    }

    [Fact]
    public void ReIngresar()
    {
        bolillero.SacarBolilla();
        bolillero.ReIngresar();
        Assert.Equal(10, bolillero.Dentro.Count);
        Assert.Empty(bolillero.Fuera);
    }

    [Fact]
    public void JugarGana()
    {
        bool gano = bolillero.Jugar(new List<int> { 0, 1, 2, 3 });
        Assert.True(gano);
    }

    [Fact]
    public void JugarPierde()
    {
        bool gano = bolillero.Jugar(new List<int> { 4, 2, 1 });
        Assert.False(gano);
    }

    [Fact]
    public void GanarNVeces()
    {
        int ganadas = bolillero.JugarNVeces(new List<int> { 0, 1 }, 1);
        Assert.Equal(1, ganadas);
    }
}


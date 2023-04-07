namespace Aula01.Repositories.Interfaces;


public static class Program
{
    public static void Main()
    {
        ExibirFraseDoUno(new Uno());
        ExibirFraseDoPalio(new Palio());
        ExibirFraseDoFox(new Fox());
        
        ExibirFraseDoCarro(new Uno());
        ExibirFraseDoCarro(new Palio());
        ExibirFraseDoCarro(new Fox());
    }

    public static void ExibirFraseDoCarro(ICarro carro)
    {
        carro.Exibir();
    }
    
    public static void ExibirFraseDoUno(Uno uno)
    {
        uno.Exibir();
    }
    public static void ExibirFraseDoPalio(Palio palio)
    {
        palio.Exibir();
    }
    
    public static void ExibirFraseDoFox(Fox fox)
    {
        fox.Exibir();
    }
}

public interface ICarro
{
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string Exibir();
}

public class Uno : ICarro
{
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string Exibir()
    {
        return $"{Nome} e {Cor}";
    }
}

public class Palio : ICarro
{
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string Exibir()
    {
        return $"{Nome} e {Cor}";
    }
}

public class Fox : ICarro
{
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string Exibir()
    {
        return $"{Nome} e {Cor}";
    }
}
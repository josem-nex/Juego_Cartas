namespace Game;

public class Human_Player : Player
{
    public Human_Player(string id, int dinero) : base(id, dinero)
    {
    }
    internal override int realizar_apuesta()
    {
        var line = Console.ReadLine();
        while (string.IsNullOrEmpty(line))
        {
            Console.Write("Apuesta Bien >");
            line = Console.ReadLine();
        }
        var a = (int)L.Use_Compiler(line);
        return a;
    }
}

using Poker;
public class Program
{
    public static void Main()
    {
        Scorer scorer = new Scorer();


        Player A = new Human_Player("TestA", 500);
        Player B = new Human_Player("TestB", 500);
        Player C = new Human_Player("TestC", 500);
        Player D = new Human_Player("TestD", 500);


        List<Mini_Ronda_Contexto> mini_rondas_contexto = new List<Mini_Ronda_Contexto>()
        {
            new Mini_Ronda_Contexto(2),
            new Mini_Ronda_Contexto(3, new Repartidor()),
            new Mini_Ronda_Contexto(1, new Repartidor()),
            new Mini_Ronda_Contexto(1, new Repartidor()),
        };

        Ronda_Context ronda = new Ronda_Context(mini_rondas_contexto);

        Factory factory = new Factory();

        // Define settings for the game.
        Global_Contexto context = new Global_Contexto(ronda, factory, A, B, C);
        IFrontMiniRonda front = new FrontMiniRonda();
        IFrontRonda frontRonda = new FrontRonda();
        IFrontendGame frontGame = new FrontGame(front, frontRonda);
        Manager manager = new Manager(scorer, context, frontGame);
    }
}
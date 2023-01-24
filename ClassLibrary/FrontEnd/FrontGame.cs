namespace Poker;

public class FrontGame : IFrontendGame{
    public FrontGame(IFrontMiniRonda frontMiniRonda, IFrontRonda frontRonda)
    {
        FrontMiniRonda = frontMiniRonda;
        FrontRonda = frontRonda;
    }
    public void StarGame(){
        Tools.ShowColoredMessage("Comienza la partida: \n", ConsoleColor.DarkGray);
    }
    public void EndGame(Player winner){
        Tools.ShowColoredMessage($"El ganador es:   {winner.Id} \n", ConsoleColor.DarkGray);
    }
    public IFrontMiniRonda FrontMiniRonda { get; }
    public IFrontRonda FrontRonda { get; }
}
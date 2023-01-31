namespace Poker;
/// <summary>
/// This class represent the FrontEnd of the Ronda. It is implemented in the console.
/// </summary>
public class FrontRonda : IFrontRonda
{
    public FrontRonda()
    {
    }
    public void EmpezarRonda(IEnumerable<Player> Participants){
        Tools.ShowColoredMessage("Comienza Una Nueva Ronda con los jugadores :", ConsoleColor.DarkRed);
        foreach (var player in Participants)
        {
            Tools.ShowColoredMessage(" " + player.Id + ", ", ConsoleColor.Blue);
        }
        Console.WriteLine();
    }
    public void RondaSinGanar(){
        Console.WriteLine("Nadie ganó la ronda");
        Console.WriteLine();
    }
    public void MostrarGanadores(IEnumerable<Player> winners){
        if (winners.Count() == 0)
        {
            Tools.ShowColoredMessage($"Nadie ganó la partida", ConsoleColor.DarkGray);
            return;
        }
        Tools.ShowColoredMessage("La ronda fue ganada por: ", ConsoleColor.DarkGray);
        foreach (var winner in winners)
        {;
            Tools.ShowColoredMessage($"{winner.Id} con ${winner.Dinero}, ", ConsoleColor.DarkGray);
        }
        Console.WriteLine();
    }
    public void TerminarRonda(IEnumerable<Player> Participants){
        foreach (var participant in Participants)
            Console.WriteLine($"{participant.Id}".PadLeft(Participants.Select(x => x.Id.Length).Max()) + " " + participant.Hand + $" {participant.Hand.rank}");
    }
}
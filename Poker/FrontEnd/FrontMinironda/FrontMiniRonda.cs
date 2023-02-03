using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// This class represent the FrontEnd of the MiniRonda. It is implemented in the console.
/// </summary>
namespace Poker;
public class FrontMiniRonda : IFrontMiniRonda
{
    public FrontMiniRonda()
    {
    }

    public void TerminarMiniRonda()
    {
        Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine();
    }
    public void EntrePlayer(){
        Console.WriteLine("-----------------------------------------------------------------");
    }
    public void EmpezarMiniRonda(IEnumerable<Player> players)
    {
        foreach (var player in players)
        {
            Console.Write("Esta es la mano de ");
            Tools.ShowColoredMessage($"{player.Id}".PadLeft(6), ConsoleColor.DarkMagenta);
            Console.Write("  " + player.Hand);
            Console.Write($"con ${player.Dinero} \n");
        }
    }
    public void Decide(bool flag, Player player)
    {
        Console.Write(flag ? player.Id + " decide bien > " : player.Id + " decide > ");
    }
    public void DecisionInvalida()
    {
        Tools.ShowColoredMessage("Decisión Inválida \n", ConsoleColor.DarkRed);
    }
    public void DecisionInvalida(string Help)
    {
        Tools.ShowColoredMessage("Ejecuta bien tu decisión! \n", ConsoleColor.DarkRed);
        Tools.ShowColoredMessage(Help, ConsoleColor.DarkGray);
        Console.WriteLine();
    }
    public void TomarDecision(string decision)
    {
        Tools.ShowColoredMessage($"Tomaste la decision de " + decision + "\n", ConsoleColor.Green);
    }
}
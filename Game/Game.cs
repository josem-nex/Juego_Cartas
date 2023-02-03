using Poker;

public class Game
{
    private Manager Manager;
    private IFrontendGame FrontGame;
    public Game(Manager manager, IFrontendGame frontGame)
    {
        Manager = manager;
        FrontGame = frontGame;
    }
    public void ExecuteGame()
    {
        FrontGame.StarGame();
        while (Manager.GetActivePlayers().Count() > 1)
        {
            ExecuteRonda();
        }
        var winner = Manager.GetWinner();
        FrontGame.EndGame(winner);
        Manager.EndGame(winner);
    }
    public void ExecuteRonda()
    {
        FrontGame.FrontRonda.EmpezarRonda(Manager.GetActivePlayersRonda());
        Manager.StartRonda();
        Manager.ExecuteRonda();
        ExecuteMiniRondas();
        var winners = Manager.GetWinnersRonda();
        FrontGame.FrontRonda.MostrarGanadores(winners);
        var Participants = Manager.GetActivePlayersRonda();
        FrontGame.FrontRonda.TerminarRonda(Participants);
        Manager.EndRonda();
    }
    public void ExecuteMiniRondas()
    {
        List<Mini_Ronda_Contexto> mini_Ronda_Contextos = Manager.Global_Contexto.Ronda_Contexto.Contextos;
        IEnumerable<Player> result = Enumerable.Empty<Player>();

        foreach (var contexto_config in mini_Ronda_Contextos)
        {
            Manager.ExecuteMiniRondas(contexto_config);

            var participants = Manager.GetActivePlayersMiniRonda();
            FrontGame.FrontMiniRonda.EmpezarMiniRonda(participants);

            foreach (var player in participants)
            {
                if (participants.Count() <= 1) break;
                if (player.Dinero > 0)
                {
                    bool flag = false;
                    bool mask = true;
                    do
                    {
                        FrontGame.FrontMiniRonda.Decide(flag, player);
                        string accion = Console.ReadLine();
                        var info_decision = Manager.InfoDecision(player, accion);
                        if (info_decision.Item1 != "InvalidDecision")
                        {
                            FrontGame.FrontMiniRonda.TomarDecision(info_decision.Item1);
                            if (Manager.MakeDecision(player, accion)) mask = false;
                            else FrontGame.FrontMiniRonda.DecisionInvalida(info_decision.Item2);
                        }
                        else FrontGame.FrontMiniRonda.DecisionInvalida();

                        flag = true;
                    } while (mask);
                }
                FrontGame.FrontMiniRonda.EntrePlayer();

            }

            result = Manager.GetActivePlayersMiniRonda();
            FrontGame.FrontMiniRonda.TerminarMiniRonda();
        }
        Manager.Execute_Winners(result);
    }
}
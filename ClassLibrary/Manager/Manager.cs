namespace Poker;
public class Manager
{
    /// <summary>
    /// A manager is responsible for Simulate the game, 
    /// </summary>
    /// <param name="scorer"> An object of type Scorer has the ranks for playing Poker </param>
    /// <param name="bets"> In each mini_round each player receives a specified number of cards,
    /// so passing [5,1,1] will make a round composed by three mini_round of bets, receiving
    /// 5,1,1 respectively cards in each round</param>
    /// <param name="players"> Well literally the players of the game</param>
    public Manager(Scorer scorer, IGlobal_Contexto global_Contexto, IFrontendGame frontGame)
    {
        Scorer = scorer;
        Global_Contexto = global_Contexto;
        FrontGame = frontGame;
    }
    private Scorer Scorer { get; }
    public IFrontendGame FrontGame { get;}
    public IGlobal_Contexto Global_Contexto { get; }
    internal IEnumerable<Player> Players
    {
        get
        {
            return Global_Contexto.PlayerManager.Players;
        }
    }
    public void SimulateGame()
    {
        FrontGame.StarGame();
        while (Global_Contexto.PlayerManager.Get_Active_Players(1).Count() > 1)
        {
            Global_Contexto.Config();
            Ronda ronda = new Ronda(Scorer, Global_Contexto, FrontGame);
            Global_Contexto.PlayerManager.Set_Active_Players(ronda.Simulate());
        }
        var winner = Global_Contexto.PlayerManager.Get_Player_By_Pos(0);
        foreach (var player in Global_Contexto.PlayerManager.Players.Where(x => x.Id != winner.Id))
        {
            if (player.Colector.get_efectos.Count > 0)
            {
                winner.Colector.add_efecto(player.Colector.remove_efecto());
            }
        }
        Global_Contexto.PlayerManager.Filtro_Partida = new List<PlayerManager.Filtrar>();
        FrontGame.EndGame(winner);
    }
}
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
    internal Ronda ronda { get; private set; }
    public void StartRonda(){
        Global_Contexto.Config();
        ronda = new Ronda(Scorer, Global_Contexto, FrontGame);
    }
    public void ExecuteRonda() => ronda.Simulate();
    public void EndRonda(){
        ronda.EndRonda();
        Global_Contexto.PlayerManager.Set_Active_Players(ronda.ParticipantsEndRonda());
    }
    public IEnumerable<Player> GetWinnersRonda() => ronda.Winners;
    public Player GetWinner() =>  Global_Contexto.PlayerManager.Get_Player_By_Pos(0);
    public IEnumerable<Player> GetActivePlayers() => Global_Contexto.PlayerManager.Get_Active_Players(1);
    public IEnumerable<Player> GetActivePlayersRonda() => Global_Contexto.PlayerManager.Get_Active_Players(2);
    public void EndGame(Player winner){
        foreach (var player in Global_Contexto.PlayerManager.Players.Where(x => x.Id != winner.Id))
        {
            if (player.Colector.get_efectos.Count > 0)
            {
                winner.Colector.add_efecto(player.Colector.remove_efecto());
            }
        }
        Global_Contexto.PlayerManager.Filtro_Partida = new List<PlayerManager.Filtrar>();
    }
}
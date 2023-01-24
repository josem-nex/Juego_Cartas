namespace Poker;
/// <summary>
/// This represent what happens inside a round.
/// </summary>
internal class MiniRonda
{
    public MiniRonda(IGlobal_Contexto contexto, Mini_Ronda_Contexto mini_contexto, IFrontMiniRonda frontGame)
    {
        Global_Contexto = contexto;
        Mini_Contexto = mini_contexto;
        FrontGame = frontGame;
    }
    public IFrontMiniRonda FrontGame { get; }
    public IGlobal_Contexto Global_Contexto { get; }
    public IEnumerable<Player> Participants => Global_Contexto.PlayerManager.Get_Active_Players(3);
    public Mini_Ronda_Contexto Mini_Contexto { get; }
    internal IEnumerable<Player> Execute()
    {
        Global_Contexto.PlayerManager.Filtro_Mini_Ronda = new List<PlayerManager.Filtrar>();
        foreach (var player in Participants)
        {
            if (Participants.Count() <= 1)
            {
                break;
            }
            Global_Contexto.Ronda_Contexto.CardsManager.AñadirCartas(Mini_Contexto.Repartidor, player, Mini_Contexto.Cant_Cartas);
            FrontGame.EmpezarJugada(player);
            if (player.Dinero > 0)
            {
                JugarPlayer(player);
            }
            FrontGame.EntrePlayer();
        }
        FrontGame.TerminarMiniRonda();
        return Participants;
        
    }
    void JugarPlayer(Player player)
    {
        Global_Contexto.PlayerManager.Current = player; // this is a patch?
        IDecision decision = new InvalidDecision();
        bool flag = false;
        do
        {
            FrontGame.Decide(flag);
            var try_decision = player.parse_decision(this.Global_Contexto);
            if (try_decision.Id != "InvalidDecision")
            {
                FrontGame.TomarDecision(try_decision);
                if (try_decision.DoDecision(player, this.Global_Contexto)) decision = try_decision;
                else   FrontGame.DecisionInvalida(try_decision);
            }
            else FrontGame.DecisionInvalida();
            flag = true;
        } while (decision.Id == "InvalidDecision");
        // at this point the player bets a reasonable number.
    }
}
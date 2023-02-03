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
    internal void Execute()
    {
        Global_Contexto.PlayerManager.Filtro_Mini_Ronda = new List<PlayerManager.Filtrar>();
        foreach (var player in Participants)
        {
            if (Participants.Count() <= 1) break;
            
            RepartirCartas(player);
        }
    }
    internal void RepartirCartas(Player player) => Global_Contexto.Ronda_Contexto.CardsManager.AñadirCartas(Mini_Contexto.Repartidor, player, Mini_Contexto.Cant_Cartas);
    internal (string, string) InfoDecision(string accion, Player player){
        var try_decision = player.parse_decision(this.Global_Contexto, accion);
        return (try_decision.Id, try_decision.Help);
    }
    internal bool MakeDecision(string accion, Player player){
        var try_decision = player.parse_decision(this.Global_Contexto, accion);
        
        if (try_decision.DoDecision(player, this.Global_Contexto)) return true;
        else   return false;
        
    }
    
}
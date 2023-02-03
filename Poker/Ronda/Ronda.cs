namespace Poker;
/// <summary>
/// A match is nothing else that simulate Rounds until there is only one player with Money.
/// </summary>
internal class Ronda
{
    internal Ronda(Scorer scorer, IGlobal_Contexto contexto, IFrontendGame frontGame)
    {
        Global_Contexto = contexto;
        Scorer = scorer;
        FrontGame = frontGame;
    }
    public IFrontendGame FrontGame { get; }
    public Scorer Scorer { get; }
    public IEnumerable<Player> Participants => Global_Contexto.PlayerManager.Get_Active_Players(2);
    public IGlobal_Contexto Global_Contexto { get; }
    internal List<Player> Winners { get; private set; }
    internal List<Player> ParticipantsEndRonda() => Participants.Where(x => x.Dinero > 0).ToList();
    internal void StartRonda()
    {
        Global_Contexto.PlayerManager.Filtro_Ronda = new List<PlayerManager.Filtrar>();
        foreach (var player in Participants)
            player.Hand = new Hand(this.Scorer);
    }
    internal MiniRonda CreateMiniRonda(Mini_Ronda_Contexto contexto_config)
    {
        Global_Contexto.PlayerManager.Filtro_Mini_Ronda = new List<PlayerManager.Filtrar>();
        var Mini_ronda = new MiniRonda(this.Global_Contexto, contexto_config, FrontGame.FrontMiniRonda);
        Global_Contexto.PlayerManager.Filtro_Mini_Ronda = new List<PlayerManager.Filtrar>();

        return Mini_ronda;
    }
    internal List<Player> GetWinners(IEnumerable<Player> round_finalist)
    {
        var player_by_hand = round_finalist.Select(x => x.Hand).OrderDescending();
        var best_hand = player_by_hand.FirstOrDefault();
        var worse_hand = player_by_hand.Last();
        if (best_hand is null)
        {
            return new List<Player>();
        }
        Winners = round_finalist.Where(x => x.Hand.Igual(best_hand)).ToList();
        return Winners;
    }

    internal void Execute_Winners(List<Player> winners)
    {
        foreach (var winner in winners)
            winner.Dinero = winner.Dinero + Global_Contexto.Ronda_Contexto.Apuestas.Get_Dinero_Total_Apostado() / winners.Count;
    }
    internal void EndRonda()
    {
        Global_Contexto.PlayerManager.Filtro_Ronda = new List<PlayerManager.Filtrar>();  
        foreach (var player in Participants)
        {
            player.Hand = new Hand(this.Scorer);
        }
        foreach (var efecto in Global_Contexto.FinalRoundEffects)
        {
            efecto.Evaluate(Global_Contexto);
        }
    }
}
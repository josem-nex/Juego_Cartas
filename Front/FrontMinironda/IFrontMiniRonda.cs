namespace Front;
using Poker;
public interface IFrontMiniRonda
{
    void EmpezarMiniRonda(IEnumerable<Player> players);
    void Decide(bool flag, Player player);
    void DecisionInvalida();
    void DecisionInvalida(string Help);
    void TomarDecision(string decision);
    void TerminarMiniRonda();
    void EntrePlayer();
    
}

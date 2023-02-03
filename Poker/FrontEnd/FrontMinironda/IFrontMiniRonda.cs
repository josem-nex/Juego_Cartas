namespace Poker;

public interface IFrontMiniRonda
{
    void EmpezarJugada(Player player);
    void Decide(bool flag);
    void DecisionInvalida();
    void DecisionInvalida(IDecision decision);
    void TomarDecision(IDecision decision);
    void TerminarMiniRonda();
    void EntrePlayer();
    
}

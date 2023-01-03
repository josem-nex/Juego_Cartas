namespace Poker;
public interface IGlobal_Contexto
{
    PlayerManager PlayerManager { get; }
    IRonda_Context Ronda_Contexto { get; }

    Factory factory { get; }
    void Config();
}

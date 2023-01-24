namespace Poker;

public class FrontGame : IFrontendGame{
    public FrontGame(IFrontMiniRonda frontMiniRonda, IFrontRonda frontRonda)
    {
        FrontMiniRonda = frontMiniRonda;
        FrontRonda = frontRonda;
    }
    public IFrontMiniRonda FrontMiniRonda { get; }
    public IFrontRonda FrontRonda { get; }
}
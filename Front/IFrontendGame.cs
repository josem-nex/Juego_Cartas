using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front;
using Poker;

public interface IFrontendGame
{
    IFrontMiniRonda FrontMiniRonda { get; }
    IFrontRonda FrontRonda { get; }
    void EndGame(Player winner);
    void StarGame();
}

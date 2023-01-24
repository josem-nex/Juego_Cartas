using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker;

public interface IFrontendGame
{
    IFrontMiniRonda FrontMiniRonda { get; }
    IFrontRonda FrontRonda { get; }
}

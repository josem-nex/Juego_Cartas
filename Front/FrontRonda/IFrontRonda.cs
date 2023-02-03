using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front;
using Poker;
public interface IFrontRonda
{
    void EmpezarRonda(IEnumerable<Player> Participants);
    void MostrarGanadores(IEnumerable<Player> Winners);
    void TerminarRonda(IEnumerable<Player> Participants);
}

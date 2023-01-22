namespace Poker;

internal sealed class Igualar : IDecision {
    public string Id => "Igualar";
    public bool DoDecision(Player player, IGlobal_Contexto contexto) {
        var apuesta_jugador = contexto.Ronda_Contexto.Apuestas.Get_Max_Sum_Apuesta() - contexto.Ronda_Contexto.Apuestas.Get_Dinero_Apostado(player);
        if (apuesta_jugador < player.Dinero && contexto.Ronda_Contexto.Apuestas.Get_Dinero_Apostado(player) + apuesta_jugador < contexto.Ronda_Contexto.Apuestas.Get_Max_Sum_Apuesta()) {
            return false;
        } else if (apuesta_jugador > player.Dinero || apuesta_jugador == 0) {
            return false;
        }
        contexto.Ronda_Contexto.Apuestas.Apostar(player, apuesta_jugador);
        Tools.ShowColoredMessage($"{player.Id} apostó { contexto.Ronda_Contexto.Apuestas.Get_Last_Apuesta(player)} \n", ConsoleColor.Yellow);
        return true;
    }
    public string Help => "No puedes igualar al inicio de partida o no tienes suficiente dinero para igualar y debes apostar todo tu dinero";
}